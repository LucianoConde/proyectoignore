using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;
    public static GameManager Instance;
    [SerializeField] Canvas gameOver;
    [SerializeField] Canvas lossgameOver;
    [SerializeField] Canvas UI;
    [SerializeField] public float maxLife;
    [SerializeField] public float speed;
    [SerializeField] public float scorePoints = 0;
    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if (scorePoints > 150)
        {
            gameOver.enabled = true;
            UI.enabled = false;
        }
       if (playerController._currentHealth <= 0)
        {
            lossgameOver.enabled = true;
            UI.enabled = false;
        }
    }
}
