using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            this.GetComponent<Animator>().SetBool("isHere", true);
        }
    }
}
