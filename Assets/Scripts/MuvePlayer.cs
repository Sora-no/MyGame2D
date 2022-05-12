using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuvePlayer : MonoBehaviour
{
    private static int hp;
    public static int HP{ get{ return hp;} set{ hp = value;}}
    public Vector3 speed;
    private float overWorld = 95;
    private float playerSpeed = 10;
    private float playerJump = 9;
    private float inputHorizontal;
    private float jump;
    [SerializeField]
    private bool isGraund;
    private string GRAUND_TAG = "Graund";
    private Rigidbody2D rb;
    private Animator animatorPlayer;
    private SpriteRenderer sr;
    private GameObject goGun;
    private GameObject deadText;
    [SerializeField]
    private VectorValue startPos;
    public static bool isAlive;

    void Start()
    {
        transform.position = startPos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        goGun = GameObject.Find("Gun");
        deadText = GameObject.Find("Dead");
        hp = 100;
        isAlive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity;
        //Wolk();
        AnimatePlayer();
        OverWorld();  
        IsDead();
        isDeadText();
    }
    private void FixedUpdate() {
        Jump();
        Wolk();
    }
    public void Wolk(){
        inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * inputHorizontal * playerSpeed * Time.deltaTime);
        
    }
    public void Jump(){
        if(SceneManager.GetActiveScene().name == "Gameplay") {jump = Input.GetAxis("Jump");}
        if(isGraund)
            rb.AddForce(transform.up * jump * playerJump, ForceMode2D.Impulse);
        if(speed.y >= 10)
            rb.velocity = new Vector3(0, 7, 0);
    }
    public void OverWorld(){
        if(transform.position.x >= overWorld)
            transform.position = new Vector3(overWorld, transform.position.y, 0);
        else if(transform.position.x <= -overWorld)
            transform.position = new Vector3(-overWorld, transform.position.y, 0);
    }
    public void AnimatePlayer(){
        if(inputHorizontal > 0 && isGraund){
            animatorPlayer.SetBool("Wolk", true);
            sr.flipX = true;
            goGun.transform.localPosition = new Vector3(1, 0, 0);
        }
        else if(inputHorizontal < 0 && isGraund){
            animatorPlayer.SetBool("Wolk", true);
            sr.flipX = false;
            goGun.transform.localPosition = new Vector3(-1, 0, 0);
        }
        else if(inputHorizontal == 0 || !isGraund){
            animatorPlayer.SetBool("Wolk", false);
        }
        if(jump > 0 && SceneManager.GetActiveScene().name == "Gameplay")
            animatorPlayer.SetBool("Jump", true);
        else
            animatorPlayer.SetBool("Jump", false);
            
    }
    public void IsDead(){
        if(hp == 0){
            gameObject.SetActive(false);
            isAlive = false;

        }
    }
    public void isDeadText(){
        if(!MuvePlayer.isAlive && SceneManager.GetActiveScene().name == "Gameplay")
            deadText.SetActive(true);
        else if(MuvePlayer.isAlive && SceneManager.GetActiveScene().name == "Gameplay")
            deadText.SetActive(false);
            
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(GRAUND_TAG))
            isGraund = true; 
        if(other.gameObject.CompareTag("Enemy"))
            hp -= 20;
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag(GRAUND_TAG))
            isGraund = false;
    }
}
