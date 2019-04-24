using UnityEngine;
using System.Collections;

public class DestroyedByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}