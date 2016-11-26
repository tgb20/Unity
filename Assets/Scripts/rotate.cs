using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    // We dont need any setup for this script so we can delete the start function
    void Update()
    {
        // The transform of the cube already has a rotate function
        // We can set it to rotate at a slightly off center rotation and multiply that by the delta time to keep it at a constant speed, delta time is 1 second = 1 second vs 1 second = 1 frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
