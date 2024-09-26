using UnityEngine;
using MidiJack;
using System.Collections.Generic;

public class MIDIToKeyPress : MonoBehaviour
{
    Dictionary<int, KeyCode> midiToKeyMap = new Dictionary<int, KeyCode>();

    void Start()
    {
        // Map MIDI key 60 to "W" key and MIDI key 61 to "Space"
        midiToKeyMap.Add(60, KeyCode.G);
        midiToKeyMap.Add(62, KeyCode.H);
        midiToKeyMap.Add(64, KeyCode.J);
        midiToKeyMap.Add(65, KeyCode.K);
        midiToKeyMap.Add(67, KeyCode.L);
    }

    void Update()
    {
        // Check for all mapped MIDI keys
        foreach (var entry in midiToKeyMap)
        {
            if (MidiMaster.GetKeyDown(0, entry.Key))
            {
                SimulateKeyPress(entry.Value);
            }
        }
    }

    void SimulateKeyPress(KeyCode key)
    {
        Debug.Log("Simulated Key Press: " + key);
        // Implement your logic based on the mapped key action
    }
}