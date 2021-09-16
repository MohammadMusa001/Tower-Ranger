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
            arrowToBeCreated = ObjectPool.SharedInstance.GetPooledObject();
            if(arrowToBeCreated !=null)
            {
                arrowToBeCreated.SetActive(true);
                arrowToBeCreated.GetComponent<Rigidbody>().isKinematic = false;
                chargeArrow.arrowToBeCharged = arrowToBeCreated;    
            }
            return chargeArrow;
        }
        else
        {            
            return this;
        }
    }
}
