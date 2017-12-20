using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomingMessageView : MonoBehaviour
{

    public Text messageSender;
    public Text messageSubject;
    public Image messageSenderAvatar;
    public TypewriterText messageContentsBox;
    public List<string> messageContents = new List<string>();

    public void SetSenderAvatar(Sprite senderAvataer)
    {
        messageSenderAvatar.sprite = senderAvataer;
    }
    public void SetSender(string sender)
    {
        Debug.Log(sender);
        Debug.Log(messageSender);
        messageSender.text = sender;
    }
    public void SetSubject(string subject)
    {
        messageSubject.text = subject;
    }
    public void SetContents(List<string> contents)
    {
        messageContents = contents;
        messageContentsBox.textLinesToDisplay = contents;
        messageContentsBox.ResartTypewriter();
    }
    public void SetContents(string contents)
    {
        messageContents.Add(contents);
        messageContentsBox.textLinesToDisplay = messageContents;
        messageContentsBox.ResartTypewriter();
    }
    public void ToggleMessageboxOnOff()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
