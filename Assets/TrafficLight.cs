using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    float redTime = 10f;
    float allTime = 20f;

    public float initRedTime;
    public GameObject light;
    public GameObject obstacle;

    void Start()
    {

        //Call SetColor using the shader property name "_Color" and setting the color to red
        light.GetComponent<Renderer>().material.color = Color.red; //initial is red light
        obstacle.SetActive(true);

        StartCoroutine(ControlLights());
    }

    void Update()
    {

    }
    IEnumerator ControlLights() {
        yield return new WaitForSeconds(initRedTime);
        InvokeRepeating("TurnGreen", 0f, allTime);//after 0 second call GreenTurn(), then every 10second call it again
        InvokeRepeating("TurnRed", redTime, allTime);//after 10second, green turn red, repeat every 20 seconds
    }

    void TurnGreen()
    {
        light.GetComponent<Renderer>().material.color = Color.green;
        obstacle.SetActive(false);
    }

    void TurnRed()
    {
        light.GetComponent<Renderer>().material.color = Color.red;
        obstacle.SetActive(true);
    }
}
