using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public int requiredKeys;
    public static int accessKeys;
    public int requiredKeys;
    public bool canBeRestarted;

    public GameObject DeathFX;
    public Transform player;
    bool fxAlreadyPlayed;

    public Animator anim;
    Scene m_Scene;
    string sceneName;

    public AudioSource[] bgMusic;
    public AudioSource menu2ndStage;
    public AudioSource firstStage;


    void Start()
    {
        PlayerController.playerHealth = 6;
        accessKeys = requiredKeys;
        PlayerController.playerStopMoving = true;
        StartCoroutine(PlayerStopMovingAtStart());
        PlayerController.moveSpeed = 8.5f;
        Time.timeScale = 1;

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        bgMusic = GetComponents<AudioSource>();
        menu2ndStage = bgMusic[0];
        firstStage = bgMusic[1];

        PlayBGMusic();
    }

    
    void Update()
    {

        //level skip cheat - added 4/24
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if ((PlayerController.playerHealth <= 0) && (fxAlreadyPlayed == false))
        {
            StartCoroutine(PlayDeathFX());
            canBeRestarted = true;
        }

        if (canBeRestarted)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");
            }
        }


    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayDeathFX()
    {
        PlayerController.moveSpeed = 0.0f;
        fxAlreadyPlayed = true;                
        Instantiate(DeathFX, player.transform.position, player.transform.rotation);
        PlayerController.moveSpeed = 0.0f;
        yield return new WaitForSeconds(0.6f);
        Time.timeScale = 0;
        
    }

    IEnumerator LoadScene()
    {
        if (sceneName == "Menu")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else 
        {
            anim.SetTrigger("end");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator PlayerStopMovingAtStart()
    {
        
        yield return new WaitForSeconds(6.0f);
        PlayerController.playerStopMoving = false;
    }

    void PlayBGMusic()
    {
        if (m_Scene.name == "Menu" || m_Scene.name == "Level4" || m_Scene.name == "Level5" || m_Scene.name == "Level6")
        {
            menu2ndStage.Play();
        }

        else if (m_Scene.name == "Level0" || m_Scene.name == "Level1" || m_Scene.name == "Level2" || m_Scene.name == "Level3")
        {
            firstStage.Play();
        }
    }
}
