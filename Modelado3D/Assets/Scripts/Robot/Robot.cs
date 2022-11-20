using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Autores:
// Daniel Darcía Barajas
// Joan Daniel Guerrero Garcia

public class Robot : MonoBehaviour
{
    //------------------------------------------------------------- Estructuras
    public enum PartsBody
    {
        // Body
        HEAP, TORSO, CHEST, NECK, HEAD,
        // Left ARM
        LSHOUDLER, LUPPERARM, LELBOW, LFOREARM, LHAND, 
        // Right ARM
        RSHOUDLER, RUPPERARM, RELBOW, RFOREARM, RHAND,
        // Left Leg
        LTHIGH, LKNEE, LLEG, LFOOT,
        // Right Leg
        RTHIGH, RKNEE, RLEG, RFOOT
    };

    public struct BackForth
    {
        public float delta, dir, val, min, max;
        public BackForth(float _delta, float _dir, float _val, float _min, float _max)
        {
            delta = _delta;
            dir = _dir;
            val = _val;
            min = _min;
            max = _max;
        }
        public void Update()
        {
            val += delta * dir;
            if(val <= min || val >= max) dir = -dir;
        }
    };

    public static void InstantiateRobotPart(int index, Color color, string name, Vector3 scale, Vector3 position)
    {
        partsBody.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        partsBody[index].GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        partsBody[index].name = name;
        partsBody[index].GetComponent<BoxCollider>().enabled = false;
        scales.Add(Transformaciones.Scale(scale.x,scale.y,scale.z));
        locations.Add(Transformaciones.Translate(position.x, position.y, position.z));
    }

    //------------------------------------------------------------- Variables
    public static List<Matrix4x4> locations;
    public static List<Matrix4x4> scales;
    public static List<GameObject> partsBody;
    Vector3[] vOriginals;
    BackForth rY;
    BackForth rX;
    BackForth rX2;
    BackForth rX3;
    BackForth rX4;
    BackForth Jump;
    Extremity leftArm;
    Extremity rightArm;
    Extremity leftLeg;
    Extremity rightLeg;
    // Start is called before the first frame update
    void Start()
    {
        leftArm = gameObject.AddComponent<Extremity>();
        rightArm = gameObject.AddComponent<Extremity>();
        leftLeg = gameObject.AddComponent<Extremity>();
        rightLeg = gameObject.AddComponent<Extremity>();
        rY = new BackForth(0.10f, -0.5f, 0f, -5f, 5f);
        rX = new BackForth(0.08f, 1f, -1.2f, -1.25f, 20.25f);
        rX2 = new BackForth(0.08f, 1f, 20.2f, -1.25f, 20.25f);
        rX3 = new BackForth(0.18f, 1f, -20.2f, -20.25f, 20.25f);
        rX4 = new BackForth(0.18f, 1f, 20.2f, -20.25f, 20.25f);
        Jump = new BackForth(0.001f, 1f, 0f, -0.05f, 0.05f);

        partsBody = new List<GameObject>();
        scales = new List<Matrix4x4>();
        locations = new List<Matrix4x4>();
        
        //HEAP
        InstantiateRobotPart((int)PartsBody.HEAP, Color.gray, "HEAP", new Vector3(0.95f, 0.5f, 0.95f), new Vector3(0f, 0f, 0f));
        vOriginals = partsBody[(int)PartsBody.HEAP].GetComponent<MeshFilter>().mesh.vertices;
        //TORSO
        InstantiateRobotPart((int)PartsBody.TORSO, Color.white, "TORSO", new Vector3(0.85f, 0.4f, 0.85f), new Vector3(0f, 0.5f/2f + 0.4f/2f, 0f));
        //CHEST
        InstantiateRobotPart((int)PartsBody.CHEST, Color.red, "CHEST", new Vector3(1.1f, 0.75f, 0.9f), new Vector3(0f, 0.4f/2f + 0.75f/2f, 0f));
        //NECK
        InstantiateRobotPart((int)PartsBody.NECK, Color.white, "NECK", new Vector3(0.2f, 0.1f, 0.2f), new Vector3(0f, 0.75f/2f + 0.1f/2f, 0f));
        //HEAD
        InstantiateRobotPart((int)PartsBody.HEAD, Color.blue, "HEAD", new Vector3(0.4f, 0.5f, 0.5f), new Vector3(0f, 0.1f/2f + 0.5f/2f, 0f));

        leftArm.Create("ARM", "LEFT");
        rightArm.Create("ARM", "RIGHT");
        leftLeg.Create("LEG", "LEFT");
        rightLeg.Create("LEG", "RIGHT");
    }

    // Update is called once per frame
    void Update()
    {
        rY.Update();
        Jump.Update();
        rX.Update();
        rX2.Update();
        rX3.Update();
        rX4.Update();
        Matrix4x4 accumT = Matrix4x4.identity;
        Matrix4x4 accumChest = Matrix4x4.identity;
        for (int i = (int)PartsBody.HEAP; i <= (int)PartsBody.HEAD; i++)
        {
            Matrix4x4 m = accumT * locations[i] * scales[i];
            if(i == (int)PartsBody.HEAP)
            {
                Matrix4x4 t = Transformaciones.Translate(0, Jump.val, 0f);
                m = accumT * locations[i] * t * scales[i];
                accumT *= locations[i] * t;
                leftLeg.Draw(ref accumT, ref partsBody, ref locations, ref scales, vOriginals, rX, rX2, rX3, rX4);
                rightLeg.Draw(ref accumT, ref partsBody, ref locations, ref scales, vOriginals, rX, rX2, rX3, rX4);
            }
            else if(i == (int)PartsBody.CHEST)
            {
                Matrix4x4 r = Transformaciones.RotateY(rY.val);
                m = accumT * locations[i] * r * scales[i];
                accumT *= locations[i] * r;
                accumChest = accumT;
                leftArm.Draw(ref accumChest, ref partsBody, ref locations, ref scales, vOriginals, rX, rX2, rX3, rX4);
                rightArm.Draw(ref accumChest, ref partsBody, ref locations, ref scales, vOriginals, rX, rX2, rX3, rX4);
            }
            else if(i == (int)PartsBody.NECK)
            {
                Matrix4x4 r = Transformaciones.RotateY(-rY.val);
                m = accumT * locations[i] * r * scales[i];
                accumT *= locations[i] * r;
            }
            else
                accumT *= locations[i];
            
            partsBody[i].GetComponent<MeshFilter>().mesh.vertices = Transformaciones.Transform(m, vOriginals);
        }
    }
}
