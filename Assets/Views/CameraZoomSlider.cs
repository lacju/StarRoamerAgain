using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoomSlider : MonoBehaviour {

    public Camera camera;
    public Slider slider;

    public void SliderChanged()
    {
        camera.orthographicSize = slider.value;
    }
}
