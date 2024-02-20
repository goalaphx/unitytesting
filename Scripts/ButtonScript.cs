using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
   public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void RestartGame()
    {
        // Load the first scene where the game starts
        PlayerController.Life = 3;
        SceneManager.LoadScene("SampleScene");
    }
}
