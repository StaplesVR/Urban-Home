using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MousePointer : MonoBehaviour {

    RaycastHit hit;
    public GameObject CameraRig;
    public GameObject bathTeleP;
    public GameObject colorTeleP;
    public GameObject frontTeleP;
    public GameObject kitchenTeleP;
    public GameObject laundryTeleP;
    public GameObject loungeTeleP;
    public GameObject mainTeleP;
    public GameObject outdoorTeleP;
    public GameObject walkTeleP;

    public SteamVR_TrackedController TCScript;
    public Animation fadeAnim;

    private void Start()
    {
        TCScript.TriggerClicked += new ClickedEventHandler(Select);
    }

    // Update is called once per frame
    void Update () {

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.tag == "Color")
            {
                hit.collider.gameObject.GetComponent<MyColour>().TurnHighlightOn();
            }

            if (hit.collider.tag == "Bathroom")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Color Room")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Front Entrance")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Kitchen")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Laundry")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Lounge")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Main Hub")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Outdoor")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }

            if (hit.collider.tag == "Walk-In")
            {
                hit.collider.gameObject.GetComponent<TeleportHighlight>().TurnTPHighlightOn();
            }
        }

        /*if (TCScript.triggerPressed == true)
        {
            Clicked();
        }*/
    }


    public void Clicked()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
    }

    void Select (object sender, ClickedEventArgs e)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.tag == "Color")
            {
                hit.collider.gameObject.GetComponent<MyColour>().TurnOnSelected();
            }

            if (hit.collider.tag == "Bathroom")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(bathTeleP.transform.position.x, bathTeleP.transform.position.y, bathTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Color Room")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                SceneManager.LoadScene("2. Color Room");
            }

            if(hit.collider.tag == "GoTo CR")
            {
                fadeAnim.Play("fadeIn");
                SceneManager.LoadScene("2. Color Room");
            }

            if (hit.collider.tag == "Front Entrance")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(frontTeleP.transform.position.x, frontTeleP.transform.position.y, frontTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Kitchen")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(kitchenTeleP.transform.position.x, kitchenTeleP.transform.position.y, kitchenTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Laundry")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(laundryTeleP.transform.position.x, laundryTeleP.transform.position.y, laundryTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Lounge")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(loungeTeleP.transform.position.x, loungeTeleP.transform.position.y, loungeTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Main Hub")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(mainTeleP.transform.position.x, mainTeleP.transform.position.y, mainTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Outdoor")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(outdoorTeleP.transform.position.x, outdoorTeleP.transform.position.y, outdoorTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }

            if (hit.collider.tag == "Walk-In")
            {
                Debug.Log("fading in");
                fadeAnim.Play("fadeIn");
                CameraRig.transform.position = new Vector3(walkTeleP.transform.position.x, walkTeleP.transform.position.y, walkTeleP.transform.position.z);
                fadeAnim.Play("fadeOut");
            }
        }
    }
}
