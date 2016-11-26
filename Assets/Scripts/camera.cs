using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    // We need to create a gameobject we can edit in the editor
    // This is how we will track our player
    public GameObject player;

    // We want the camera to stay offset from the player, otherwise we would just see the inside.
    private Vector3 offset;

    void Start()
    {
        // We can set our offset to be equal to the distance between the camera and the player
        // This will keep an equal distance
        offset = transform.position - player.transform.position;
    }

    // Does anyone remember what the late update does?
    void LateUpdate()
    {
        // After every frame we need to move the camera to its new position
        // We can set it to the players position plus our offset we setup before
        transform.position = player.transform.position + offset;
    }
}
