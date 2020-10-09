using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> checkpoints = new List<GameObject>();
    void Start()
    {
        GameObject.Find("totalTime").GetComponent<Text>().text = (Math.Floor(Stats.total * 100) / 100).ToString() + "s";
        for (int i = 0; i < 6; i++)
            if (i >= Stats.cps.Count) {
                checkpoints[i].GetComponent<Text>().text = "0s";
            }
            else {
                checkpoints[i].GetComponent<Text>().text = (Math.Floor(Stats.cps[i] * 100) / 100).ToString() + "s";
            }
    }

}
