using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private Transform raycast;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask raycastLayer;
   
    
    void Update()
    {
    //    bool  rayHit = Physics.Raycast(raycast.position, raycast.forward, maxDistance, raycastLayer);

    //    if (rayHit)
    //    {
    //        jump.isGrounded = true;
    //    }
    //    else
    //    {
    //        jump.isGrounded= false;
    //    }

    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(raycast.position, raycast.position + raycast.forward * maxDistance);
    //}
    }
}
