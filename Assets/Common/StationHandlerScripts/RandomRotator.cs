using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumble;

    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * tumble);
      //  gameObject.transform. (new Vector3(0, -125, -532));
    }
}
