using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField]Vector3 movementVector;
    [SerializeField][Range(0,1)]  float movementFactor;
    [SerializeField]float speed = 1f;


    float theta = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
         
        theta = theta + speed*Time.deltaTime;
        Vector3 offset = movementFactor * movementVector;
        
        transform.position = startingPosition + movementVector * Mathf.Sin(theta+2*Mathf.PI*movementFactor ) ;
    }
}
