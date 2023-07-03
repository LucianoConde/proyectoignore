using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
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

        imagenBarraVida.fillAmount = _player._currentHealth / _player.maxHealth;
    }
}
