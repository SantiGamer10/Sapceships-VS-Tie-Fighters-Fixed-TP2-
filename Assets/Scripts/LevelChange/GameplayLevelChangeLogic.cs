using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLevelChangeLogic : MonoBehaviour
{
    [SerializeField] private List<HealthPoints> enemiesListCount = new List<HealthPoints>();
    [SerializeField] private GameObject levelChangeShip;

    private int enemiesEliminated = 0;

    private void Awake()
    {
        if (enemiesListCount.Count == 0)
        {
            Debug.LogError($"{name}: enemies list is empty\n Check this assignment list\n disable component");
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        for (int i = 0; i < enemiesListCount.Count; i++)
        {
            enemiesListCount[i].DeathEvent += CountLogic;
        }
    }

    private void CountLogic()
    {
        enemiesEliminated++;
        Debug.Log($"{enemiesEliminated}");

        if (enemiesListCount.Count == enemiesEliminated)
        {
            levelChangeShip.SetActive(true);
        }
    }
}
