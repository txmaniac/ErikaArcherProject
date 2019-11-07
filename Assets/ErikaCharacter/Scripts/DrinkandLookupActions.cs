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
        anim.SetBool("onSunny", false);
        anim.SetBool("isShoot", false);
    }

    // Update is called once per frame
    void Update()
    { 
        bool input_interact = Input.GetKey(KeyCode.E);
        bool input_look = Input.GetKey(KeyCode.Q);
        bool input_overdraw = Input.GetMouseButton(1);
        bool input_recoil = Input.GetMouseButtonDown(0);
        anim.SetBool("foundDrink", input_interact);
        anim.SetBool("onSunny", input_look);
        anim.SetBool("isShoot", input_overdraw);
        

        if (input_recoil)
            anim.SetTrigger("isFire");
    }
}
