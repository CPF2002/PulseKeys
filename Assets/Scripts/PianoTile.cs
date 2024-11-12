using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoTile : MonoBehaviour
{
    public int midiNote;
    private UnityEngine.UI.Image uiImage;
    public string objectName;
    public Color startColor;

    void Start()
    {
        uiImage = GetComponent<UnityEngine.UI.Image>();
        startColor = uiImage.color;
    }

    void Update()
    {
        // Change color of tile when midi note is pressed as a input signifier
        if (MidiJack.MidiMaster.GetKeyDown(0, midiNote))
        {
            uiImage.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        else if (MidiJack.MidiMaster.GetKeyUp(0, midiNote))
        {
            uiImage.color = startColor;
        }
    }

}