using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lvl;
    public static bool isPaused = false;
    public GameObject pauseMenu;
    private AudioSource backgroundMusic;
    public Scene scen;
    public int levelToUnlock = 1;
    PlayerController playerController;
    UpdateScoreToDB updateScoreToDB;


    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        updateScoreToDB = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UpdateScoreToDB>();
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            //backgroundMusic = Camera.main.GetComponent<AudioSource>();  VRATI OVO
            
            if(isPaused)
            {
               
                Resume();
               //backgroundMusic.enabled = true;
            }
            else
            {
                //backgroundMusic.enabled = false;
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

   public void Quitt()
    {
        PlayerPrefs.SetInt("loggedIn", 0);
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }

    public void LevelComplete()
    {
        lvl.SetActive(true);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
    public void EndGame()
    {
        if(SceneManager.GetActiveScene().name == "Arcade")
        {
            updateScoreToDB.SendLeaderboard((int)(playerController.transform.position.z));
            
            Invoke("RestartArcade", 0.50f);
        }
        else
        {
            Invoke("Restart", 1f);
        }
       
    }    
    
    void Restart()
    {
        
        SceneManager.LoadScene("Level1");
    }

    void RestartArcade()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //SceneManager.LoadScene("Arcade");
    }

   public  void PlayAgainArcade()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Arcade");
        Time.timeScale = 1f;
    }


}
