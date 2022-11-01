using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMode : MonoBehaviour
{

    public GameObject player;
    public GameObject obstacle;
    public GameObject ground;
    float infHelp = 290;
    
   
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        
        InvokeRepeating("Spawner", 1, 1);
        InvokeRepeating("GameProgress", 5, 1);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > infHelp)
        {
            float newLength = player.transform.position.z * 2 + 600;
            ground.transform.localScale = new Vector3(25, 1, newLength);
            infHelp += 300;
        }
        

    }
    private List<Vector3> GeneratePosition()
    {
        List<Vector3> positions = new List<Vector3>();

        float spawnPosX1 = Random.Range(-9, -3);
        float spawnPosZ1 = Random.Range(player.transform.position.z+100, player.transform.position.z + 120);

        float spawnPosX2 = Random.Range(-3, 3);
        float spawnPosZ2 = Random.Range(player.transform.position.z + 100, player.transform.position.z + 120);

        float spawnPosX3 = Random.Range(3, 9);
        float spawnPosZ3 = Random.Range(player.transform.position.z + 100, player.transform.position.z + 120);

        //Vector3 retVect = new Vector3(spawnPosX, 0, spawnPosZ);

        positions.Add(new Vector3(spawnPosX1, 0, spawnPosZ1));
        positions.Add(new Vector3(spawnPosX2, 0, spawnPosZ2));
        positions.Add(new Vector3(spawnPosX3, 0, spawnPosZ3));

        return positions;

    }

    void Spawner()
    {

        List<Vector3> positions = new List<Vector3>();
        positions = GeneratePosition();

        for (int i = 0; i < 3; i++)
        {

            Instantiate(obstacle, positions[Random.Range(0,3)], obstacle.transform.rotation);
           
        }
        
    }

    void GameProgress()
    {
        PlayerController playerScript = player.GetComponent<PlayerController>();
        playerScript.speed += 10;
    }
    
}
