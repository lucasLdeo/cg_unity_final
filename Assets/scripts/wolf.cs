using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour
{

    
   
    Animator anim;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();


    }
    public void Seat()
    {
 
        anim.SetTrigger("seat");

    }

    
    
}
