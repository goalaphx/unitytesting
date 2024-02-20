using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallScript : MonoBehaviour
{
    [SerializeField]private AudioSource fallsound;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            fallsound.Play();
            PlayerController.Life -= 1;
            if(PlayerController.Life == 0){
                SceneManager.LoadScene("GameOver");
            }
            else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
        }
    }
    
}
