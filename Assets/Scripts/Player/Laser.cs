using UnityEngine;
using UnityEngine.InputSystem;
public class Laser : MonoBehaviour
{
    [SerializeField] public Vector2 speed;
    private Vector2 _direction;
    private void Start()
    {
        // Add this line to give the laser an initial velocity
        GetComponent<Rigidbody2D>().velocity = _direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AsteroidMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
