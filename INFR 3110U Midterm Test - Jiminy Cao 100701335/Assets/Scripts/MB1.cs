using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MB1 : MonoBehaviour
{
    private float speed = 2.0f;

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
    void Update()
    {
        
        if (transform.position.x <= 13.0f || transform.position.x >= 17.0f) {
            speed *= -1.0f;
        }
        if (speed < 0) {
            player.transform.parent = null;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
