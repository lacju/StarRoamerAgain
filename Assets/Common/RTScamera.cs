using UnityEngine;
using System.Collections;
public class RTScamera : MonoBehaviour
{
    public int scrollDistance = 5;
    public float scrollSpeed = 70;
    public GameObject playerObject;

    private void Awake()
    {
        playerObject = GameObject.Find("PlayerObject");

    }

    void Update()
    {

        // float mousePosX = Input.mousePosition.x;
        // float mousePosY = Input.mousePosition.y;

        float mousePosX = playerObject.transform.localPosition.x;
        float mousePosY = playerObject.transform.localPosition.z;

        if (mousePosX < scrollDistance)
        {
            transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
        }

        if (mousePosX >= Screen.width - scrollDistance)
        {
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        }

        if (mousePosY < scrollDistance)
        {
            transform.Translate(transform.forward * -scrollSpeed * Time.deltaTime);
        }

        if (mousePosY >= Screen.height - scrollDistance)
        {
            transform.Translate(transform.forward * scrollSpeed * Time.deltaTime);
        }
    }
}