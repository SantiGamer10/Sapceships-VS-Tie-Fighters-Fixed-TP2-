using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFighterShoot : MonoBehaviour
{
    private float shootTimer = 0f;
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;

    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }
    public void Shoot()
    {
        var laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        var laserMovement = laser.GetComponent<TieFighterLaser>();
        laserMovement.SetDirection(firePoint.up);
    }
}
