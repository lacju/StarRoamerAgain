using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {

	void Update () {
        Material mat = GetComponent<MeshRenderer>().material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = Time.deltaTime;

        mat.mainTextureOffset = offset;
	}
}
