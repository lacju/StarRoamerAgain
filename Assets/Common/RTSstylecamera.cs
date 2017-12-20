using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSstylecamera : MonoBehaviour {

    

    public int Boundary = 50;
    public int speed = 5;
    public GameObject playerObject;
    public Collider topBoundry;
    public Collider bottomBoundry;
    public Collider leftBoundry;
    public Collider rightBoundry;

    new Camera camera;

    private int theScreenWidth;
    private int theScreenHeight;

    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
       
    }
  




    void Update()
    {
        Vector3 playerObjectPosition = camera.WorldToScreenPoint(playerObject.transform.position);
        if (playerObjectPosition.x > theScreenWidth - Boundary)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (playerObjectPosition.x < 0 + Boundary)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //transform.position.x -= speed * Time.deltaTime;

        }

        if (playerObjectPosition.y > theScreenHeight - Boundary)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            //  transform.position.y += speed * Time.deltaTime;
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }

        //  if (Collision.)
        {
            //  transform.position.y -= speed * Time.deltaTime;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

    }

    void OnGUI()
    {
        GUI.Box(new Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
        GUI.Box(new Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
        GUI.Box(new Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
    }
}