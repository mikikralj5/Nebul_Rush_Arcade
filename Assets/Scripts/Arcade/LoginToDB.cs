using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginToDB : MonoBehaviour
{

    public InputField username;
    public InputField password;
    public GameObject menu;
    GetScoreFromDB getScore;
    MainMenuFun mainMenuFun;
    public GameObject wrn;
    public GameObject arcadeFun;
    public GameObject arcadeLogin;

    private void Start()
    {
        getScore = GameObject.FindGameObjectWithTag("ArcadePanel").GetComponent<GetScoreFromDB>();
        mainMenuFun = menu.GetComponent<MainMenuFun>();
    }

    private void Update()
    {
        Validation();
    }
    public void Login()
    {
        var request = new LoginWithPlayFabRequest()
        {
            Username = username.text,
            Password = password.text

        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnSuccess, OnError);


    }


    void OnSuccess(LoginResult result)
    {
        Debug.Log("Succesfful login");
        PlayerPrefs.SetInt("loggedIn", 1);
        getScore.ClearLeaderboard();
        getScore.GetLeaderBoard();
        mainMenuFun.LoadArcade();
        InputEnd();
        wrn.SetActive(false);
        
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("error while loggin in");
        //Debug.Log(error.GenerateErrorReport());
        Debug.Log(error.ErrorMessage);
        wrn.SetActive(true);
    }

    public void LogOut()
    {
        PlayerPrefs.SetInt("loggedIn", 0);
        //mainMenuFun.LoadLoginOnLogout();
        arcadeFun.SetActive(false);
        arcadeLogin.SetActive(true);
    }

    private void InputEnd()
    {
        username.text = "";
        username.placeholder.GetComponent<Text>().text = "Username";
        password.text = "";
        password.placeholder.GetComponent<Text>().text = "Password";
      
    }

    private void Validation()
    {
        if (username.isFocused)
        {
            wrn.SetActive(false);
            username.placeholder.GetComponent<Text>().text = "";
        }
        else
            username.placeholder.GetComponent<Text>().text = "Username";

        if (password.isFocused)
        {
            wrn.SetActive(false);
            password.placeholder.GetComponent<Text>().text = "";
        }
        else
            password.placeholder.GetComponent<Text>().text = "Password";

       
    }

}

   

   


