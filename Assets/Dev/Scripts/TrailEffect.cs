using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    TrailRenderer trail;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
    }
}
