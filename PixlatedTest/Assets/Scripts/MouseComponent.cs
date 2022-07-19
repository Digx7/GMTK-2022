using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.EventSystems;

 public class MouseComponent : MonoBehaviour
 {
     public float MouseSensitivity = 500f;

     public Transform PlayerBody;

     float Xrotation = 0f;
     float Yrotation = 0f;

     //Start is called before the first frame update
     void Start()
     {
         Cursor.lockState = CursorLockMode.Locked;
     }

     // Update is called once per frame
     public void Update()
     {
         float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
         float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

         Xrotation -= MouseY;
         Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

         //Yrotation -= MouseX;
         //Yrotation = Mathf.Clamp(Xrotation, -90f, 90f);

         transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);

         PlayerBody.Rotate(Vector3.up * MouseX);
     }
 }
