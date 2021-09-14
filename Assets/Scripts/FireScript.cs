using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] public float damage, range = 200f;
    [SerializeField] Camera fpsCam;
    private float health;
    [SerializeField] PlayerData playerData;
    private float fov;
    [SerializeField] LineRenderer stringLine;
    [SerializeField] Vector3 stringLineStartPos,bowStartPos;
    [SerializeField] GameObject bowstring;
    [SerializeField] Transform arrowSpawn;
    [SerializeField] StateManager stateManager;

    
    
    [SerializeField] private GameObject arrow;


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
            if (damage <= 50)
            {
                damage += Time.deltaTime * 50;
            }
        }

        else
        {
            
            fpsCam.fieldOfView = Mathf.Lerp(fpsCam.fieldOfView, 90, Time.deltaTime * 5);
            stringLine.SetPosition(1, new Vector3(stringLineStartPos.x, stringLineStartPos.y, stringLineStartPos.z));
            bowstring.transform.position = bowStartPos;
        }   
    }







    
}
