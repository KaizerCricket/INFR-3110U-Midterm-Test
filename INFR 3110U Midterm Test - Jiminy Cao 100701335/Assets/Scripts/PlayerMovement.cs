using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Movement speed
    private float speed = 7.5f;
    // Velocity vector for gravity purposes
    private Vector3 velocity;
    // Reference to Checkpoint to respawn to
    public GameObject checkpoint;
    // reference to Animator component for final stretch
    public Animator anim;

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();

        // Floor check
        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = 0.0f;
        }

        // Movement using WASD
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);                                 
        
        // Set Transform forward to direction being moved towards
        if (move != Vector3.zero) {
            transform.forward = move;
        }

        // Gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Theoretical Death Plane
        if (transform.position.y < -4) {
            transform.position = checkpoint.transform.position;
            // Places End Moving Platform back to it's starting position
            anim.SetTrigger("Died");
            anim.SetBool("isHere", false);
        }
    }
}
