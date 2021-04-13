using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{

    float greenTime = 10f;
    float redTime = 10f;
    float allTime = 20f;

    public GameObject light;

    void Start()
    {
       
        //Call SetColor using the shader property name "_Color" and setting the color to red
        light.GetComponent<Renderer>().material.color = Color.black; //initial is black
        InvokeRepeating("TurnRed", 0f, allTime);//after 0 second call GreenTurn(), then every 10second call it again
        InvokeRepeating("TurnGreen", redTime, allTime);//after 10second, green turn red, repeat every 20 seconds
    }
     
    void Update()
    {
       
    }

    void TurnGreen()
    {
        light.GetComponent<Renderer>().material.color = Color.green;

    }

    void TurnRed()
    {
        light.GetComponent<Renderer>().material.color = Color.red;
    }
}
