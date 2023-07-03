using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : MonoBehaviour
{

                     private float initialTime;
    [SerializeField] private float duration;
  
    void Update()
    {
        initialTime += Time.deltaTime;
        if (initialTime > duration)
        {
            Destroy(gameObject);
        }
    }
}
