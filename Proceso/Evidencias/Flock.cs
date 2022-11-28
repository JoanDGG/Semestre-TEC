using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    private enum FlockingStates
    {
        Follow, Evade
    }
    public float speed;
    public float rayCastDistance = 55f;
    public float turnAngle = 10f;
    [SerializeField] private FlockingStates currentState;
	internal FlockController controller;
    private GameObject[] pointList;
    private new Rigidbody rigidbody;
    private Vector3 relativePos;
    private Vector3 randomize;
    private Vector3 destPos;
    // private Vector3 down;
    private int index = -1;
    private void Start()
    {
        pointList = GameObject.FindGameObjectsWithTag("Point");
        rigidbody = GetComponent<Rigidbody>();
        currentState = FlockingStates.Follow;
        relativePos = new Vector3();
        // down = new Vector3(0f, -0.5f, 1f);

        FindNextPoint();
    }

    private void FindNextPoint()
    {
        print("Finding next point");
        index = (index+1)%pointList.Length; //Random.Range(0, pointList.Count);
        destPos = pointList[index].transform.position;
    }
    
    void FixedUpdate()
    {
        if (controller)
        {
            CheckRaycast();
            
            relativePos = Steer() * Time.deltaTime;
            if (currentState == FlockingStates.Evade)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, rayCastDistance, 1 << 6))
                {
                    rigidbody.AddForce(hit.normal * hit.rigidbody.gameObject.GetComponent<Collider>().repulsionForce, ForceMode.Impulse);

                    if(Vector3.Angle(hit.normal, transform.forward) > 0)
                    {
                        if(hit.point.x > hit.collider.bounds.center.x)
                            transform.Rotate(0f, turnAngle, 0f, Space.Self);
                        else if(hit.point.x < hit.collider.bounds.center.x)
                            transform.Rotate(0f, -turnAngle, 0f, Space.Self);
                        
                        if(hit.point.y > hit.collider.bounds.center.y)
                            transform.Rotate(-turnAngle, 0f, 0f, Space.Self);
                        else if(hit.point.y < hit.collider.bounds.center.y)
                            transform.Rotate(turnAngle, 0f, 0f, Space.Self);
                    }
                }

                // Fuerza hacia .forward
                rigidbody.AddForce(transform.forward, ForceMode.Impulse);
            }
            else if (currentState == FlockingStates.Follow)
            {
                Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }

            if(relativePos != Vector3.zero)
                rigidbody.velocity = relativePos;

            float currentSpeed = rigidbody.velocity.magnitude;

            if (currentSpeed > controller.maxVelocity)
                rigidbody.velocity = rigidbody.velocity.normalized * controller.maxVelocity;
                
            else if (currentSpeed < controller.minVelocity) 
                rigidbody.velocity = rigidbody.velocity.normalized * controller.minVelocity;
        }
    }

    private void CheckRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayCastDistance))    // Front sensor
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if(hit.collider.tag != "Point")
                currentState = FlockingStates.Evade;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayCastDistance, Color.blue);
            currentState = FlockingStates.Follow;
        }
    }

    //Calculate flock steering Vector based on the Craig Reynold's algorithm (Cohesion, Alignment, Follow leader and Seperation)
    private Vector3 Steer() 
    {
        Vector3 center = controller.flockCenter - transform.localPosition;          // cohesion
        Vector3 velocity = controller.flockVelocity - rigidbody.velocity;           // alignment
        Vector3 follow = destPos - transform.localPosition;                         // follow leader
        Vector3 separation = Vector3.zero; 											// separation

        foreach (Flock flock in controller.flockList) 
        {
            if (flock != this) 
            {
                Vector3 relativePos = transform.localPosition - flock.transform.localPosition;
                separation += relativePos.normalized;
            }
        }

        // Randomize the direction every 2 seconds
        if(Time.time % 2==0)
        {
            randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);
            randomize.Normalize();
        }

        return (controller.centerWeight * center +
                controller.velocityWeight * velocity +
                controller.separationWeight * separation +
                controller.followWeight * follow +
                controller.randomizeWeight * randomize);
    }	
}
