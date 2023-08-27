using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject pathPreview;
    [SerializeField] private AnimationCurve movingCurve;
    
    
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
            
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);


        if (Input.GetMouseButton(0))
        {
            pathPreview.transform.position = Vector3.Lerp(pathPreview.transform.position, worldPoint,  movingCurve.Evaluate(1));
        }
    }

    private IEnumerator DoMove(Vector3 targetPosition)
    {
        var duration = 1f;
        var t = 0f;

        while (t<duration)
        {
            pathPreview.transform.position = Vector3.Lerp(pathPreview.transform.position, targetPosition,  movingCurve.Evaluate(t / duration));
            t += Time.deltaTime;
            yield return null;
        }

        pathPreview.transform.position = targetPosition;
    }
}
