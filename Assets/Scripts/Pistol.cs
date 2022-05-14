using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    new int maxBulletsInMag = 6;
    public override void Reload(){
        if(Input.GetKeyDown(KeyCode.R) && bullets != 0 && bulletsInPack > 0){
            bulletsInPack -= maxBulletsInMag - bullets;
            bullets += maxBulletsInMag - bullets;
            
        }
        else if(Input.GetKeyDown(KeyCode.R) && bullets == 0 && bulletsInPack > 0){
            bulletsInPack -= maxBulletsInMag;
            bullets +=maxBulletsInMag;
            
        }
        else if(Input.GetKeyDown(KeyCode.R) && bulletsInPack <= maxBulletsInMag && bullets == 0){
            bulletsInPack -= bulletsInPack;
            bullets += bulletsInPack;
            
        }
        else if(Input.GetKeyDown(KeyCode.R) && bulletsInPack == 0 && bullets == 0){
            Debug.Log("No ammo");
        }

    }
}
