using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    [HideInInspector] private float health               ;
    [HideInInspector] private float fov                  ;

    [SerializeField] Camera         fpsCam               ;
    [SerializeField] PlayerData     playerData           ;
    [SerializeField] LineRenderer   stringLine           ;
    [SerializeField] Vector3        stringLineStartPos   , bowStartPos  ;
    [SerializeField] GameObject     bowstring            ;
    [SerializeField] Transform      arrowSpawn           ;
    [SerializeField] StateManager   stateManager         ;

    [SerializeField] public float   damage, range = 200f ;
    [SerializeField] private float  maxDamage     = 50f  , maxFov = 90f ;
    [SerializeField] private float  damageRate    = 40f  ;
    [SerializeField] private float  fovRate       = 5.0f ;
 
    [SerializeField] GameObject     arrow;


    private void Awake()
    {
        
        health = playerData.playerHealth;  
        stringLineStartPos = stringLine.GetPosition(1);
        bowStartPos = bowstring.transform.position;
    }
    private void Update()
    {
        if(stateManager.currentState.name  == "Launch Arrow")
        {
            damage = 0;
        }

        if(Input.GetButton("Fire1") && stateManager.currentState.name != "Launch Arrow")
        {
            if (damage <= maxDamage)
            {
                damage += Time.deltaTime * damageRate;
            }
        }

        else
        {
            
            fpsCam.fieldOfView = Mathf.Lerp(fpsCam.fieldOfView, maxFov, Time.deltaTime * fovRate);
            stringLine.SetPosition(1, new Vector3(stringLineStartPos.x, stringLineStartPos.y, stringLineStartPos.z));
            bowstring.transform.position = bowStartPos;
        }   
    }







    
}
