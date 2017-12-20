 using UnityEngine;
 using System.Collections;
 
 public class OrthoSmoothFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;
    public float zOffSet;

    private Vector3 velocity = Vector3.zero;

   

    private void FixedUpdate()
    {

        Vector3 goalPos = target.position;
         goalPos.y = 690;


        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
        
    }
}