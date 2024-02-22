using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameender : MonoBehaviour
{
   void Start()
    {
        StartCoroutine(CloseGame());
    }

    IEnumerator CloseGame()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Close the game
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
