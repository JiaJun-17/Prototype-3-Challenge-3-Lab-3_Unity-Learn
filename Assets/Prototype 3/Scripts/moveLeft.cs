using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float speed = 10.0f;

    //name of the class which is PlayerController
    //used to communicate between scripts
    //if want the move left function stop when something happen, then need to create the reference in moveLeft script
    private PlayerController playerControllerScript; //create a variable 
    private float leftBoundary = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //find Player in the hierarchy
        //set the variable to PlayerContoller object/component on Player gameobject in the scene
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if gameOver==true, stop
        if (playerControllerScript.gameOver == false){  //gameOver is a public variable from PlayerController class

            transform.Translate(Vector3.left * speed * Time.deltaTime); //move to the left

        }
        
        if(transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle")){

            Destroy(gameObject);

        }
    }
}
