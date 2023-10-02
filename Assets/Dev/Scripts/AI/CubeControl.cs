using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeControl : MonoBehaviour
{
    public static Action cubeDestroyEvent;

    private void OnTriggerEnter(Collider other)
    {
        cubeDestroyEvent?.Invoke();
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
