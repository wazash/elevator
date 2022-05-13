using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCatcher : MonoBehaviour
{
    [SerializeField] GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(parent.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
