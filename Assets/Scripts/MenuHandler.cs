using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single); 
    }

    public void Tutorial() {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single); 
    }
}
