using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
    [SerializeField] private PlayerController _player;
    public float cantidad = 0.5f;
    private void Start()
    {
        vidaActual = vidaMax;
    }


    void Update()
    {
        RevisarVida();
        
    }


    public void RevisarVida()
    {
        
        imagenBarraVida.fillAmount = 0;
    }
}
