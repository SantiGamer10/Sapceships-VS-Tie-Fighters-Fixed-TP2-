using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement characterMovement;
    [SerializeField] private PlayerShoot laser;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        Debug.Log($"{gameObject.name}: Flying");
    }
    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        characterMovement.SetDirection(inputValue);
        Debug.Log($"{gameObject.name}: Movement Event risen. Value: {inputValue}");
    }

    public void SetShootingValue(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            if (laser == null)
            {
                Debug.LogError($"{name}: Laser is null!");
                return;
            }
            laser.Shoot();
        }
    }
}
