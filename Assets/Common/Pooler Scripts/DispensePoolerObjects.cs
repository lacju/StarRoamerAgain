using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensePoolerObjects : MonoBehaviour {


	void Start ()
    {

        for (int i = 0; i < ObjectPooler.current.pooledAmount; i++)
        {
            ObjectPooler.current.GetPooledObject();
        }
	}

    void Update()
    {

    }
	

}
