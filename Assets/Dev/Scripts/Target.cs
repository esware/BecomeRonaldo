using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameEvents.WinEvent?.Invoke();
    }
}
