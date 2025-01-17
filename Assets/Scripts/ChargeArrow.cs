using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeArrow : State
{
    public LaunchArrow  launchArrow        ;
    public GameObject   arrowToBeCharged   ;
    public float        damage             ;
    public Camera       fpsCam             ;
    public LineRenderer stringLine         ;
    public GameObject   bowNString         ;
    public Transform    arrowSpawn         ;
    public FireScript   fireScript         ;
    public Vector3      stringLineStartPos ;
    public GameObject   arrow              ;

    private ObjectPooler objectPooler      ;


    [SerializeField] private float
        
                     fovRate             = 40   , bowAndArrowRate    =  2.0f ,
                     minFov              = 50   , stringLineMinPos   = -0.4f , 
                     arrowSpawnMinPos    = 2.1f , bowAndStringMinPos = -1.5f ,
                     arrowDeactivateTime = 3    ;
                        


    private void Awake()
    {
        stringLineStartPos = stringLine.GetPosition(1);    
    }

    private void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();           
    }
    public override State RunCurrentState()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            if(arrowToBeCharged != null)
            {
                damage = fireScript.damage;
                arrowToBeCharged.GetComponent<ArrowScript>().arrowDamage = damage;
                Vector3 force = arrowSpawn.TransformDirection(Vector3.forward * damage);
                arrowToBeCharged.GetComponent<Rigidbody>().isKinematic = false;
                arrowToBeCharged.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                arrowToBeCharged.GetComponent<TrailRenderer>().enabled = true;
                fireScript.isReloading = false;

                StartCoroutine(DeactivateArrow(arrowToBeCharged));
                launchArrow.arrowToBeLaunched = arrowToBeCharged;
            }

            return launchArrow;
        }

        else
        {
            if((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1")))
            {
                if(arrowToBeCharged != null)
                {
                    ChargeShot();
                }
                             
            }

            return this;
        }
    }

    private void ChargeShot()
    {
        fireScript.isReloading = true;

        if (fpsCam.fieldOfView >= minFov)
        {
            fpsCam.fieldOfView -= Time.deltaTime * fovRate;
        }

        if (stringLine.GetPosition(1).x >= stringLineMinPos)
        {
            stringLine.SetPosition(1, new Vector3((stringLine.GetPosition(1).x - 
                Time.deltaTime), stringLineStartPos.y, stringLineStartPos.z));
        }

        arrowToBeCharged.transform.position = arrowSpawn.position;
        arrowToBeCharged.transform.rotation = arrowSpawn.rotation;
        if (arrowSpawn.localPosition.x >= arrowSpawnMinPos)
        {
            arrowSpawn.Translate(Vector3.back * Time.deltaTime * bowAndArrowRate);
        }
        if (bowNString.transform.localPosition.x >= bowAndStringMinPos)
        {
            bowNString.transform.Translate(Vector3.left * Time.deltaTime * bowAndArrowRate);
        }
    }

    IEnumerator DeactivateArrow(GameObject arrowToBeDeactivated)
    {
        yield return new WaitForSeconds(arrowDeactivateTime);
        objectPooler.ReturnObjectToThePool(arrowToBeDeactivated);
    }
}
