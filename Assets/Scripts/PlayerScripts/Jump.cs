using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform m_forcePosition;
    [SerializeField] private Collider m_collider;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float timeToStart;
    [Header("Raycast")]
    [SerializeField] private Transform raycast;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask raycastLayer;
    void Update()
    {
        bool rayHit = Physics.Raycast(raycast.position, raycast.forward, maxDistance, raycastLayer);
        if (rayHit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        timeToStart = Time.time;
        if (timeToStart >= 4)
        {
            m_animator.SetBool("Stand", false);
           

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                m_animator.SetBool("Jumping", true);
                m_rigidBody.AddForceAtPosition(transform.up * jumpForce, m_forcePosition.position, ForceMode.Impulse);
            }
            else
            {
                m_animator.SetBool("Jumping", false);
            }
        }
      
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycast.position, raycast.position + raycast.forward * maxDistance);
    }

}
