using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArrow : State
{
    
    
    public ChargeArrow chargeArrow       ;
    public GameObject  arrowToBeLaunched ;
    public GameObject  arrowToBeCreated  ;
    public Camera      fpscam            ;
    public Transform   arrowSpawn        ;
    public float       damage            ;
    public override State RunCurrentState()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            arrowToBeCreated = Instantiate(arrowToBeCreated) as GameObject;
            arrowToBeCreated.GetComponent<Rigidbody>().isKinematic = false;
            chargeArrow.arrowToBeCharged = arrowToBeCreated;
            return chargeArrow;
        }
        else
        {
            //Destroy(arrowToBeLaunched, 5f);
            return this;
        }
    }
}
