using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourLoader : MonoBehaviour {

    public Renderer CRCeiling;
    public Renderer CRWall;
    public Material CRFrame;

    public ColorRoomPointer CRPoint;

    public Transform Content;
    public GameObject ColorPrefab;
    public MasterList MasterList = new MasterList();

    private List<MyColour> colourList = new List<MyColour>();

    [Header("UI Stuff")]
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI ReseneCodeText;
    public TextMeshProUGUI RGBText;

	// Use this for initialization
	void Start () {

        TextAsset asset = Resources.Load("Colours") as TextAsset;

        if(asset != null)
        {
            MasterList TheList = JsonUtility.FromJson<MasterList>(asset.text);
            foreach (Master master in TheList.Master)
            {
                bool DontAdd = false;
                if (master.R == "-" || master.G == "-" || master.B == "-")
                {
                    DontAdd = true;
                }
                else
                {
                    foreach (Master CheckMaster in MasterList.Master)
                    {
                        if (master.Totalcolourcode == CheckMaster.Totalcolourcode)
                        {
                            DontAdd = true;
                            break;
                        }
                    }
                }
                if (!DontAdd)
                {
                    float R = int.Parse(master.R);
                    float G = int.Parse(master.G);
                    float B = int.Parse(master.B);
                    string rgbString = "R:" + master.R + " ,G:" + master.G + " ,B" + master.B;
                    Color theColor = new Color32((byte)R, (byte)G, (byte)B, 255);
                    CreateColor(theColor, master.Colourname, master.Totalcolourcode, rgbString);
                    MasterList.Master.Add(master);
                }
            }
        }
        else
        {
            print("Nothin here?");
        }

    }

    public void CreateColor(Color theColor, string theName, string Code, string rgbString)
    {
        GameObject ReseneColor = Instantiate(ColorPrefab, Content.position, Content.rotation, Content);
        MyColour colorScript = ReseneColor.GetComponent<MyColour>();
        colorScript.SetColor(theName, Code, rgbString, theColor, this);
        colourList.Add(colorScript);
    }

    public void ColorSelected(string name, string code, string rgb, Color theColor)
    {

        if(CRPoint.ceilingIsSelected == true)
        {
            CRCeiling.material.color = theColor;
        }

        if (CRPoint.wallIsSelected == true)
        {
            CRWall.material.color = theColor;
        }

        if (CRPoint.frameIsSelected == true)
        {
            CRFrame.color = theColor;
        }

        NameText.text = name;
        ReseneCodeText.text = code;
        RGBText.text = rgb;

    }

    public void TurnOffSelected()
    {
        foreach(MyColour theColour in colourList)
        {
            theColour.TurnOffSelection();
        }
    }

    private void OnApplicationQuit()
    {
        CRFrame.color = new Color32(55, 55, 55, 255);
    }
}
