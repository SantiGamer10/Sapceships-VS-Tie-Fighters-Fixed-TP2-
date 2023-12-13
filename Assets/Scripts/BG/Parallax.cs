using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float spriteHeight;
    private Vector3 startPos;

    private void Awake()
    {
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;

    }
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        BackgroundMovement();
        ResetBackgroundPosition();
    }

    private void BackgroundMovement()
    {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);
    }

    private void ResetBackgroundPosition()
    {
        if (transform.position.y < startPos.y - spriteHeight)
        {
            transform.position = startPos;
        }
    }
}
