using UnityEngine;
using System.Collections;
// We need to import the ui libraries for talking to our count text
using UnityEngine.UI;

public class player : MonoBehaviour {
    
    // We need to talk to our count text
    public Text countText;
    // We need to talk to our win text
    public Text winText;

    // This float will be used to control the speed of our player. We are not setting it in the script because we want to edit it in the editor
    public float speed;

    // We need to keep track of how many pickups we have collected
    private int count;

    // In order to use our rigidbody we need to tell unity that we are using one
    private Rigidbody rb;

    // The start function only runs once at the beginning of a script. This is where you should setup anything you will use later on
    void Start()
    {
        // You can then assign the rigidbody to be the one we created in the editor
        rb = GetComponent<Rigidbody>();

        // At the start of every game we need to restart the count 
        count = 0;
        // Then we need to update the score
        SetCountText();
    }

    // A fixed update runs at a constant rate, while a normal update runs once every frame, and a LateUpdate runs after every frame
    // You should do anything involving physics in the fixed update
    void FixedUpdate()
    {
        // We need to map our two directions to inputs
        // "Horizontal in Unity is equal to A, D, Left, or Right"
        float moveHorizontal = Input.GetAxis("Horizontal");
        // "Vertical in Unity is equal to W, S, Up, or Down"
        float moveVertical = Input.GetAxis("Vertical");
        
        // We take those values and put them in a vector. A Vector3 is a 3 dimensional vector, meaning it stores speed and direction for 3 dimensions 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // We can take that vector and add it to our rigidbody to make our sphere roll
        // We multiply it by our speed value so that we can set the speed of the object. If speed is equal to 1 then it will move 1 meter a second
        rb.AddForce(movement * speed);
    }

    // To detect when we hit a pickup item we need to check when a trigger is entered
    void OnTriggerEnter(Collider other)
    {
        // We then need to check if we collided with the gameobject we wanted to, the pickup items
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // If we did collide with one we can disable it
            other.gameObject.SetActive(false);
            // We then need to add one to our count
            count += 1;
            //And update the score
            SetCountText();
        }
    }

    // Create a new function to set the count
    void SetCountText()
    {
        // Set the text equal to the current count
        countText.text = "Count: " + count.ToString();

        // We need to check if the player has won
        if (count >= 12)
        {
            // If the player did win, we need to tell them
            winText.text = "You Win!";
        }
    }


}
