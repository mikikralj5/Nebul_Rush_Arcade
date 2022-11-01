using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapulPickup : MonoBehaviour
{

   
    Rigidbody playerRb;
    private float upForce = 700f;
  
    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    

    public void CatapulFun()
    {
        
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * Time.deltaTime * upForce, ForceMode.Impulse);
             
    }
}
