using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject optionsPanel;
    public GameObject mainMenu;
    public GameObject mainMenuText;
    public GameObject continueText;
    public GameObject continueLevels;
    public GameObject btnMain;
    public GameObject btnCont;
    public GameObject bntLvl;
    public GameObject arcadeFun;
    public GameObject arcadeLogin;
    public GameObject arcadeRegister;
    public GameObject arcadePanel;
    private GetScoreFromDB getScoreFromDB;
    public Button contbtn;
    public RawImage contNewImage;
    public Texture newPic;
    public Texture newContPic;


    private void Start()
    {
        getScoreFromDB = arcadePanel.GetComponent<GetScoreFromDB>();
    }
    public void Exitt()
    {
        
        PlayerPrefs.SetInt("loggedIn", 0);
        Application.Quit();
        
      
    }

    public void OptionsMenu()
    {
        optionsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }   
    

    public void startStory()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.DeleteAll();
    }

   

    public void ContinueGame()
    {
        mainMenuText.SetActive(false);
        btnMain.SetActive(false);
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
        if(levelReached == 0)
        {
            contbtn.interactable = false;
            contNewImage.texture = newPic;
        }
        else
        {
            contbtn.interactable = true;
            contNewImage.texture = newContPic;
        }
        continueText.SetActive(true);
        btnCont.SetActive(true);
    }

    public void LoadLevels()
    {
        continueText.SetActive(false);
        btnCont.SetActive(false);
        continueLevels.SetActive(true);
        bntLvl.SetActive(true);
    }

    public void BackMain()
    {
        mainMenuText.SetActive(true);
        btnMain.SetActive(true);
        continueText.SetActive(false);
        btnCont.SetActive(false);
        
    }

    public void BackContNew()
    {
        continueText.SetActive(true);
        btnCont.SetActive(true);
        continueLevels.SetActive(false);
        bntLvl.SetActive(false);
    }

    public void LoadArcadeLogin()
    {
        if(PlayerPrefs.GetInt("loggedIn") != 1)
        {
            mainMenu.SetActive(false);
            arcadeLogin.SetActive(true);
        }
        else
        {
            getScoreFromDB.ClearLeaderboard();
            getScoreFromDB.GetLeaderBoard();
            LoadArcade();
        }

        
    }

    public void LoadArcadeRegister()
    {
        arcadeLogin.SetActive(false);
        arcadeRegister.SetActive(true);
    }
    public void ArcadeRegisterBack()
    {
        arcadeLogin.SetActive(true);
        arcadeRegister.SetActive(false);
    }

    public void LoadArcade() //na leaderboard i start arcade ide
    {
        //SceneManager.LoadScene("Arcade");
        mainMenu.SetActive(false);
        arcadeLogin.SetActive(false);
        arcadeFun.SetActive(true);
    }

    /*
    public void LoadLoginOnLogout()
    {
        arcadeFun.SetActive(false);
        arcadeLogin.SetActive(true);
    }
    */

    public void ArcadeBack()
    {
        mainMenu.SetActive(true);
        arcadeLogin.SetActive(false);
    }

    public void ArcadeFunBack()
    {
        arcadeFun.SetActive(false);
        mainMenu.SetActive(true);
        
    }

    public void StartArcadde()
    {
        SceneManager.LoadScene("Arcade");
    }
}
