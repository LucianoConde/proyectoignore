using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _score;
    // Update is called once per frame
    void Update()
    {
        _time.text = "Time " + Time.time.ToString();
        //_score.text = "Score " + GameManager.instance.score.ToString();

    }
}
