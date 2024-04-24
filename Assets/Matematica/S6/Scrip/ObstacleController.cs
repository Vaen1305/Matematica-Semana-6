using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] ObstacleData data; 
    [SerializeField] Transform earthTransform;


    private void Update()
    {

        transform.RotateAround(earthTransform.position, Vector3.right, data.speed * Time.deltaTime);

        
        transform.Rotate(Vector3.up, data.rotationSpeed * Time.deltaTime);
    }
}
