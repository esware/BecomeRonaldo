using System;
using System.Collections;
using System.Collections.Generic;
using Dev.Scripts.Character.PlayerStates;
using Managers;
using UnityEngine;

namespace Dev.Scripts
{
    public class CameraContoller : MonoBehaviour
    {
        [SerializeField] private AnimationCurve cameraMoveCurve;
        [SerializeField] private float duration = 10f;


        private Animator _animator;

        private void Awake()
        {
            SignUpEvents();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _animator = GetComponent<Animator>();
            _animator.Play("Idle",0);
        }

        void SignUpEvents()
        {
            GameEvents.RunEvent += PlayerRunState;
        }

        private void PlayerRunState()
        {
            _animator.Play("RunCam",0);
        }


        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                //_animator.Play("ShootCam",0);
            }
                
        }

        /*private IEnumerator CameraMove(Camera targetCam)
        {
            var t = 0f;

            while (t<duration)
            {
                var d = cameraMoveCurve.Evaluate(t / duration);
                
                mainCam.transform.position=  Vector3.Lerp(mainCam.transform.position,targetCam.transform.position,d);
                mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation,targetCam.transform.rotation,d);
                
                t += Time.deltaTime;
                yield return null;
            }
            mainCam.gameObject.SetActive(false);
            targetCam.gameObject.SetActive(true);
        }*/
    }
}