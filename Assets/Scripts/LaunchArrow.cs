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
    private ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
    }
    public override State RunCurrentState()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            arrowToBeCreated = objectPooler.GetObjectToBePooled(arrowToBeCreated);
            if(arrowToBeCreated !=null)
            {
                arrowToBeCreated.GetComponent<TrailRenderer>().enabled = false;
                arrowToBeCreated.SetActive(true);
                
                arrowToBeCreated.GetComponent<Rigidbody>().isKinematic = true;
                
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
