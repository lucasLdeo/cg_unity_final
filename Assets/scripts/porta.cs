using System.Collections;
using UnityEngine;

public class porta : MonoBehaviour {
    private bool clicked = false; 
    public float doorOpenAngle = 90.0f;
    public float doorCloseAngle = 0.0f;
    public float doorAnimSpeed = 2.0f;
    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
    public bool doorStatus = false; //false is close, true is open
    private bool doorGo = false; //for Coroutine, when start only one
    public int x;
    public int y;

    void Start()
{
    doorStatus = false; //door is open, maybe change
                        //Initialization your quaternions
    doorOpen = Quaternion.Euler(x, y, doorOpenAngle);
    doorClose = Quaternion.Euler(x, y, doorCloseAngle);
}

public void OpenD()
    {

        clicked = true;
    }
void Update()
{
   
    if (clicked && !doorGo)
    {
        //Calculate distance between player and door
        
            if (doorStatus)
            { //close door
                StartCoroutine(this.moveDoor(doorClose));
            }
            else
            { //open door
                StartCoroutine(this.moveDoor(doorOpen));
            }
        
    }
}
public IEnumerator moveDoor(Quaternion dest)
{
    doorGo = true;
    //Check if close/open, if angle less 4 degree, or use another value more 0
    while (Quaternion.Angle(transform.localRotation, dest) > 1.0f)
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
        //UPDATE 1: add yield
        yield return null;
    }
    //Change door status
    doorStatus = !doorStatus;
    doorGo = false;
        clicked = false;
    //UPDATE 1: add yield
    yield return null;
}
   
}