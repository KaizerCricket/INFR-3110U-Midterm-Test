using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Reference to Player
    public GameObject player;

    void Update() {
        // Keeps the Camera positioned directly aboce player for Top-Down view
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
