using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public static List<float> cps = new List<float>();
    public static float total;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
