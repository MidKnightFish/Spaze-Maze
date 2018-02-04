/*
 *          ### ### 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : LocomotionRigidbody
{
    //var dec
    [SerializeField] private float boostSpeed = 30.0f, speedboostResc = 1f;
    [SerializeField] private float bulletSpeed = 60f, fireRate = 0.4f;
    [SerializeField] private Transform bulletSpawn, bulletRefPoint;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Animator animator;
    [SerializeField] private int LvlKeyAmount, tutKeyAmount = 1;
    
    [Header("SFX")]
    [SerializeField] private AudioSource sfxBoostPickUp;
    [SerializeField] private AudioSource sfxJetpack;
    [SerializeField] private AudioSource sfxKeyPickUp;
    [SerializeField] private AudioSource sfxDeath;
    [SerializeField] private AudioSource sfxHealthLoss;
    [SerializeField] private AudioSource sfxDoor;
    [SerializeField] private AudioSource sfxShoot;

    [Header("Game Objects")]
    [SerializeField] private GameObject TutDoor;
    [SerializeField] private GameObject LvlDoor;
    [SerializeField] private GameObject Key2;
    [SerializeField] private GameObject Key3;
    
    private bool victory, facingRight;
    private int hp = 4, lifes = 3, tutKeyCount = 0, LvlKeyCount = 0;
    private Vector3 joysR, joysRref;
    private CooldownClass fireRateCd;
    private Vector3 CheckpointPos;

    /* private bool HasAKey = false, boostAvailable = true;
     private bool HasAKey1 = false;
     private bool HasAKey2 = false;
     private bool HasAKey3 = false;
     private bool HasAPickUp = false;*/
    private bool isCollidedWithWall = false, isCollidedWithMW = false;


    public delegate void DVoidVoid();
    public delegate void DVoidInt(int val);
    public delegate void DVoidFloat(float val);

    
    public static event DVoidVoid OnPlayerVictory;
    public static event DVoidInt OnPlayerDmg;
    public static event DVoidVoid OnPressStart;
    public static event DVoidVoid OnSpeedboostBarRefresh;
    public static event DVoidFloat SpeedbarDecrease;
    public static event DVoidInt OnHpBarRefresh;
    public static event DVoidInt OnGetKey;
    public static event DVoidInt OnPlayerDeath;

    private ParticleSystem.EmissionModule jetpack;
    private ParticleSystem.EmissionModule smoke;

    //var init
    new private void Start()
    {
        base.Start();

        fireRateCd = new CooldownClass();        
        joysR = new Vector3(0.5f, 0f,0f);
        CheckpointPos = transform.position;
        facingRight = true;
        speedboostResc = 1f;

        ParticleSystem[] particles = this.GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in particles)
        {
            if (ps.gameObject.name == "Jetpack_boost") jetpack = ps.emission;
            if (ps.gameObject.name == "Smoke_boost") smoke = ps.emission;
        }
    }

    //funct def
    private void MsgHandler()
    {
        if (hp <= 0)
        {

            sfxDeath.Play();
            RestartResets(ref lifes);

        }

        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            //JD
            if (OnPressStart != null) OnPressStart();
            else
            {
                Debug.Log("called empty OnPressStart");
                Debug.Break();
            }
            //JD
        }

        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.Space)) && fireRateCd.Available())
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody;
            instantiatedProjectile.velocity = (bulletSpawn.position - bulletRefPoint.position) * bulletSpeed;//(new Vector3(Input.GetAxis("5th Axis"), 0f, Input.GetAxis("4th Axis"))).normalized * bulletSpeed;
            //transform.TransformDirection(new Vector3(0, 0, speed));

            sfxShoot.Play();
            fireRateCd.AddCooldown(fireRate);

        }


    }

    private void Flip(float axis)
    {
        if ((axis > 0 && !facingRight || axis < 0 && facingRight) && axis != 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);

        }


    }

    private void AnimAim()
    {
        joysRref = Vector3.Normalize(new Vector3(Input.GetAxis("4th axis"), 0f, Input.GetAxis("5th axis")));

        if (joysRref.magnitude != 0)
        {

            if (joysRref.z < 0)
            {
                joysR.x = Mathf.Abs(joysRref.z) + 1;

            }
            else if (joysRref.x < 0 && joysRref.z > 0)
            {
                joysR.x = 1 - joysRref.z;

            }

            if (joysRref.z > 0)
            {
                joysR.x = Mathf.Abs(joysRref.z) - 1;

            }
            else if (joysRref.x > 0 && joysRref.z < 0)
            {
                joysR.x = 1 - joysRref.z;

            }

            if (joysRref.z == 0 && (joysRref.x == 1 && joysRref.x == -1))
            {
                joysR.x = 1;

            }

            if (joysRref.z == 1 && joysRref.x == 0)
            {
                joysR.x = 0;

            }
            else if (joysRref.z == -1 && joysRref.x == 0)
            {
                joysR.x = 2;

            }
            animator.SetFloat("aimAnimLerp", Mathf.Abs(joysR.x / 2));

        }


    }

    //####
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagSystemClass.bossDoorTriggerTag))
        {
            LvlDoor.SetActive(true);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.enemyTag) || collision.gameObject.CompareTag(TagSystemClass.enemyBulletTag))
        {
            sfxHealthLoss.Play();
            OnPlayerDmg(hp);
            hp -= 1;

        }
        else if (collision.gameObject.CompareTag(TagSystemClass.speedBoostPickupTag))
        {
            sfxBoostPickUp.Play();
            OnSpeedboostBarRefresh();
            speedboostResc = 1f;

        }
        else if (collision.gameObject.CompareTag(TagSystemClass.medKitTag))
        {
            OnHpBarRefresh(hp);
            hp = 4;

        }
        else if (collision.gameObject.CompareTag(TagSystemClass.lvlKeyTag))
        {
            sfxKeyPickUp.Play();
            LvlKeyCount++;
            CheckpointPos = collision.gameObject.transform.position;
            OnGetKey(tutKeyCount + LvlKeyCount);
            if (LvlKeyCount >= LvlKeyAmount)
            {
                sfxDoor.Play();
                LvlDoor.SetActive(false);
                LvlKeyCount -= LvlKeyAmount;
                OnGetKey(tutKeyCount + LvlKeyCount);
            }

        }
        else if (collision.gameObject.CompareTag(TagSystemClass.tutKeyTag))
        {
            sfxKeyPickUp.Play();
            tutKeyCount++;
            CheckpointPos = collision.gameObject.transform.position;
            OnGetKey(tutKeyCount + LvlKeyCount);
            if (tutKeyCount >= tutKeyAmount)
            {
                sfxDoor.Play();
                TutDoor.SetActive(false);
                tutKeyCount -= tutKeyAmount;
                OnGetKey(tutKeyCount + LvlKeyCount);
            }

        }
    
        /*
        //Keys
        if (collision.gameObject.tag == "PickUp" && HasAPickUp == false)
        {
            HasAPickUp = true;
            sfxKeyPickUp.Play();

        }

        if (collision.gameObject.tag == "Key" && HasAPickUp == false)
        {
            sfxKeyPickUp.Play();
            HasAKey = true;

        }

        if (collision.gameObject.tag == "Key1" && HasAPickUp == false)
        {
            sfxKeyPickUp.Play();
            HasAKey1 = true;

        }

        if (collision.gameObject.tag == "Key2" && HasAPickUp == false)
        {
            sfxKeyPickUp.Play();
            HasAKey2 = true;

        }

        if (collision.gameObject.tag == "Key3" && HasAPickUp == false)
        {
            sfxKeyPickUp.Play();
            HasAKey3 = true;

        }*/

        if (collision.gameObject.CompareTag(TagSystemClass.wallTag))
        {
            isCollidedWithWall = true;

        }
        else if (collision.gameObject.CompareTag(TagSystemClass.dynWallTag))
        {
            isCollidedWithMW = true;

        }

        if (isCollidedWithWall && isCollidedWithMW)
        {
            sfxDeath.Play();
            RestartResets(ref lifes);


        }


    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.wallTag))
        {
            isCollidedWithWall = false;

        }
        else if (collision.gameObject.CompareTag(TagSystemClass.dynWallTag))
        {
            isCollidedWithMW = false;

        }


    }

    private void RestartResets(ref int lifes)
    {
        lifes = lifes - 1;
        OnPlayerDeath(lifes);

        if (lifes > 0)
        {
            transform.position = CheckpointPos;
            rb.velocity = Vector3.zero;

            hp = 4;
            OnHpBarRefresh(4);

            speedboostResc = 1f;
            OnSpeedboostBarRefresh();

        }

    }

    //unity calls
    void Update()
    {
        MsgHandler();
        AnimAim();
        /*
        //Key activation
        if (HasAKey == true)
        {
            //sets door to active /inactive
            Door1.SetActive(false);
            sfxDoor.Play();
            HasAKey = false;

        }

        if (HasAKey1 == true && HasAKey2 == true && HasAKey3 == true)
        {
            //sets door 2 to active /inactive
            Door2.SetActive(false);
            sfxDoor.Play();

            HasAKey1 = false;
            HasAKey2 = false;
            HasAKey3 = false;

            OnPlayerVictory();

        }

    */
    }

    private void FixedUpdate()
    {
        Move();
        Flip(Input.GetAxis("4th axis"));
        
        //speedboost
        if ((Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Q)) && speedboostResc > 0/* && !(speedboostResc <= 0)*/)            //left upper shoulder
        {
            effectiveSpeedCap = boostSpeed;                                             //set current effectiveSpeedCap higher so dash can be performed
            multiplier = boostSpeed;
            SpeedbarDecrease(speedboostResc -= 0.01f);
            jetpack.enabled = true;
            smoke.enabled = true;
            if (sfxJetpack)
            {
                if (!sfxJetpack.isPlaying) sfxJetpack.Play();
                sfxJetpack.loop = true;
            }
        }
        else
        if (speedboostResc <= 0 || Input.GetKeyUp(KeyCode.Joystick1Button4) || Input.GetKeyUp(KeyCode.Joystick1Button4))
        {
            multiplier = 1.0f;
            effectiveSpeedCap = speed;
            jetpack.enabled = false;
            smoke.enabled = false;
            if (sfxJetpack) sfxJetpack.loop = false;
        }


    }
     
     
}
