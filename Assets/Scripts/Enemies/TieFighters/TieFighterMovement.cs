using System;
using UnityEngine;

public class TieFighterMovement : MonoBehaviour
{
    // Tie fighters are a type of enemies that shoot their lasers and damage the player's ship.
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private float multiplierSpeed = 2f;
    private bool isSpeedMultiplier = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * speed;

        if (isSpeedMultiplier)
        {
            transform.position = transform.position + new Vector3(movementInput.x, movementInput.y) * speed * multiplierSpeed * Time.deltaTime;
        }
        else
            transform.position = transform.position + new Vector3(movementInput.x, movementInput.y) * speed * Time.deltaTime;
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
                                smoothedMovementInput,
                                movementInput,
                                ref movementInputSmoothVelocity,
                                0.1f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AsteroidMovement asAsteroid = other.GetComponent<AsteroidMovement>();
        if (asAsteroid != null)
        {
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector2 direction)
    {
        movementInput = direction;
    }

    public void ChangeSpeed()
    {
        isSpeedMultiplier = !isSpeedMultiplier;
    }

    public Action GetSpeedChangeLogic()
    {
        return ChangeSpeed;
    }
}
