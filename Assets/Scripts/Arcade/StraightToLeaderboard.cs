using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightToLeaderboard : MonoBehaviour
{

    MainMenuFun mainMenuFun;
    public GameObject menu;
    public GameObject arcadePanel;
    GetScoreFromDB getTable;
    // Start is called before the first frame update
    void Start()
    {
        getTable = arcadePanel.GetComponent<GetScoreFromDB>();
        mainMenuFun = menu.GetComponent<MainMenuFun>();
        if(PlayerPrefs.GetInt("LoadLeaderboard") == 1)
        {
            mainMenuFun.LoadArcade();
            getTable.ClearLeaderboard();
            getTable.GetLeaderBoard();
            PlayerPrefs.SetInt("LoadLeaderboard", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
