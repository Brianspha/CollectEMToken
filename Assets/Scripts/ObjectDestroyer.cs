using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private PlatformSpawner platformSpawner;
    private bool deActivated;
    private void Start()
    {
        deActivated = false;
        platformSpawner = GameObject.FindGameObjectWithTag("PlatformSpawner").GetComponent<PlatformSpawner>();
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !deActivated)
        {
            deActivated = true;
            DeActivateObject(other.gameObject);
        }
    }
    private void DeActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
