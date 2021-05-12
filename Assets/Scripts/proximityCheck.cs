using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class proximityCheck : MonoBehaviour
{
    public GameObject[] light;
    public GameObject pedestrian;
    public GameObject[] bus;
    public GameObject busStation;
    public float BusDistance;

    public GameObject buttonPrefab;
    public RectTransform buttonContainer;
    private GameObject button;
    public GameObject activeButtonTag;

    public GameObject[] buttonImage;
    public List<GameObject> buttonList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // foreach (Button button in AppButton) //disable all buttons at start
        //  {
        // button.interactable = false;
        // button.gameObject.SetActive(false);
        // }


    }

    // Update is called once per frame
    void Update()
    {
        bus = GameObject.FindGameObjectsWithTag("bus"); //get bus and save in bus list when it is spawned in the scene


        //for (int l = 0; l < light.Length; l++) 
        //LightDistance = Vector3.Distance(light[l].transform.position, pedestrian.transform.position);
        //check distance with traffic lights
        if (Vector3.Distance(light[0].transform.position, pedestrian.transform.position) < 35)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else if (Vector3.Distance(light[1].transform.position, pedestrian.transform.position) < 35)
        {
            checkDistance();
        }
        else if (Vector3.Distance(light[2].transform.position, pedestrian.transform.position) < 35)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else if (Vector3.Distance(light[3].transform.position, pedestrian.transform.position) < 35)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        // else
        // {
        //     disableAllButton();
        //  }

        // }//for loop 

        //check if pedestrian is close to the bus and bus is at the station
        void checkDistance()
        {

            for (int i = 0; i < bus.Length; i++)
            {
                int busNo = bus[i].GetComponent<busNumber>().busNo;
                activeButtonTag = GameObject.FindGameObjectWithTag(busNo.ToString()); //find button with tag = bus number
                if ((Vector3.Distance(bus[i].transform.position, pedestrian.transform.position) < 250) && (Vector3.Distance(bus[i].transform.position, busStation.transform.position) < 60))
                {

                    // AppButton[i].interactable = true;

                    // GameObject b = GameObject.FindGameObjectsWithTag("busNo");

                    if (!activeButtonTag) //if button for specific bus is not created
                    {
                        // AppButton[busNo - 1].gameObject.SetActive(true);
                        button = (GameObject)Instantiate(buttonPrefab); //instantiate button from prefab
                        button.tag = busNo.ToString(); //set button tag == bus number
                        button.GetComponentInChildren<Text>().text = "Bus No. " + busNo; //set button text == bus number
                        button.transform.SetParent(buttonContainer, false); //place the button in the button panel
                        buttonList.Add(button); //save theh button in the button list
                        buttonImage[i].SetActive(true);  //display image

                    }

                    //BusDistance = Vector3.Distance(bus[i].transform.position, pedestrian.transform.position);
                    //Debug.Log(BusDistance);
                }
                else
                {
                    // AppButton[busNo - 1].gameObject.SetActive(false);
                    if (activeButtonTag)
                    {
                        activeButtonTag.SetActive(false);
                        buttonImage[i].SetActive(false);
                    }
                }
            }

        }


        /*     void disableAllButton()
             {
                 foreach (Button button in AppButton) //disable all buttons 
                 {
                     // button.interactable = false;
                     button.gameObject.SetActive(false);
                 }
             }*/
    }
}