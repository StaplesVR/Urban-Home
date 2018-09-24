using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHighlight : MonoBehaviour {

    public GameObject TPHighlight;
    private bool TPhighlightOn;
    private float TPhighlightTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TPhighlightOn)
        {
            TPhighlightTimer -= Time.deltaTime;
            if (TPhighlightTimer <= 0)
            {
                TPhighlightOn = false;
                TPHighlight.SetActive(false);
            }
        }

    }

    public void TurnTPHighlightOn()
    {
        TPHighlight.SetActive(true);
        TPhighlightOn = true;
        TPhighlightTimer = 0.1f;
    }
}
