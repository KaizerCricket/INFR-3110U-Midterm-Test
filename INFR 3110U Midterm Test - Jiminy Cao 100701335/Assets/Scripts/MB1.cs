using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Moving Block Script 1
public class MB1 : MonoBehaviour {
    // Movement Speed
    public float speed = 3.0f;
    // Reference to Player
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        // Sets player as child of block to move them
        if (other.gameObject == player) {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        // Sets Player parent back to null when not pushing them
        if (other.gameObject == player) {
            player.transform.parent = null;
        }
    }

    void Update()
    {
        // Continuously move Block back and forth between 2 points
        if (transform.position.x <= 13.0f) {
            speed = 3.0f;
        }
        else if (transform.position.x >= 17.0f) {
            speed = -3.0f;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
