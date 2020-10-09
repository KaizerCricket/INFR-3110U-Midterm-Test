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

    float lastTime = 0.0f;
    public GameObject text;

    public void SaveTime() {

        float currentTime = Time.time;
        float checkpointTime = currentTime - lastTime;
        lastTime = currentTime;

        SaveCheckpointTime(checkpointTime);
        Debug.Log(checkpointTime);
    }

    public float LoadTime(int index) {
        if (index >= GetNumCheckpoints()) {
            return -1;
        }
        else {
            return GetCheckpointTime(index);
        }
    }

    public float LoadTotalTime() {
        return GetTotalTime();
    }

    public void ResetLog() {
        ResetLogger();
    }

    // Start is called before the first frame update
    void Start() {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        text.GetComponent<Text>().text = "Time: " + (Math.Floor(Time.time * 100) / 100).ToString() + "s";
    }
    private void OnDestroy() {
        ResetLog();
    }
}
