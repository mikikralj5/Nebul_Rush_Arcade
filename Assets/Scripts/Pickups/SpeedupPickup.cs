using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupPickup : MonoBehaviour
{

    private float oldSpeed;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void SpeedUpFunc()
    {
        oldSpeed = playerController.speed;
        playerController.speed *= 2;
        StartCoroutine(SpeedupCountDown());
    }

    IEnumerator SpeedupCountDown()
    {
        yield return new WaitForSeconds(1);
        playerController.speed = oldSpeed;
    }
}
