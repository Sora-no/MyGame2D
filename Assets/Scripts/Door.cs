using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    private void Update() {
        if(isTrigger && Input.GetKeyDown(KeyCode.E)){
            if(SceneManager.GetActiveScene().name == "Gameplay")
                SceneManager.LoadScene("Shalter");
            else if(SceneManager.GetActiveScene().name == "Shalter")
                SceneManager.LoadScene("Gameplay");
        }
            
    }
    private bool isTrigger = false;
    private void OnTriggerEnter2D(Collider2D other) {
        isTrigger = true;
            
    }
    private void OnTriggerExit2D(Collider2D other) {
        isTrigger = false;
    }
}
