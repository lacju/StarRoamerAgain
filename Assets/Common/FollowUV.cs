using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour {
   public float parralax;

    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;

        Vector2 offset = mat.mainTextureOffset;

       offset.x = (transform.position.y / transform.localScale.y / parralax) ;
        offset.y = (transform.position.z / transform.localScale.z / parralax) ;

        mat.mainTextureOffset = offset;
    }
}
