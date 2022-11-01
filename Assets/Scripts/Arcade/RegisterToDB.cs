using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class RegisterToDB : MonoBehaviour
{
    public InputField email;
    public InputField username;
    public InputField password;
    public GameObject menu;
    public GameObject wrn;
    MainMenuFun mainMenuFun;


    private void Start()
    {
        mainMenuFun = menu.GetComponent<MainMenuFun>();
    }

    private void Update()
    { 
        Validation();        
    }
    public void Register()
    {
        var req = new RegisterPlayFabUserRequest
        {

            Email = email.text,
            Password = password.text,
            Username = username.text,
            DisplayName = username.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(req, OnSucces, OnError);
    }

    

    void OnSucces(RegisterPlayFabUserResult result)
    {
        Debug.Log("Succesffuly registered");
        mainMenuFun.ArcadeRegisterBack();
        InputEnd();
        wrn.SetActive(false);
    }


    void OnError(PlayFabError error)
    {
        Debug.Log("error while loggin in");
       // Debug.Log(error.GenerateErrorReport());
        Debug.Log(error.ErrorMessage);
        wrn.SetActive(true);
        
        
    }

    private void InputEnd()
    {
        email.text = "";
        email.placeholder.GetComponent<Text>().text = "Email";
        username.text = "";
        username.placeholder.GetComponent<Text>().text = "Username";
        password.text = "";
        password.placeholder.GetComponent<Text>().text = "Password";
    }

    private void Validation()
    {
        if (email.isFocused)
        {
            wrn.SetActive(false);
            email.placeholder.GetComponent<Text>().text = "";
        }
        else
        {
            email.placeholder.GetComponent<Text>().text = "Email";
        }

        if(password.isFocused)
        {
            wrn.SetActive(false);
            password.placeholder.GetComponent<Text>().text = "";
        }
        else
            password.placeholder.GetComponent<Text>().text = "Password";

        if(username.isFocused)
        {
            wrn.SetActive(false);
            username.placeholder.GetComponent<Text>().text = "";
        }
        else
            username.placeholder.GetComponent<Text>().text = "Username";
    }
}
