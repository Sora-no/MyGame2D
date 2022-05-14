using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    static protected int bullets = 0;
    static public int Bullets{get{return bullets;}}
    protected int maxBulletsInMag;
    static protected int bulletsInPack = 0;
    static public int BulletsInPack{get{return bulletsInPack;}}
    protected Vector3 posSpawnBulet;
    protected bool inTriggerAmmoShop;
    //private Vector3 gunPos;
    [SerializeField]
    protected GameObject[] bullet;
    protected SpriteRenderer sr;
    protected AudioSource gunBoom;
    
    void Start(){
        sr = GetComponent<SpriteRenderer>();
        gunBoom = GetComponent<AudioSource>();
    }

    void Update(){
        posSpawnBulet = transform.position + new Vector3(0, 0.12f, 0);
        Fire();
        PosGun();
        Reload();
        ReloadInPack();
        
    }

    public void Fire(){
        if(Input.GetKeyDown(KeyCode.Q) && bullets != 0){
            bullets --;
            Instantiate(bullet[0], posSpawnBulet, bullet[0].transform.rotation);
            gunBoom.PlayOneShot(gunBoom.clip);
        }
    }
    public void PosGun(){
        if(transform.localPosition.x == 1){
            sr.flipX = false;
            
        }
        else if(transform.localPosition.x == -1){
            sr.flipX = true;
        }
    }
    // public void Magazin(){
    //     if(bullets == 0 && bulletsInPack != 0){
    //         bullets += 6;
    //         bulletsInPack -= 6;
    //     }
    //     else if(bullets < 6)

    // }
    public void ReloadInPack(){
        if(inTriggerAmmoShop && bulletsInPack < 300 && Input.GetKeyDown(KeyCode.E))
            bulletsInPack = 100;
    }
    public virtual void Reload(){
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
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "AmmoShop")
            inTriggerAmmoShop = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "AmmoShop")
            inTriggerAmmoShop = false;
    }
}
