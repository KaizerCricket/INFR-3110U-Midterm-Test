using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : MonoBehaviour
{
    // Reference to player
    public GameObject player;
    // Reference to all checkpoints
    public List<GameObject> checkpoints = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject == player) {
            // Calls DLL function to log time;
            GameObject.Find("Logger").GetComponent<PluginManager>().SaveTime();
            // Resets Checkpoints for future playthroughs
            for (int i = 0; i < 5; i++) {
                checkpoints[i].GetComponent<Checkpoint>().visited = false;
            }
            // Transitions player to stat/end screen
            SceneManager.LoadScene(2);
        }
    }
}
