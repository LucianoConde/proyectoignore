using System;
using UnityEngine;

namespace ClasesRegulares.Clase5
{
    public class Shuriken : MonoBehaviour
    {
        [SerializeField] private float m_speed = 5;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float lifeTime;
        [SerializeField] private float currentTime;
        private void Update()
        {
            transform.position += transform.forward * m_speed *Time.deltaTime;
            currentTime += Time.deltaTime;
            if (currentTime > lifeTime)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter(Collider Other)
        {
            if (Other.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}