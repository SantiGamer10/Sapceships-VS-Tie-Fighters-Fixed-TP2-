using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheatsManager : MonoBehaviour
{
    private Action InvincibleEvent;
    private Action SpeedMultiplierEvent;

    [SerializeField] private PlayerMovement characterMovement;
    [SerializeField] private HealthPoints healthPoints;
    [SerializeField] private List<HealthPoints> enemiesListCount = new List<HealthPoints>();
    [SerializeField] private int AOEDamageValue = 5;

    public void Awake()
    {
        if (!healthPoints)
        {
            Debug.LogError("player has no HP");
        }

        if (enemiesListCount == null)
        {
            Debug.LogError($"{name}: enemies list is empty\n Check this assignment list\n disable component");
            enabled = false;
            return;
        }
    }

    public void Start()
    {
        InvincibleEvent = healthPoints.GetVulnerabilityChangeLogic();
        SpeedMultiplierEvent = characterMovement.GetSpeedChangeLogic();
    }

    public void SetInvulnerabilityState(InputAction.CallbackContext inputContext)
    {
        Debug.Log("Invulnerability Cheat Activated");

        if (inputContext.started)
        {
            InvincibleEvent?.Invoke();
        }
    }

    public void SetDamageAOE(InputAction.CallbackContext inputContext)
    {
        Debug.Log("Damage AOE cheat Activated");

        if (inputContext.started)
        {
            DoDamageInArea();
        }
    }

    public void SetMovementSpeed(InputAction.CallbackContext inputContext)
    {
        Debug.Log("Speed Multiplier Cheat Activated");

        if (inputContext.started)
        {
            SpeedMultiplierEvent?.Invoke();
        }
    }

    public void DoDamageInArea()
    {
        for (int i = 0; i < enemiesListCount.Count; i++)
        {
            enemiesListCount[i].TakeDamage(AOEDamageValue);
        }
    }
}
