using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTestController : MonoBehaviour
{

    public GameObject Player;
    //variable für die geschwindigkeit des spielers
   // public float Speed;
    //variable für die stärke des boosts des spielers
    public float boost;
    //varaiable für momentanes leben und das leben mit dem der spieler das spiel beginnt
    public int startingHealth = 3;
    public int currentHealth;
    //does a player have a pick up or not ?
    public bool HasAPickUp = false;
    public float timerForPickUp;
    public bool HasAKey = false;
    public bool HasAKey1 = false;
    public bool HasAKey2 = false;
    public bool HasAKey3 = false;
    private bool facingRight;
    private bool isCollidedWithWall = false;
    private bool isCollidedWithMW = false;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    //public GameObject gameOver;
    //public GameObject Win;
    public GameObject Health4;
    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject PickUpTimer4;
    public GameObject PickUpTimer3;
    public GameObject PickUpTimer2;
    public GameObject PickUpTimer1;
    //public AudioSource sfxSourceWin;
    public AudioSource sfxKeyPickUp;
    public AudioSource sfxDeath;
    public AudioSource sfxHealthLoss;
    public AudioSource sfxDoor;

    // public float speed;

    //private Rigidbody rb;


    void start()
    {
        //setzt das momentane leben auf den wert des start lebens wenn der spieler gespawnd wird
        currentHealth = startingHealth;
        // rb = GetComponent<Rigidbody>();
        facingRight = true;
    }



    void FixedUpdate()
    {
        //makes the player move with wasd pfeiltasten oder steuerknüppel auf xbox contoller

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
         
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // rb.AddForce(movement * speed);
        Flip(moveHorizontal);
        //PickUp Use
        if (HasAPickUp == true)
        {

            //boostet den spieler nach forne wenn rechte schultertaste gedrückt wird wenn ein pick up aufgenomme wurde
            if (Input.GetKey(KeyCode.JoystickButton5))
            {
                Player.GetComponent<Rigidbody>().velocity = movement * boost;
            
                timerForPickUp += 1.0F * Time.deltaTime;

                if (timerForPickUp >= 4)
                {
                    HasAPickUp = false;
                }

            }

        }
        //Key aktivation
        if (HasAKey == true)
        {
            //sets door to aktive /inaktive

           Door1.SetActive(false);
            sfxDoor.Play();
            HasAKey = false;
        }
        if (HasAKey1 == true && HasAKey2 == true && HasAKey3 == true)
        {
            //sets door 2 to aktive /inaktive
            Door2.SetActive(false);
            sfxDoor.Play();
            HasAKey1 = false;
            HasAKey2 = false;
            HasAKey3 = false;
        }

    }

    //destroys player charakter on collision with everything that is tagged EnemyBullet or enemy
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy")
        {
            currentHealth = currentHealth - 1;
            sfxHealthLoss.Play();
        }
        //destroys player if 2 objekts with wall and WM hit him at the same time 
        if (collision.gameObject.tag == "Wall") {
            isCollidedWithWall = true;
        }
        else if (collision.gameObject.tag == "MW"){
            isCollidedWithMW = true;
        }
        
        if (isCollidedWithWall && isCollidedWithMW) {
            sfxDeath.Play();
            Destroy(gameObject);

            Application.LoadLevel(Application.loadedLevel);
        }
    
        if (currentHealth <= 0)
        {
            //aktiviert das gane over panel und zerstört dén spieler 
            //gameOverPanel.SetActive(true);
            //gameObject.SetActive(false);
            // Destroy(gameObject);
            //Application.LoadLevel(Application.loadedLevel);
        }
//PickUp detektion
        if (collision.gameObject.tag == "PickUp" && HasAPickUp == false)
        {

            HasAPickUp = true;
            sfxKeyPickUp.Play();
        }
        if (collision.gameObject.tag == "Key" && HasAPickUp == false)
        {

            HasAKey = true;
            sfxKeyPickUp.Play();
        }
        if (collision.gameObject.tag == "Key1" && HasAPickUp == false)
        {

            HasAKey1 = true;
            sfxKeyPickUp.Play();
        }
        if (collision.gameObject.tag == "Key2" && HasAPickUp == false)
        {

            HasAKey2 = true;
            sfxKeyPickUp.Play();
        }
        if (collision.gameObject.tag == "Key3" && HasAPickUp == false)
        {
            sfxKeyPickUp.Play();
            HasAKey3 = true;
            sfxKeyPickUp.Play();
        }
}
    public void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.tag == "Wall")
        isCollidedWithWall = false;
    else if (collision.gameObject.tag == "MW")
        isCollidedWithMW = false;
}
private void Flip(float moveHorizontal)
    {
        if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
    }

}
    
//Ignoriert den collider vom camerapoint um glitche zu vermeiden 
        // if (collision.gameObject.tag == "CameraPoint")
        //{
          //Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
        //}
    


