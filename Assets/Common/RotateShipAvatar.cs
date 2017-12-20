// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Rotates the ship model within the Ship Selection mentu UI. 
// ===============================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShipAvatar : MonoBehaviour {

    public float rotationForwardSpeed;
    public float rotationRightSpeed;

    private void Update()
    {

        transform.Rotate(Vector3.forward * (rotationForwardSpeed * Time.deltaTime));
        transform.Rotate(Vector3.right * (rotationRightSpeed * Time.deltaTime));


    }
}
