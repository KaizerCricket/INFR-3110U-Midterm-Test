using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0F;

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();

        controller.SimpleMove(transform.TransformDirection(Vector3.forward) * speed * Input.GetAxis("Vertical")
                            + transform.TransformDirection(Vector3.right) * speed * Input.GetAxis("Horizontal"));
    }
}
