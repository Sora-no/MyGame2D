using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMuve : MonoBehaviour
{
    private GameObject player;
    private float rOverCam;
    private float lOverCam; 
    private float playerPosX;
    private float playerPosY;
    private void Start() {
        player = GameObject.Find("Player");
    }
    void LateUpdate()
    {
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;
        OverWorld();
        GamePlayCam();
        
        
    }
    public void GamePlayCam(){
        

        transform.position = new Vector3(playerPosX, playerPosY, transform.position.z);
        if(transform.position.x >= rOverCam)
            transform.position = new Vector3(rOverCam, playerPosY, transform.position.z);
        else if(transform.position.x <= lOverCam)
            transform.position = new Vector3(lOverCam, playerPosY, transform.position.z);
        
    }
    public void OverWorld(){
        if(SceneManager.GetActiveScene().name == "Shalter"){lOverCam = -1; rOverCam = 35; if(playerPosY <= 0){playerPosY += 2.98f;}}
        else if(SceneManager.GetActiveScene().name == "Gameplay"){lOverCam = -87; rOverCam = 87; if(playerPosY <= 0){playerPosY = 0;}}
            
        
    }

}
