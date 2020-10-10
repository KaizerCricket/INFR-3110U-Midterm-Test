using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class PluginManager : MonoBehaviour {
    const string DLL_NAME = "MidtermDLL";
    //RESET LOGGER
    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();
    //SET TIME
    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float intervals);
    //GET TOTAL TIME
    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();
    // GET CHECKPOINT TIME
    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);
    // GET NUMBER OF CHECKPOINTS
    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    // Time at previous Checkpoint
    float lastTime = 0.0f;
    // Reference to text for onscreen timer
    public GameObject text;

    // Function for logging current checkpoint
    public void SaveTime() {
        // Gets current time since start of playthrough
        float currentTime = Time.timeSinceLevelLoad;
        // Calculate time interval between previous and current checkpoint
        float checkpointTime = currentTime - lastTime;
        // Stores time of current checkpoint
        lastTime = currentTime;
        // Calls C++ function to add to checkpoint vector and total run time
        SaveCheckpointTime(checkpointTime);
    }

    // Gets time interval at index
    public float LoadTime(int index) {
        if (index >= GetNumCheckpoints()) {
            return -1;
        }
        else {
            return GetCheckpointTime(index);
        }
    }

    // Gets total run time
    public float LoadTotalTime() {
        return GetTotalTime();
    }

    // Resets Logger
    public void ResetLog() {
        ResetLogger();
    }

    // Starts up timer and clears static storage of checkpoint times
    void Start() {
        lastTime = Time.timeSinceLevelLoad;
        Stats.cps.Clear();
    }

    // Displays current total run time rounded to 2 decimals
    void Update() {
        text.GetComponent<Text>().text = "Time: " + (Math.Floor(Time.timeSinceLevelLoad* 100) / 100).ToString() + "s";
    }

    // When transitioning scenes, stores log in Static Variables of Stats script and calls reset function
    private void OnDestroy() {
        for (int i = 0; i < GetNumCheckpoints(); i++) {
            Stats.cps.Add(LoadTime(i));
        }
        Stats.total = LoadTotalTime();
        ResetLog();
    }
}
