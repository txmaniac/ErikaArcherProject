using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkandLookupActions : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("foundDrink", false);
    }

    // Update is called once per frame
    void Update()
    { 
        bool input_interact = Input.GetKeyDown(KeyCode.E);

        if (input_interact)
        {
            anim.SetBool("foundDrink", input_interact);
            input_interact = false;
        }
    }
}
