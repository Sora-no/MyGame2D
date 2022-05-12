using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public float speed;
    private float buletSpeed = 55;
    private SpriteRenderer srGun;
    private Rigidbody2D rb;
    public bool inGun = true;
    private void Start() {
       srGun = GameObject.Find("Gun").GetComponent<SpriteRenderer>();
       rb = GetComponent<Rigidbody2D>();
   }
    void Update(){  
         
        FlyBulet();
        speed = rb.velocity.magnitude;
    }
    public void FlyBulet(){
        if(srGun.flipX == false && inGun)
            rb.velocity = new Vector3(buletSpeed, 0, 0);
        else if(srGun.flipX == true && inGun)
            rb.velocity = new Vector3(-buletSpeed, 0, 0);  
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Weapon"))
            inGun = false;
    }
}
