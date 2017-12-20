using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStationName : MonoBehaviour {


    public void SetStationName(string sname)
    {
        gameObject.GetComponent<UIWindowTitle>().SetTitle(sname);
        gameObject.GetComponent<UIWindowTitle>().OnValidate();
    }
}
