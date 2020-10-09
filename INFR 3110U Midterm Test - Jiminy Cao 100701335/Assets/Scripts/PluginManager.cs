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

        float currentTime = Time.timeSinceLevelLoad;
        float checkpointTime = currentTime - lastTime;
        lastTime = currentTime;

        SaveCheckpointTime(checkpointTime);
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
        lastTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update() {
        text.GetComponent<Text>().text = "Time: " + (Math.Floor(Time.timeSinceLevelLoad* 100) / 100).ToString() + "s";
    }
    private void OnDestroy() {
        for(int i = 0; i < GetNumCheckpoints(); i++)
        Stats.cps.Add(LoadTime(i));
        Stats.total = LoadTotalTime();
        ResetLog();
    }
}
