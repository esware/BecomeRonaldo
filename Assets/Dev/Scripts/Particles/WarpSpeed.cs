using UnityEngine;
using System.Collections;

public class WarpSpeed : MonoBehaviour {
	
    //#########################################
    //This script is not working, needs some fixes.
	
    /*
    public float WarpDistortion;
    public float Speed;
    
    private ParticleSystem _particleSystem;
    private ParticleSystemRenderer _particleSystemRenderer;

    private void Awake()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystemRenderer = _particleSystem.GetComponent<ParticleSystemRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Engage();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Disengage();
        }
        _particleSystemRenderer.velocityScale += WarpDistortion * (Time.deltaTime * Speed);
    }

    public void Engage()
    {
        _particleSystem.Play();
        WarpDistortion = Mathf.Abs(WarpDistortion);
    }

    public void Disengage()
    {
        WarpDistortion = -Mathf.Abs(WarpDistortion);
    }

    bool atWarpSpeed()
    {
        return _particleSystemRenderer.velocityScale < WarpDistortion;
    }

    bool atNormalSpeed()
    {
        return _particleSystemRenderer.velocityScale > 0;
    }
    */
}