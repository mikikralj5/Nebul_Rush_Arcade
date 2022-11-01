using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    private PlayerController playerController;
    public GameObject inventoryImage;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            for (int i = 0; i < playerController.slots.Length; i++)
            {
                if (playerController.isFull[i] == false)
                {
                    playerController.isFull[i] = true;
                    FindObjectOfType<SoundEffectManager>().PlaySound("MouseClick");
                    Instantiate(inventoryImage, playerController.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
