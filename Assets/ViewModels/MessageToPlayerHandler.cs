using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;

public class MessageToPlayerHandler : MonoBehaviour
{

    public IncomingMessageView imh;
    public GameObject playerMessageWindow;
    public GameObject messageReceivedText;
    private string messageSender, messageSubject, messageContents;
    private List<string> messageContentsList;
    private Sprite messageSenderAvatar;
    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;
    private bool lookForInput = false;

    public void SendPlayerMessage(string sender, string subject, string messagecontents, Sprite senderAvatar)
    {
        messageReceivedText.SetActive(true);
        lookForInput = true;
        messageSender = sender;
        messageSubject = subject;
        messageContents = messagecontents;
        messageSenderAvatar = senderAvatar;
    }
    public void SendPlayerMessage(string sender, string subject, List<string> messageContents, Sprite senderAvatar)
    {
        messageReceivedText.SetActive(true);
        lookForInput = true;
        imh.SetSender(sender);
        imh.SetSubject(subject);
        imh.SetContents(messageContents);
        imh.SetSenderAvatar(senderAvatar);

    }
    public void ActivateMessageWindow()
    {


        playerMessageWindow.SetActive(true);
        imh.SetSender(messageSender);
        imh.SetSubject(messageSubject);
        imh.SetSenderAvatar(messageSenderAvatar);
        if (messageContentsList != null)
        {
            imh.SetContents(messageContentsList);
        }
        else
        {
            imh.SetContents(messageContents);
        }
    }

    private void Awake()
    {
        rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);

    }
    private void Update()
    {
        if (lookForInput)
        {

            if (rewiredPlayer.GetButtonDown("ReadMessage"))
            {
                messageReceivedText.SetActive(false);
                Time.timeScale = 0;
                lookForInput = false;
                ActivateMessageWindow();
                
            }
            
        }

    }

    
}
