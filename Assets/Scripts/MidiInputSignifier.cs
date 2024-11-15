using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MidiInputSignifier : MonoBehaviour
{
    public int midiKey = 60;
    public float targetAlpha = 0.5f; // Desired alpha value (0 = transparent, 1 = opaque)   
    


    // Update is called once per frame
    void Update()
    {
        if (MidiMaster.GetKeyDown(0, midiKey))  
        {

            //rend.material.color = new Color(1, 1, 1, targetAlpha);

        }

    }
}
