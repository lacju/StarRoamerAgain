using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldController : MonoBehaviour {

    public PlayerObject _POC;
    public int distanceFromPlayer;
    private void FixedUpdate()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, _POC.transform.localPosition.z + distanceFromPlayer);
    }
}
