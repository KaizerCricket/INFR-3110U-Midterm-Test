using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0F;

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();

        if (Input.GetAxis("Vertical") != 0) {
            controller.SimpleMove(transform.TransformDirection(Vector3.forward) * speed * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0) {
            controller.SimpleMove(transform.TransformDirection(Vector3.right) * speed * Input.GetAxis("Horizontal"));
        }
    }
}
