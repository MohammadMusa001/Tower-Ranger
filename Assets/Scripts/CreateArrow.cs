using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArrow : State
{
    public ChargeArrow chargeArrow;
    public GameObject arrowToBeCreated;
    public override State RunCurrentState()
    {
        if(Input.GetButton("Fire1"))
        {
            return chargeArrow;
        }
        else
        {
            
            chargeArrow.arrowToBeCharged = this.arrowToBeCreated;
            return this;
        }
    }
    

}
