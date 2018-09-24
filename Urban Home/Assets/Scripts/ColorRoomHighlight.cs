using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRoomHighlight : MonoBehaviour {

    public GameObject DotHighlight;
    public GameObject partHighlight;
    private bool highlightOn;
    private float highlightTimer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (highlightOn)
        {
            highlightTimer -= Time.deltaTime;
            if (highlightTimer <= 0)
            {
                highlightOn = false;
                DotHighlight.SetActive(false);
                partHighlight.SetActive(false);
            }
        }

    }

    public void TurnHighlightOn()
    {
        DotHighlight.SetActive(true);
        partHighlight.SetActive(true);
        highlightOn = true;
        highlightTimer = 0.1f;
    }
}
