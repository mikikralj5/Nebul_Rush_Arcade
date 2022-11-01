using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeBackToLeaderboar : MonoBehaviour
{

    public void BackToLeaderboard()
    {
        PlayerPrefs.SetInt("LoadLeaderboard", 1);
        FindObjectOfType<GameManager>().LoadMenu();
    }

  

  
}
