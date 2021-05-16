
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonFunction : MonoBehaviour
{
    public GameObject lightNE;
    public GameObject lightNW;
    public GameObject lightSE;
    public GameObject lightSW;

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        lightNE = GameObject.Find("LightsNEPos");
        lightNW = GameObject.Find("LightsNWPos");
        lightSE = GameObject.Find("LightsSEPos");
        lightSW = GameObject.Find("LightsSWPos");

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Button btn = GetComponent<Button>();
        Debug.LogWarning(btn.tag);
       
        GameObject bus;
        if (btn.tag == "1") {
            bus = GameObject.Find("Bus1(Clone)");
        } else {
            bus = GameObject.Find("Bus2(Clone)");
        }

        bus.GetComponent<driveToBus>().waitLonger = true;

        InterruptTraffic();

    }

    void InterruptTraffic() {
        string location = GetPlayerLocation();

        if (location != "skip") {
            GameObject lights = GameObject.Find("4_Lanes_Crossroad/TrafficLights");
            lights.GetComponent<TrafficLightsControl>().prioPedestrians(location);
        }
    }

    string GetPlayerLocation() {
        GameObject player = GameObject.Find("Player");

        float distanceNE = Vector3.Distance(player.transform.position, lightNE.transform.position);
        float distanceNW = Vector3.Distance(player.transform.position, lightNW.transform.position);
        float distanceSE = Vector3.Distance(player.transform.position, lightSE.transform.position);
        float distanceSW = Vector3.Distance(player.transform.position, lightSW.transform.position);

        if (distanceSW < distanceNW && distanceSW < distanceSE && distanceSW < distanceNE) {
            return "pedestrian_SW";
        } else if (distanceSE < distanceNE && distanceSE < distanceNW && distanceSE < distanceSW) {
            return "pedestrian_SE";
        } else if (distanceNW < distanceNE && distanceNW < distanceSE && distanceNW < distanceSW) {
            return "pedestrian_NW";
        } else {
            return "skip";
        }
    }
}