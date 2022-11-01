using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastPickup : MonoBehaviour
{

    GameObject player;
    float radius = 15f;
    public ParticleSystem destroyEffect;
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

  
    public void BlastFunc()
    {
        Collider[] objectsToDestory = Physics.OverlapSphere(player.transform.position, radius);
        foreach (var item in objectsToDestory)
        {
            if(item.CompareTag("Obstacle"))
            {
                Destroy(item.gameObject);
                Instantiate(destroyEffect, item.transform.position, item.transform.rotation);
                
            }
                
        }

    }

}
