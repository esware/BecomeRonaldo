using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUpdater : MonoBehaviour
{
    public NavMeshSurface navMeshSurfaces;
    
    private void Awake()
    {
        SignUpEvents();
    }

    private void SignUpEvents()
    {
        //CubeControl.cubeDestroyEvent += UpdateNavMesh;
    }

    private void Start()
    {
        navMeshSurfaces = FindObjectOfType<NavMeshSurface>();
        navMeshSurfaces.BuildNavMesh();
    }
    
    
}
