using UnityEngine;

public class GeneralObjectDestroyer : MonoBehaviour
{
    public float destroyDelay = 1f;
    public GameObject parent;
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DestroyObject();
        }
        Debug.Log("OnCollisionEnter GeneralObjectDestroyer: "+other.gameObject.tag);
    }
    private void DestroyObject()
    {
        Destroy(parent, destroyDelay);
    }
}
