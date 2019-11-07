using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
    public float verticalSpeed;
    public Transform target;
    public Transform target_2;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    float mouseX, mouseY;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool input = Input.GetMouseButton(1);
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * verticalSpeed;

        if (input)
        {
            /*Quaternion camTurn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up * -1);
            Quaternion camUpdown = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * verticalSpeed, Vector3.forward * -1);
            cameraoffset = camUpdown * camTurn * cameraoffset;
            Vector3 newpos = target_2.position + cameraoffset;

            target_2.transform.position = Vector3.Slerp(transform.position, newpos, 1);
            Cursor.visible = false;
            transform.LookAt(target);*/

            /*mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * verticalSpeed;*/
            mouseY = Mathf.Clamp(mouseY, -35, 0);
            target_2.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }

        else
        {
            target_2.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        /*else
        { 
            target_2.rotation = Quaternion.Euler(0, mouseX, 0);
            Quaternion camTurn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            Quaternion camUpdown = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * verticalSpeed, Vector3.forward * -1);

            cameraoffset = camUpdown * camTurn * cameraoffset;
            Vector3 newpos = target.position + cameraoffset;
            target_2.rotation = Quaternion.Euler(0, mouseX, 0);
            transform.position = Vector3.Slerp(transform.position, newpos, 1);
            Cursor.visible = false;
            transform.LookAt(target);
        }*/
    }
}
