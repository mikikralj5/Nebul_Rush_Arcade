using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionFun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject optionsPanel;
    public GameObject mainMenu;

  
    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
