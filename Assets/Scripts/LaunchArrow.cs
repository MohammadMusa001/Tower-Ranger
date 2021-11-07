using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArrow : State
{ 
    public ChargeArrow   chargeArrow       ;
    public GameObject    arrowToBeLaunched ;
    public GameObject    arrowToBeCreated  ;
    public Camera        fpscam            ;
    public Transform     arrowSpawn        ;
    public float         damage            ;
    public bool          canShootArrow     ;
    private ObjectPooler objectPooler      ;
    
    private float reloadTime = 0.5f;

    private void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        canShootArrow = true;
        Debug.Log("Launch arrow");
    }
    public override State RunCurrentState()
    {
        if (Input.GetButtonDown("Fire1") && canShootArrow && !PauseMenu.isGamePaused)
        {
            arrowToBeCreated = objectPooler.GetObjectToBePooled(arrowToBeCreated);
            if(arrowToBeCreated !=null)
            {
                arrowToBeCreated.GetComponent<TrailRenderer>().enabled = false;
                arrowToBeCreated.SetActive(true);
                
                arrowToBeCreated.GetComponent<Rigidbody>().isKinematic = true;
                
                chargeArrow.arrowToBeCharged = arrowToBeCreated;
                canShootArrow = false;
                StartCoroutine(Reload());
            }
            
            return chargeArrow;
        }
        else
        {            
            return this;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShootArrow = true;

    }
}
