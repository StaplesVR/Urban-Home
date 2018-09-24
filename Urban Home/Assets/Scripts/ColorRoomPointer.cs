using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorRoomPointer : MonoBehaviour {

    RaycastHit hit;

    public GameObject ceilingHigh;
    public GameObject ceilingSelect;
    public GameObject ceilDotSelect;
    public bool ceilingIsSelected;


    public GameObject wallHigh;
    public GameObject wallSelect;
    public GameObject wallDotSelect;
    public bool wallIsSelected;

    public GameObject frameHigh;
    public GameObject frameSelect;
    public GameObject frameDotSelect;
    public bool frameIsSelected;


    public SteamVR_TrackedController TCScript;
    public Animation fadeAnim;


    private void Start()
    {
        TCScript.TriggerClicked += new ClickedEventHandler(Select);
    }

    // Update is called once per frame
    void Update()
    {

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.tag == "Color")
            {
                hit.collider.gameObject.GetComponent<MyColour>().TurnHighlightOn();
            }

            if (hit.collider.tag == "Main Hub")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Ceiling dot")
            {
                hit.collider.gameObject.GetComponent<ColorRoomHighlight>().TurnHighlightOn();
            }

            if (hit.collider.tag == "Wall dot")
            {
                hit.collider.gameObject.GetComponent<ColorRoomHighlight>().TurnHighlightOn();
            }

            if (hit.collider.tag == "Frame dot")
            {
                hit.collider.gameObject.GetComponent<ColorRoomHighlight>().TurnHighlightOn();
            }
        }
    }


    void Select(object sender, ClickedEventArgs e)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.tag == "Color")
            {
                hit.collider.gameObject.GetComponent<MyColour>().TurnOnSelected();
            }

            if (hit.collider.tag == "Main Hub")
            {
                SceneManager.LoadScene("1. Urban Home Main Scene");
            }

            if (hit.collider.tag == "Ceiling dot")
            {
                if (ceilingIsSelected == false)
                {
                    Debug.Log("ceiling is selected");
                    ceilingIsSelected = true;
                    ceilingSelect.SetActive(true);
                    ceilDotSelect.SetActive(true);

                }
                else if (ceilingIsSelected == true)
                {
                    Debug.Log("ceiling is deselected");
                    ceilingSelect.SetActive(false);
                    ceilingIsSelected = false;
                    ceilDotSelect.SetActive(false);
                }

               
            }

            if (hit.collider.tag == "Wall dot")
            {
                if (wallIsSelected == false)
                {
                    Debug.Log("wall is selected");
                    wallIsSelected = true;
                    wallSelect.SetActive(true);
                    wallDotSelect.SetActive(true);

                }
                else if (wallIsSelected == true)
                {
                    Debug.Log("wall is deselected");
                    wallSelect.SetActive(false);
                    wallIsSelected = false;
                    wallDotSelect.SetActive(false);
                }
            }


            if (hit.collider.tag == "Frame dot")
            {
                if (frameIsSelected == false)
                {
                    Debug.Log("frame is selected");
                    frameIsSelected = true;
                    frameSelect.SetActive(true);
                    frameDotSelect.SetActive(true);

                }
                else if (frameIsSelected == true)
                {
                    Debug.Log("frame is deselected");
                    frameSelect.SetActive(false);
                    frameIsSelected = false;
                    frameDotSelect.SetActive(false);
                }
            }
        }
    }
}
