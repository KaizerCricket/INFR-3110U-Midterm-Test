using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MB2 : MonoBehaviour {
    public float speed = 5.0f;

    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            player.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.z <= 3.0f) {
            speed = 5.0f;
        }
        else if (transform.position.z >= 7.0f) {
            speed = -5.0f;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
