using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Reference to player
    public GameObject player;
    // Reference to object with DLL script
    private GameObject logger;
    // Check for if checkpoint has been passed
    public bool visited = false;

    private void Start() {
        // Get DLL object
        logger = GameObject.Find("Logger");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player && !visited) {
            // Sets player last checkpoint to this checkpoint
            player.GetComponent<PlayerMovement>().checkpoint = this.gameObject;
            // Sets boolean to true to prevent triggering past checkpoints
            visited = true;
            // Calls DLL function to log time;
            logger.GetComponent<PluginManager>().SaveTime();
        }
    }
}
