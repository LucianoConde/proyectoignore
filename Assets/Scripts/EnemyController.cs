using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyClass
{
    Passive,
    Aggressive,
}
public enum EnemyBehaviour
{
    PlayerChase,
    Kamikaze,
    LookAt,
}
public  class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] public PlayerController playerController;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private Transform ExplosionPosition;
    [SerializeField] private PlayerController m_Target;

    [Header("EnemySelection")]
    [SerializeField] EnemyClass enemyType;
    [SerializeField] EnemyBehaviour enemyBehaviour;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [Header("Raycast")]
    [SerializeField] private Transform raycast;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask raycastLayer;
    [Header("Health")]
    [SerializeField] private float maxLife;
    [SerializeField] private float currentLife;
    [SerializeField] private float stopChaseAt = 2f;
    [SerializeField] private float timeToStart;
    [SerializeField] private float initialTime;
    [SerializeField,HideInInspector] private float currentTime;
    private void Awake()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        m_Target = GameObject.FindObjectOfType<PlayerController>();
        currentTime = initialTime;
        switch (enemyType)
        {
            case EnemyClass.Passive:
                maxLife = 10f;
                speed = 2f;
                break;

            case EnemyClass.Aggressive:
                maxLife = 100f;
                transform.localScale *= 3;
                speed = -10f;
                break;
        }
       
        currentLife = maxLife;
        
       
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Gun"))
        {
            Instantiate(Explosion,ExplosionPosition.position,ExplosionPosition.rotation);
            
            
            GetDamage();
        }
        
        if (Other.CompareTag("EnemyLimit"))
        {
            Destroy(gameObject);
        }
    }
    
   
    void Update()
    {
        
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= timeToStart)
        {
             m_animator.SetBool("Start", true);
            if (currentLife <= 0)
            {
                Destroy(gameObject);
                 GameManager.Instance.scorePoints += 10;
                Debug.Log("+10-----Puntaje Total=" + GameManager.Instance.scorePoints);
            }
            bool playerSpot = Physics.Raycast(raycast.position, raycast.forward, out RaycastHit hitInfo, maxDistance, raycastLayer);
            if (playerSpot)
            {
                enemyBehaviour = EnemyBehaviour.LookAt;
            }
            else
            {
                switch (enemyBehaviour)
                {
                    case EnemyBehaviour.Kamikaze:
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        break;

                    case EnemyBehaviour.PlayerChase:
                        if (playerController.itIsDead == false && !playerSpot)
                        {
                            Chase();
                            Look();
                        }

                        else
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                            speed = 2f;
                        }

                        break;
                    case EnemyBehaviour.LookAt:
                        if (playerSpot)
                        {
                            Look();
                        }
                        
                        break;
                }
            }
          
            
        }
       
        
    }
  
    protected void EnemyMovement(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void Chase()
    {
        var distanceDif = m_Target.transform.position - transform.position;
        if (stopChaseAt < distanceDif.magnitude)
        {
            EnemyMovement(distanceDif.normalized);
            Quaternion newRotation = Quaternion.LookRotation(distanceDif.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }
     
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycast.position, raycast.position + raycast.forward* maxDistance);
    }
    private void Look()
    {
        transform.LookAt(m_Target.transform.position);
    }
    private void GetDamage()
    {
        currentLife -= 10;
    }
}
