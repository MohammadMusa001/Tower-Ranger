using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] string playerName;
    [SerializeField] public float playerHealth, playerDamage, playerAttackRange, playerAttackRate;
    private float fov;
    [SerializeField] public LineRenderer stringLine;
    [SerializeField] public Vector3 stringLineStartPos, bowStartPos;
    [SerializeField] public GameObject bowstring;
    [SerializeField] public Transform arrowSpawn;
    [SerializeField] public Camera fpsCam;
}
