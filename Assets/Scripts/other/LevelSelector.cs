﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;
	
	// Start is called before the first frame update
	void Start()
	{
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);


		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > levelReached)
			{
				levelButtons[i].interactable = false;
				
			}

		}
	}



	public void SelectLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
