using System.Collections;
using System.Collections.Generic;
using Managers;
using Ricimi;
using UnityEngine;

public class FailTarget : MonoBehaviour
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
        Transition.LoadLevel("TestScene",0.7f,Color.white);
    }
}
