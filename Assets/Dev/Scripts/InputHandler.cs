using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dev.Scripts
{
    public class InputHandler : MonoBehaviour
    {

        private Vector3 _mousePosition;
        private Vector3 _worldPoint;
        private Camera _mainCam;

        private Vector3 tempPosition;
        
        public TrailRenderer trail ;
        public Rigidbody ballRigidbody;
        public float shotForce;
        public float falsoForce;

        private int index = 0;

        private void Awake()
        {
            _mainCam = FindObjectOfType<Camera>();
        }
        
        public List<Vector3> pathPoints = new List<Vector3>();
        public List<Vector3> shortestPoints = new List<Vector3>();
        public List<GameObject> spheres = new List<GameObject>();

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10f;
                Vector3 worldPosition = _mainCam.ScreenToWorldPoint(mousePosition);
                
                if (Mathf.Abs(Vector2.Distance(worldPosition,tempPosition)) > 0.5f)
                {
                    pathPoints.Add(worldPosition);
                    tempPosition = worldPosition;
                }
                
                trail.transform.position = worldPosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
               SetPathWorldPosition();
               /*CreateSpheres(spheres,pathPoints);
               CreateSpheres(spheres,GetShortestPath());
               
               GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
               obj.transform.localScale = Vector3.one * 0.8f;
               obj.GetComponent<Collider>().isTrigger = true;
            
               var big =Instantiate(obj, GetBiggerVector(), Quaternion.identity);
               big.GetComponent<Renderer>().material.color=Color.blue;
               spheres.Add(big);*/
               
               trail.Clear();
               trail.gameObject.SetActive(false);

               if (pathPoints.Count < 3)
               {
                   pathPoints.Clear();
                   return;
               }

               StartCoroutine(Shot());
            }

            if (Input.GetMouseButtonDown(0))
            {
                pathPoints.Clear();
                shortestPoints.Clear();
                trail.gameObject.SetActive(true);
            }

            if (Input.GetMouseButtonDown(1))
            {
                ResetBall();
            }

        }
        
        private IEnumerator Shot()
        {
            ballRigidbody.isKinematic = false;

            var endPosition = pathPoints[^1];
            var firstForce = (GetBiggerVector()-ballRigidbody.transform.position).normalized;
            
            var duration = 1f;
            var t = 0f;
            ballRigidbody.AddForce(firstForce*shotForce,ForceMode.Impulse);
            var falsoPosition = GetBiggerVector();

            while (t<duration)
            {
                var secondForce = (endPosition-falsoPosition).normalized;
                secondForce.z = 0f;

                ballRigidbody.AddForce(secondForce*falsoForce,ForceMode.Impulse);

                t += Time.deltaTime;

                if (ballRigidbody.transform.position.z>30)
                {
                    yield break;
                }
                
                yield return null;
            }
        }

        private Vector3 GetBiggerVector()
        {
            GetShortestPath();
            var distance=0f;
            Vector3 tempPoint=new Vector3();

            for (int i = 0; i < pathPoints.Count-1; i++)
            {
                if (Vector3.Distance(pathPoints[i],shortestPoints[i])>distance)
                {
                    distance = Vector3.Distance(pathPoints[i], shortestPoints[i]);
                    tempPoint = pathPoints[i];
                }
            }
            
            return tempPoint;
        }

        private List<Vector3> GetShortestPath()
        {
            int numberOfPoints = pathPoints.Count;

            Vector3 startPoint = pathPoints[0];
            Vector3 endPoint = pathPoints[numberOfPoints - 1];

            float step = 1f / (numberOfPoints - 1);

            for (float t = 0; t <= 1; t += step)
            {
                Vector3 point = Vector3.Lerp(startPoint, endPoint, t);
                shortestPoints.Add(point);
            }

            return shortestPoints;
        }

        private void CreateSpheres(List<GameObject> spheresList,List<Vector3> positionList)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.localScale = Vector3.one * 0.3f;
            obj.GetComponent<Collider>().isTrigger = true;

            foreach (var p in positionList)
            {
                var c =Instantiate(obj, p, Quaternion.identity);
                spheresList.Add(c);
            }
        }

        private void SetPathWorldPosition()
        {
            int pointDistance = 40/pathPoints.Count;
                
            for (int i = 0; i < pathPoints.Count; i++)
            {

                float xMultiplier = (i+1)*3f / pathPoints.Count;
                    
                Vector3 adjustedPosition = new Vector3(pathPoints[i].x * xMultiplier, pathPoints[i].y * xMultiplier/3, pointDistance * i + 1);
                var p = adjustedPosition;

                if (p.y < 0)
                {
                    p.y = 0.5f;
                }

                pathPoints[i] = p;
            }
        }


        private void ResetBall()
        {
            foreach (var s in spheres)
            {
                Destroy(s.gameObject);
            }
            spheres.Clear();
            
            var ballTransform = ballRigidbody.transform;
                            
            ballTransform.rotation =Quaternion.identity;
            ballTransform.position = new Vector3(0, 1, 0);
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.isKinematic = true;
        }

    }
}