using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("MainGame"); 
    }

    public void StartMenu() {
        Debug.Log("CLICKED!");
        SceneManager.LoadScene("MainMenu"); 
    }

    public void Tutorial() {
        SceneManager.LoadScene("Tutorial"); 
    }
}
