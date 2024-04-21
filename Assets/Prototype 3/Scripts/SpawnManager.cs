using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; //need drag the obstacle prefab into this obstaclePrefab variable in Unity Editor
    private Vector3 spawnPosition = new Vector3(25,0,0); //position
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScript; //get reference to the PlayerController Script

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //"Player" name must be the same as the name in the Unity

        //(name of the method, time to start, rate)
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle () {  //SpawnObstacle method

        //stop creating obstacle when the game is over 
        //if gameOver == true, it will skip the instantiate line of code 
        if(playerControllerScript.gameOver == false){

        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);

        }
    }
}
