using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleArrow : State
{
    public CreateArrow createArrow;
    public override State RunCurrentState()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("sssss");
            return createArrow;
        }
        else
        {
            return this;
        }
    }

}
