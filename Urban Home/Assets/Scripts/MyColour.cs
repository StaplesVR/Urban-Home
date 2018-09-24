using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MyColour : MonoBehaviour {

    private string Name;
    private string ReseneCode;
    private string rgbColor;

    public TextMeshProUGUI NameText;
    public Image imageColour;

    public GameObject Highlight;
    public GameObject Selected;

    private bool highlightOn;
    private float highlightTimer;

    private ColourLoader colourLoader;

    public void SetColor(string theName, string Code, string rgbString, Color theColor, ColourLoader script)
    {
        gameObject.name = theName;
        Name = theName;
        ReseneCode = Code;
        rgbColor = rgbString;

        NameText.text = theName;
        imageColour.color = theColor;
        colourLoader = script;
    }

    private void Update()
    {
        if (highlightOn)
        {
            highlightTimer -= Time.deltaTime;
            if(highlightTimer <= 0)
            {
                highlightOn = false;
                Highlight.SetActive(false);
            }
        }
    }

    public void TurnHighlightOn()
    {
        Highlight.SetActive(true);
        highlightOn = true;
        highlightTimer = 0.1f;
    }

    public void TurnOnSelected()
    {

        colourLoader.ColorSelected(Name, ReseneCode, rgbColor, imageColour.color);
        colourLoader.TurnOffSelected();
        Selected.SetActive(true);

    }

    public void TurnOffSelection()
    {
        Selected.SetActive(false);
    }

}
