using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float timeStart = 30;
    public TMP_Text textBox;
    void Start()
    {
        textBox.text = timeStart.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        timeStart = Mathf.Clamp(timeStart, 0, timeStart);
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
            if(timeStart < 1)
        {
            StartCoroutine(LevelEndController.Instance.FailLevel());
        }
    }
}
