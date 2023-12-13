using System;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public Action DeathEvent;

    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;

    [SerializeField] private bool shouldDestroyOnDeath;
    [SerializeField] private bool isEnemy;

    private bool isVulnerable = true;
    private bool gameOver = true;
    //[SerializeField] private float waitForDestroy = 0.5f;

    public void Start()
    {
        HP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (isVulnerable)
        {
            HP -= damage;
        }

        if (isEnemy && damage == 1)
        {
            HP -= damage;
            gameOver = false;
        }

        if (shouldDestroyOnDeath && HP <= 0)
        {
            Destroy(gameObject);
            
        }

        if (HP <= 0)
        {
            DeathEvent?.Invoke();
            gameObject.SetActive(false);
            gameOver = true;
        }
    }

    private void ChangeVulnerability()
    {
        isVulnerable = !isVulnerable;
    }

    public Action GetVulnerabilityChangeLogic()
    {
        return ChangeVulnerability;
    }
}
