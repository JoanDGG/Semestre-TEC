using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Vector2 clampDegrees = new Vector2(360, 180);
    public Vector2 smoothValues =  new Vector2(3, 3);
    public Vector2 sensitivity =  new Vector2(2, 2);
    
    private bool lockCursor = true;
    private Vector2 targetDirection;
    private Vector2 mousePosition;
    private Vector2 mouseSmooth;
    private Animator animator;
    void Start()
    {
        targetDirection = transform.rotation.eulerAngles;
        animator = GetComponent<Animator>();
        Cursor.visible = !lockCursor;
    }
    void LateUpdate()
    {
        animator.SetBool("Turbo", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        SetLockCursor();
        Follow();
    }

    private void SetLockCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            lockCursor = !lockCursor;

        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }

    private void Follow()
    {
        Quaternion targetOrientation = Quaternion.Euler(targetDirection);

        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothValues.x, sensitivity.y * smoothValues.y));

        mouseSmooth.x = Mathf.Lerp(mouseSmooth.x, mouseDelta.x, 1f / smoothValues.x);
        mouseSmooth.y = Mathf.Lerp(mouseSmooth.y, mouseDelta.y, 1f / smoothValues.y);

        mousePosition += mouseSmooth;

        if(clampDegrees.x < 360)
            mousePosition.x = Mathf.Clamp(mousePosition.x, -clampDegrees.x * 0.5f, clampDegrees.x * 0.5f);
        
        transform.localRotation = Quaternion.AngleAxis(-mousePosition.y, targetOrientation * Vector3.right);
        
        if(clampDegrees.y < 360)
            mousePosition.y = Mathf.Clamp(mousePosition.y, -clampDegrees.y * 0.5f, clampDegrees.y * 0.5f);
        
        transform.localRotation *= Quaternion.AngleAxis(mousePosition.x, transform.InverseTransformDirection(Vector3.up));
        
        transform.rotation *= targetOrientation;
    }
}
