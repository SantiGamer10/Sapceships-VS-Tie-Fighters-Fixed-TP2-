using UnityEngine;

public class DestroyWhenLeavingScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if (transform.position.y < -7 || transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }
}
