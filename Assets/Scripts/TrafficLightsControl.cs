using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsControl : MonoBehaviour
{
    public float greenTime;
    public float orangeTime;
    public ArrayList stateQueue;

    public Material greenColor;
    public Material orangeColor;
    public Material redColor;

    public GameObject southLeftLight;
    public GameObject southLeftObstacle;
    public GameObject southForwardLight;
    public GameObject southForwardObstacle;
    public GameObject southRightLight;
    public GameObject southRightObstacle;
    public GameObject southPedestrianLight;
    public GameObject southPedestrianObstacle;

    public GameObject eastLeftLight;
    public GameObject eastLeftObstacle;
    public GameObject eastForwardLight;
    public GameObject eastForwardObstacle;
    public GameObject eastRightLight;
    public GameObject eastRightObstacle;
    public GameObject eastPedestrianLight;
    public GameObject eastPedestrianObstacle;

    public GameObject northLeftLight;
    public GameObject northLeftObstacle;
    public GameObject northForwardLight;
    public GameObject northForwardObstacle;
    public GameObject northRightLight;
    public GameObject northRightObstacle;
    public GameObject northPedestrianLight;
    public GameObject northPedestrianObstacle;

    public GameObject westLeftLight;
    public GameObject westLeftObstacle;
    public GameObject westForwardLight;
    public GameObject westForwardObstacle;
    public GameObject westRightLight;
    public GameObject westRightObstacle;
    public GameObject westPedestrianLight;
    public GameObject westPedestrianObstacle;

    void Start()
    {
        StartCoroutine(ControlLights());
    }

    public void prioPedestrians(string pedestrianState) {
        foreach (string state in stateQueue) {
            if (state == pedestrianState) {
                return;
            }
        }

        stateQueue.Insert(1, pedestrianState);
    }

    IEnumerator ControlLights() {
        while (true) {
            bool cycleEnd = false;
            stateQueue = new ArrayList() {"one", "two", "three", "four"};

            while (!cycleEnd) {
                if (stateQueue[0] == "one") {
                    StartCoroutine(StateOne());
                } else if (stateQueue[0] == "two"){
                    StartCoroutine(StateTwo());
                } else if (stateQueue[0] == "three") {
                    StartCoroutine(StateThree());
                } else if (stateQueue[0] == "four") {
                    StartCoroutine(StateFour());
                } else if (stateQueue[0] == "pedestrian_SW") {
                    StartCoroutine(StatePedestrianSW());
                } else if (stateQueue[0] == "pedestrian_SE") {
                    StartCoroutine(StatePedestrianSE());
                } else if (stateQueue[0] == "pedestrian_NW") {
                    StartCoroutine(StatePedestrianNW());
                }
                yield return new WaitForSeconds(greenTime + orangeTime);

                if (stateQueue.Count == 1) {
                    cycleEnd = true;
                } else {
                    stateQueue.RemoveAt(0);
                }
            }
        }
    }

    IEnumerator StatePedestrian() {
        southPedestrianLight.GetComponent<Renderer>().material = greenColor;
        southPedestrianObstacle.SetActive(false);

        northPedestrianLight.GetComponent<Renderer>().material = greenColor;
        northPedestrianObstacle.SetActive(false);

        eastPedestrianLight.GetComponent<Renderer>().material = greenColor;
        eastPedestrianObstacle.SetActive(false);

        westPedestrianLight.GetComponent<Renderer>().material = greenColor;
        westPedestrianObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime + orangeTime);

        southPedestrianLight.GetComponent<Renderer>().material = redColor;
        southPedestrianObstacle.SetActive(true);

        northPedestrianLight.GetComponent<Renderer>().material = redColor;
        northPedestrianObstacle.SetActive(true);

        eastPedestrianLight.GetComponent<Renderer>().material = redColor;
        eastPedestrianObstacle.SetActive(true);

        westPedestrianLight.GetComponent<Renderer>().material = redColor;
        westPedestrianObstacle.SetActive(true);
    }

    IEnumerator StatePedestrianSW() {
        northPedestrianLight.GetComponent<Renderer>().material = greenColor;
        eastPedestrianLight.GetComponent<Renderer>().material = greenColor;
        westPedestrianLight.GetComponent<Renderer>().material = greenColor;

        southRightLight.GetComponent<Renderer>().material = greenColor;

        westPedestrianObstacle.SetActive(false);
        northPedestrianObstacle.SetActive(false);

        southRightObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        northPedestrianLight.GetComponent<Renderer>().material = redColor;
        eastPedestrianLight.GetComponent<Renderer>().material = redColor;
        westPedestrianLight.GetComponent<Renderer>().material = redColor;

        southRightLight.GetComponent<Renderer>().material = orangeColor;

        westPedestrianObstacle.SetActive(true);
        northPedestrianObstacle.SetActive(true);

        southRightObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        southRightLight.GetComponent<Renderer>().material = redColor;
    }

    IEnumerator StatePedestrianSE() {
        southPedestrianLight.GetComponent<Renderer>().material = greenColor;
        eastPedestrianLight.GetComponent<Renderer>().material = greenColor;

        southForwardLight.GetComponent<Renderer>().material = greenColor;
        northRightLight.GetComponent<Renderer>().material = greenColor;
        westRightLight.GetComponent<Renderer>().material = greenColor;

        eastPedestrianObstacle.SetActive(false);

        southForwardObstacle.SetActive(false);
        northRightObstacle.SetActive(false);
        westRightObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        southPedestrianLight.GetComponent<Renderer>().material = redColor;
        eastPedestrianLight.GetComponent<Renderer>().material = redColor;

        southForwardLight.GetComponent<Renderer>().material = orangeColor;
        northRightLight.GetComponent<Renderer>().material = orangeColor;
        westRightLight.GetComponent<Renderer>().material = orangeColor;

        eastPedestrianObstacle.SetActive(true);

        southForwardObstacle.SetActive(true);
        northRightObstacle.SetActive(true);
        westRightObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        southForwardLight.GetComponent<Renderer>().material = redColor;
        northRightLight.GetComponent<Renderer>().material = redColor;
        westRightLight.GetComponent<Renderer>().material = redColor;
    }

    IEnumerator StatePedestrianNW() {
        eastPedestrianLight.GetComponent<Renderer>().material = greenColor;
        northPedestrianLight.GetComponent<Renderer>().material = greenColor;

        westRightLight.GetComponent<Renderer>().material = greenColor;
        southRightLight.GetComponent<Renderer>().material = greenColor;
        eastForwardLight.GetComponent<Renderer>().material = greenColor;

        northPedestrianObstacle.SetActive(false);

        westRightObstacle.SetActive(false);
        southRightObstacle.SetActive(false);
        eastForwardObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        eastPedestrianLight.GetComponent<Renderer>().material = redColor;
        northPedestrianLight.GetComponent<Renderer>().material = redColor;

        westRightLight.GetComponent<Renderer>().material = orangeColor;
        southRightLight.GetComponent<Renderer>().material = orangeColor;
        eastForwardLight.GetComponent<Renderer>().material = orangeColor;

        northPedestrianObstacle.SetActive(true);

        westRightObstacle.SetActive(true);
        southRightObstacle.SetActive(true);
        eastForwardObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        westRightLight.GetComponent<Renderer>().material = redColor;
        southRightLight.GetComponent<Renderer>().material = redColor;
        eastForwardLight.GetComponent<Renderer>().material = redColor;
    }

    IEnumerator StateOne()
    {
        southForwardLight.GetComponent<Renderer>().material = greenColor;
        southRightLight.GetComponent<Renderer>().material = greenColor;
        southPedestrianLight.GetComponent<Renderer>().material = greenColor;
        southForwardObstacle.SetActive(false);
        southRightObstacle.SetActive(false);
        southPedestrianObstacle.SetActive(false);

        northForwardLight.GetComponent<Renderer>().material = greenColor;
        northRightLight.GetComponent<Renderer>().material = greenColor;
        northPedestrianLight.GetComponent<Renderer>().material = greenColor;
        northForwardObstacle.SetActive(false);
        northRightObstacle.SetActive(false);
        northPedestrianObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        southForwardLight.GetComponent<Renderer>().material = orangeColor;
        southRightLight.GetComponent<Renderer>().material = orangeColor;
        southPedestrianLight.GetComponent<Renderer>().material = redColor;
        southForwardObstacle.SetActive(true);
        southRightObstacle.SetActive(true);
        southPedestrianObstacle.SetActive(true);

        northForwardLight.GetComponent<Renderer>().material = orangeColor;
        northRightLight.GetComponent<Renderer>().material = orangeColor;
        northPedestrianLight.GetComponent<Renderer>().material = redColor;
        northForwardObstacle.SetActive(true);
        northRightObstacle.SetActive(true);
        northPedestrianObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        southForwardLight.GetComponent<Renderer>().material = redColor;
        southRightLight.GetComponent<Renderer>().material = redColor;
        northForwardLight.GetComponent<Renderer>().material = redColor;
        northRightLight.GetComponent<Renderer>().material = redColor;
    }

    IEnumerator StateTwo()
    {
        eastForwardLight.GetComponent<Renderer>().material = greenColor;
        eastRightLight.GetComponent<Renderer>().material = greenColor;
        eastPedestrianLight.GetComponent<Renderer>().material = greenColor;
        eastForwardObstacle.SetActive(false);
        eastRightObstacle.SetActive(false);
        eastPedestrianObstacle.SetActive(false);

        westForwardLight.GetComponent<Renderer>().material = greenColor;
        westRightLight.GetComponent<Renderer>().material = greenColor;
        westPedestrianLight.GetComponent<Renderer>().material = greenColor;
        westForwardObstacle.SetActive(false);
        westRightObstacle.SetActive(false);
        westPedestrianObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        eastForwardLight.GetComponent<Renderer>().material = orangeColor;
        eastRightLight.GetComponent<Renderer>().material = orangeColor;
        eastPedestrianLight.GetComponent<Renderer>().material = redColor;
        eastForwardObstacle.SetActive(true);
        eastRightObstacle.SetActive(true);
        eastPedestrianObstacle.SetActive(true);

        westForwardLight.GetComponent<Renderer>().material = orangeColor;
        westRightLight.GetComponent<Renderer>().material = orangeColor;
        westPedestrianLight.GetComponent<Renderer>().material = redColor;
        westForwardObstacle.SetActive(true);
        westRightObstacle.SetActive(true);
        westPedestrianObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        eastForwardLight.GetComponent<Renderer>().material = redColor;
        eastRightLight.GetComponent<Renderer>().material = redColor;
        westForwardLight.GetComponent<Renderer>().material = redColor;
        westRightLight.GetComponent<Renderer>().material = redColor;
    }

    IEnumerator StateThree() {
        southLeftLight.GetComponent<Renderer>().material = greenColor;
        southLeftObstacle.SetActive(false);

        northLeftLight.GetComponent<Renderer>().material = greenColor;
        northLeftObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        southLeftLight.GetComponent<Renderer>().material = orangeColor;
        southLeftObstacle.SetActive(true);

        northLeftLight.GetComponent<Renderer>().material = orangeColor;
        northLeftObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        southLeftLight.GetComponent<Renderer>().material = redColor;
        northLeftLight.GetComponent<Renderer>().material = redColor;
    }

    IEnumerator StateFour() {
        eastLeftLight.GetComponent<Renderer>().material = greenColor;
        eastLeftObstacle.SetActive(false);

        westLeftLight.GetComponent<Renderer>().material = greenColor;
        westLeftObstacle.SetActive(false);

        yield return new WaitForSeconds(greenTime);

        eastLeftLight.GetComponent<Renderer>().material = orangeColor;
        eastLeftObstacle.SetActive(true);

        westLeftLight.GetComponent<Renderer>().material = orangeColor;
        westLeftObstacle.SetActive(true);

        yield return new WaitForSeconds(orangeTime);

        eastLeftLight.GetComponent<Renderer>().material = redColor;
        westLeftLight.GetComponent<Renderer>().material = redColor;
    }
}
