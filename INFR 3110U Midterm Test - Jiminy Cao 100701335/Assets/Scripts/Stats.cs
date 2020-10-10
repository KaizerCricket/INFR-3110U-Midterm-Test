using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Storage for Logger to persist between scenes
public class Stats : MonoBehaviour
{
    // Checkpoint time intervals stored here
    public static List<float> cps = new List<float>();
    // Total run time stored here
    public static float total;

    void Start()
    {
        // allows script/object to persist between scenes
        DontDestroyOnLoad(this);
    }
}
