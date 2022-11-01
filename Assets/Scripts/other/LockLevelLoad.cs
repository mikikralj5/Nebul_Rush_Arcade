using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevelLoad : MonoBehaviour
{

    public Texture[] imageLevels;
    public RawImage contPic;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        contPic.texture = imageLevels[levelReached];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
