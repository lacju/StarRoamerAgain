using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBoundary : MonoBehaviour {

    public GameObject playerObject;

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Game object collided with: " + collision.gameObject);
        Debug.Log("Game object collided with to string: " + collision.gameObject.ToString());
        if (collision.gameObject == playerObject) 
        {
            Debug.Log(collision.gameObject);
            SendMessageUpwards("MoveCameraUp");
        }
    }
}
