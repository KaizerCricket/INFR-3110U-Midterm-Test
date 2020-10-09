using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    public bool visited = false;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player && !visited) {
            player.GetComponent<PlayerMovement>().checkpoint = this.gameObject;
            visited = true;
        }
    }
}
