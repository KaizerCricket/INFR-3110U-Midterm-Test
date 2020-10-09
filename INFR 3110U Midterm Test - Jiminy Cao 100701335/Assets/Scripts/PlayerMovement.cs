using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 7.5f;
    private Vector3 velocity;
    public GameObject checkpoint;
    public Animator anim;

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = 0.0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero) {
            transform.forward = move;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -4) {
            anim.SetTrigger("Died");
            anim.SetBool("isHere", false);
            transform.position = checkpoint.transform.position;
        }
    }
}
