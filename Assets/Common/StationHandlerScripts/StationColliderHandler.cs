using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class StationColliderHandler : MonoBehaviour {

    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;
    public GameObject pressKeyToDock;
    public StationHandler sh;
    // Use this for initialization

    private void Awake()
    {
        rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
    }

    private void OnTriggerStay(Collider other)
    {
        pressKeyToDock.SetActive(true);
        if (rewiredPlayer.GetButtonDown("Dock"))
        {
            Debug.Log("Y ket pressed");
            Time.timeScale = 0;
            sh.enabled = true;

        }
        
    }

    //private void OnTriggerEnter()
    //{
    //    pressKeyToDock.SetActive(true);

    //    if (rewiredPlayer.GetButtonDown("Dock"))
    //    {
    //        Debug.Log("Y ket pressed");
    //       // Time.timeScale = 0;
    //        sh.enabled = true;

    //    }
    //}

    private void OnTriggerExit()
    {
        pressKeyToDock.SetActive(false);
    }
}
