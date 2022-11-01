using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class GetScoreFromDB : MonoBehaviour
{

    public GameObject rowPrefab;
    public Transform rowsParent;

 


    void OnError(PlayFabError error)
    {
        Debug.Log("error while loggin in");
        Debug.Log(error.GenerateErrorReport());
    }


    public void GetLeaderBoard()
    {

        

        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 5
        };

        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

   
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position+1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    public void ClearLeaderboard()
    {
        
        foreach(Transform child in rowsParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
