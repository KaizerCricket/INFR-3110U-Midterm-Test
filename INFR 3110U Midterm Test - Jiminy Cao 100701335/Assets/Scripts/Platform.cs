using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the Moving Platform at the end
public class Platform : MonoBehaviour
{
    // Reference to player
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        // Start moving when player walks onto the platform
        if (other.gameObject == player) {
            this.GetComponent<Animator>().SetBool("isHere", true);
        }
    }
}
