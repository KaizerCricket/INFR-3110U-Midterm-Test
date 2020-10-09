using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndPoint : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> checkpoints = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            SceneManager.LoadScene(2);
            for (int i = 0; i<5; i++)
                checkpoints[i].GetComponent<Checkpoint>().visited=false;
        }
    }
}
