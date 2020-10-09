using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    private GameObject logger;
    public bool visited = false;
    private float lastTime;

    private void Start() {
        logger = GameObject.Find("Logger");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player && !visited) {
            player.GetComponent<PlayerMovement>().checkpoint = this.gameObject;
            visited = true;
                
            logger.GetComponent<PluginManager>().SaveTime();
        }
    }
}
