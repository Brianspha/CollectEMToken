using UnityEngine;

public class EndDetector : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Token"))
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }
}
