using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMoves : MonoBehaviour
{

    

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    AudioSource audioData;
    public Transform endMarker;
    public Transform endMarker2;
    private bool activedFly = false;
    Animator anim;
    private int ver = 1;

    // Movement speed in units/sec.
    public float speed = 1.0F;
    public float speed2 = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        // Keep a note of the time the movement started.
        

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

    }
    public void Fly()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        startTime = Time.time;
        anim.SetTrigger("fly");
        activedFly = true;
    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        if (activedFly == true) { 
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
      
            if (transform.position.y>149 && ver==1)
            {
                ver = 0;
                Debug.Log("xD");
                startTime = Time.time;
                speed = speed2;
                endMarker.position = endMarker2.position;
                journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            }
        }
    }
} 
