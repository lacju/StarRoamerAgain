// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Script executes when first loading into the Sol scene to prepare events and objects. 
// ===============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolFirstLoadHandler : MonoBehaviour {

    private MessageToPlayerHandler mtp;
    private PlayerObject _POC;
    private Camera mainCamera;

    private void Awake()
    {
        mtp = FindObjectOfType<MessageToPlayerHandler>();
        _POC = FindObjectOfType<PlayerObject>();
        mainCamera = FindObjectOfType<Camera>();
    }

    
    private void Start()
    {
        mainCamera.transform.position = _POC.transform.position;
        mtp.SendPlayerMessage(GameManager.Instance.initialMessageSender, GameManager.Instance.initialMessageSubject, 
            GameManager.Instance.initialMessageContent, GameManager.Instance.initialMessageSenderAvatar);
        
    }
}
