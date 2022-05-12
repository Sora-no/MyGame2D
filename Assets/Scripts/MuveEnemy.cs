using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuveEnemy : MonoBehaviour
{
    private float speedEnemy = 5;
    private Rigidbody2D rbEnemy;
    private GameObject player;
    private Vector3 forPlayer;
    private SpriteRenderer sr;
    private float hpEnemy = 100;
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        isDead();
        Muvemnet();
    }
    public void isDead(){
        if(hpEnemy <= 0){
            Destroy(gameObject);
            GameManager.score ++;}
            
    }
    public void Muvemnet(){
        if(MuvePlayer.isAlive == false)
            forPlayer = transform.position - player.transform.position;
        else
            forPlayer = player.transform.position - transform.position;
        if(forPlayer.x < 0){
            forPlayer.x = -speedEnemy;
            sr.flipX = false;

        }
        else if(forPlayer.x > 0){
            forPlayer.x = speedEnemy;
            sr.flipX = true;    
        }
        rbEnemy.velocity = forPlayer;
        //Debug.Log(player.transform.position - transform.position);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bullet_pistol")){
            hpEnemy -= 20;
        }
        if(other.gameObject.CompareTag("OverWorld"))
            Destroy(gameObject);

    }
}

