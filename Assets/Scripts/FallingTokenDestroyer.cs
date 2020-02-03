using UnityEngine;

public class FallingTokenDestroyer : MonoBehaviour
{
    public float destroyTime = 2f;

    private void Update()
    {
        if (transform.position.y < 0)
        {
            Invoke("DestroyToken", destroyTime);
        }
    }

    private void DestroyToken()
    {
        Destroy(gameObject);
    }
}
