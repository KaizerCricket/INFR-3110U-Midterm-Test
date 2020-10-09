using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MB1 : MonoBehaviour
{
    public float speed = 3.0f;

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
        if (transform.position.x <= 13.0f) {
            speed = 3.0f;
        }
        else if (transform.position.x >= 17.0f) {
            speed = -3.0f;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
