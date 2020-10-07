using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;

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

    public void SaveTime(float checkpointTime) {
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

    public float LoadTotalTimeTest() {
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
        if (Input.GetKeyDown(KeyCode.O)) {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            lastTime = currentTime;

            SaveTime(checkpointTime);
        }
    }
    private void OnDestroy() {
        ResetLog();
    }
}
