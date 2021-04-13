using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{



    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
   Vector3 endMarker;
    private bool activedFly = false;
    Animator anim;
    private int ver = 1;
    public int moverange = 6;

    // Movement speed in units/sec.
    public float speed = 0.7F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        // Keep a note of the time the movement started.
        

    }
    public void Move()
    {
        endMarker = new Vector3(startMarker.position.x, startMarker.position.y, startMarker.position.z + moverange);
        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
        startTime = Time.time;
        anim.SetTrigger("move");
        activedFly = true;
    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        if (activedFly == true)
        {
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
            Debug.Log(fracJourney);
           
                


        }
    }
}
