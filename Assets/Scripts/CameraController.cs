using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************
 * Component of the Main Camera that keeps it
 * a constant distance from the vehicle
 * 
 * Logan Rudsenske
 * September 11 2023, Version 1
 ******************************************/

public class CameraController : MonoBehaviour
{
    [Tooltip("Drag Vehicle onto Vehicle Transform")]
    [SerializeField] private Transform vehicleTransform; // to keep track of vehicle's position
    private Vector3 offset;                              // distance camera is from vehicle

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 10, -10);
    }

    // Update is called once per frame just after Update
    void LateUpdate()
    {
        transform.position = vehicleTransform.position + offset;
    }
}
