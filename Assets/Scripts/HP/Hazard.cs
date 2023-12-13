using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject playerGameObject = other.gameObject;
        HealthPoints playerHP = playerGameObject.gameObject.GetComponent<HealthPoints>();

        if (playerHP)
        {
            playerHP.TakeDamage(damage);
        }
        else
        {
            Debug.LogError(message: $"{name}: PlayerHP is null!");
        }
    }
}
