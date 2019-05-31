using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float moveSpeed;
    public int playerKeys;
    private LevelManager levelManager;

    public static bool canGoToNextLevel;
    public static int keysLeftToCollect;

    public static int playerHealth;

    public float flashTime;
    Color originalColor;
    public MeshRenderer rend;

    public static bool playerStopMoving;

    public AudioSource[] gameSounds;
    AudioSource damageZap;
    AudioSource keyCollect;
    AudioSource doorEnter;
    AudioSource playerDeath;
    bool playDeathSoundOnce;

    void Start()
    {
        playerHealth = 6;
        playerKeys = 0;
        moveSpeed = 8.5f;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        canGoToNextLevel = false;
        keysLeftToCollect = LevelManager.accessKeys;
        
        originalColor = rend.material.color;

        gameSounds = GetComponents<AudioSource>();
        damageZap = gameSounds[0];
        keyCollect = gameSounds[1];
        doorEnter = gameSounds[2];
        playerDeath = gameSounds[3];

        
}

    
    void FixedUpdate()
    {
        if (!playerStopMoving)
        {
            MovePlayerTowardsMouse();
        }
    }


    void Update()
    {
        if (playerHealth <= 0)
        {
            if (playDeathSoundOnce == false)
            {
                playerDeath.Play();
                playDeathSoundOnce = true;
            }
            
            rend.material.color = Color.white;
        }

        SpeedBoost();
        CanGoToNextLevel();

        keysLeftToCollect = (LevelManager.accessKeys) - playerKeys;

    
    }


    void MovePlayerTowardsMouse()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
                
        transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);
    }


    void SpeedBoost()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveSpeed = 14.4f;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveSpeed = 8.5f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "key")
        {
            keyCollect.Play();
            playerKeys++;
         
        }

        if ((col.gameObject.tag == "Door") && (canGoToNextLevel))
        {
            doorEnter.Play();
            playerStopMoving = true;
            levelManager.LoadNextLevel();
        }   


    }


    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.layer == 9))
        {
            damageZap.Play();
            playerHealth -= 1;
            FlashWhite();

            if (col.gameObject.tag == "Instadeath")
            {
                playerStopMoving = true;
                playerHealth = -1;

            }
        }

    }



    void CanGoToNextLevel()
    {
        if (playerKeys == LevelManager.accessKeys)
        {
            canGoToNextLevel = true;

        }
    }


    
    void FlashWhite()
    {
            rend.material.color = Color.white;
            Invoke("ResetColor", flashTime);
        

    }

    void ResetColor()
    {
        rend.material.color = originalColor;
    }

    

}
