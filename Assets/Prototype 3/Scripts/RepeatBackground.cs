using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBakcground : MonoBehaviour
{
    private Vector3 startPosition; //the position that the object starts to move
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {

        startPosition = transform.position;
        //background must have collider component
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //the length of the background divide by 2

    }

    // Update is called once per frame
    void Update()
    {
        //if current position less than starting position
        if(transform.position.x < startPosition.x - repeatWidth){

            transform.position = startPosition;

        }
    }
}
