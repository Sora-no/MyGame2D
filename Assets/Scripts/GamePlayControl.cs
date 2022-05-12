using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayControl : MonoBehaviour
{
    public void Home(){
        SceneManager.LoadScene("MineMenu");
        Debug.Log("Jopa");
    }
    
    
}
