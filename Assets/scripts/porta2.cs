using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta2 : MonoBehaviour
{



    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;
    private bool activedOpen = false;


    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

    }
    public void Open()
    {
        startTime = Time.time;
   
        activedOpen = true;
    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        if (activedOpen == true)
        {
            Debug.Log("xDDD");
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

           
        }
    }
}
