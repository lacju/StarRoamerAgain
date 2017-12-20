using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterText : MonoBehaviour {

    public Text textBox;
    public float typeSpeed;
    public GameObject warningWindow;
    public GameObject closeTextButton;
    public GameObject replayTextButton;
    public GameObject nextPageButton;
    public GameObject previousPageButton;
    public GameObject skipScrollButton;
    public int secondsBeforeNextText;
    public List<string> textLinesToDisplay = new List<string>();
    


    int currentlyDisplayingText = 0;

    void Awake()
    {
        StartCoroutine(AnimateText());
    }
    public void ResartTypewriter()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateText());
    }

    private void FixedUpdate()
    {
        nextPageButton.SetActive(false);
        previousPageButton.SetActive(false);

        if (currentlyDisplayingText > 0)
        {
            previousPageButton.SetActive(true);
        }
        if (textLinesToDisplay.Count > 1 & currentlyDisplayingText != textLinesToDisplay.Count -1)
        {
            nextPageButton.SetActive(true);
        }
        if (currentlyDisplayingText == textLinesToDisplay.Count)
        {
            nextPageButton.SetActive(false);
        }

    }
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentlyDisplayingText > textLinesToDisplay.Count)
        {
            currentlyDisplayingText = 0;
            
        }
        StartCoroutine(AnimateText());
    }

    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {

        for (int i = 0; i < (textLinesToDisplay[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = textLinesToDisplay[currentlyDisplayingText].Substring(0, i);

            yield return new WaitForSeconds(typeSpeed);
        }

    }

    public void ReplayTextButton()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateText());
    }
    public void OpenWarningWindow()
    {
        
        warningWindow.SetActive(true);
    }
    public void CloseTextWindow()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void SkipScroll()
    {
        StopAllCoroutines();
        textBox.text = textLinesToDisplay[currentlyDisplayingText];
    }
    public void NextPage()
    {
        if (textLinesToDisplay.Count -1 > 1 && currentlyDisplayingText != textLinesToDisplay.Count - 1)
        {
            StopAllCoroutines();
            nextPageButton.SetActive(true);
            SkipToNextText();
        }
        if (currentlyDisplayingText != textLinesToDisplay.Count)
        {
            nextPageButton.SetActive(true);
        }
    }
    public void LastPage()
    {

        
        currentlyDisplayingText = currentlyDisplayingText - 2;
        
      
        SkipToNextText();
    }
}
