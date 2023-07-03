using ClasesRegulares.Clase5;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float sideSpeed;
    [SerializeField,HideInInspector] public bool itIsDead;
    [Header("Health")]
    public float maxHealth = 100f;
    public float _currentHealth;
    public float minHealth = 0f;
    [Header("Animation")]
    [SerializeField] private GameObject Explosion;
    [SerializeField] private Transform ExplosionPosition;
    [SerializeField] private Animator animator;
    [Header("Shuriken")]
    [SerializeField] private Shuriken m_shurikenToShoot;
    [SerializeField] private Transform m_shootingPoint;
    [SerializeField] private float timeToReShoot;
    [SerializeField] private float ShootTime;
    [Header("Time")]
    //[SerializeField] private float timetorethrow;
    [SerializeField] private float timeToStart;
    [SerializeField] private float currentTime;
    [SerializeField] private float redTime;
    [SerializeField] private float hitTimer;
    [SerializeField] private Volume globalVolume;
    private ChannelMixer colorEffect;
    ///////////////////////

    void Awake()
    {
        _currentHealth = maxHealth;
    }
    void Update()
    {
        //evaluates the death case.
        Death();

        //timers 
        
        currentTime += Time.fixedDeltaTime;
        
        //start 
        if (timeToStart<=currentTime && !itIsDead)
        {
            //animator transition
            animator.SetBool("Stand", false);
            //movement
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //inputs
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > Limits.leftSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * sideSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < Limits.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * sideSpeed);
                }
            }
            if (Input.GetButtonDown("Fire1") )
            {
                
                Shoot();
                
            }
        }
    }

    //Damage applyed
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("end"))
        {
            _currentHealth = 0;
        }
        if (Other.CompareTag("Enemy") && !itIsDead)
        {
            Debug.Log("recibí 10 de daño");
            ReceiveDamage();
            hitTimer = currentTime;
            if(!itIsDead)
            {
                Instantiate(Explosion, ExplosionPosition.position, ExplosionPosition.rotation);
            }
            
            if (currentTime >= hitTimer + redTime)
            {
                colorEffect.redOutRedIn.value = 150;
            }
        }
    }

    // Damage Metod
    private void ReceiveDamage()
    {
        _currentHealth -= 10f;
        
    }
    //Death Metod
    public void Death()
    {
        if (_currentHealth <= minHealth)
        {
            animator.SetBool("isDead", true);
            Debug.Log("Death");
            itIsDead = true;
        }
    }

    //Shuriken throw Metod
    private void Shoot()
    {
        if (currentTime >= ShootTime + timeToReShoot)
        {
            ShootTime = currentTime;
            Instantiate(m_shurikenToShoot, m_shootingPoint.position, m_shootingPoint.rotation);
            Debug.Log("shoot");
        }
        
    }
}
