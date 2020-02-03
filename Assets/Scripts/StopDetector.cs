using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDetector : MonoBehaviour
{
   public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touching: " + collision.gameObject.tag);
    }
}
