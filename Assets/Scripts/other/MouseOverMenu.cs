using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Texture newPic;
    private Texture oldPic;
    public RawImage nextPic;


   
    
    // Start is called before the first frame update
    void Start()
    {
        oldPic = nextPic.texture;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        nextPic.texture = newPic;
        FindObjectOfType<SoundEffectManager>().PlaySound("MouseOver");
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        nextPic.texture = oldPic;
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        nextPic.texture = oldPic;
        FindObjectOfType<SoundEffectManager>().PlaySound("MouseClick");
    }
}
