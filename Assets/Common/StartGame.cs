using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {



    public void startGame()
    {
        print("Starting game");

        DontDestroyOnLoad(GameManager.Instance);
        SceneManager.LoadScene("NewGame");
    }
}
