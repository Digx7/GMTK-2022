using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Vector3 rot;

    // Update is called once per frame
    void Update()
    {
      Vector3 input = rot * Time.deltaTime;

      transform.Rotate (input); //rotates 50 degrees per second around z axis
    }
}
