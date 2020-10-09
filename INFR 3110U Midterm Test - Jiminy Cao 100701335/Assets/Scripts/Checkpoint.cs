using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            player.GetComponent<PlayerMovement>().checkpoint = this.gameObject;
        }
    }
}
