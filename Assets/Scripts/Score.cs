using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text _TextMeshPro;
    
    // Update is called once per frame
    void Update()
    {
        _TextMeshPro.text = "Score: " + GameManager.Instance.scorePoints.ToString();
    }
}
