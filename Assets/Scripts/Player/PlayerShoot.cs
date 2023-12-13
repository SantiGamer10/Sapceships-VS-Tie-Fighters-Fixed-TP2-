using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShots;

    private bool fireContinuously;
    private bool fireSingle;
    private float lastFireTime;

    public void Fire(InputAction.CallbackContext context)
    {
        fireContinuously = context.ReadValueAsButton();

        if (fireContinuously && !fireSingle)
        {
            fireSingle = true;
            Shoot();
        }
    }

    private void FireCanceled()
    {
        fireContinuously = false;
    }

    public void Shoot()
    {
        var laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        var laserMovement = laser.GetComponent<Laser>();
        laserMovement.SetDirection(firePoint.up);
    }

    private void FixedUpdate()
    {
        if (fireContinuously || fireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if (timeSinceLastFire >= timeBetweenShots)
            {
                lastFireTime = Time.time;
                fireSingle = false;
            }
        }
    }
}
