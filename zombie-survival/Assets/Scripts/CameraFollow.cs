using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
     public Transform player;
     public float smoothing = 2.75f;
 
     private Vector3 offset;
    private Vector3 direction;

     void Start () {
         offset = new Vector3(0, -2f, 2f);
         direction = offset.normalized;
     }
 
     void LateUpdate()
     {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = player.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * smoothing);

        Quaternion rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);
        transform.position = player.position - (rotation * offset);
        transform.rotation = rotation;
      
    }
}

