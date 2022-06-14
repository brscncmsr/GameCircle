using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject StartCanvas;
    public GameObject FinalCanvas;
    public GameObject FailCanvas;
    public TextMeshProUGUI finalText;
    public TextMeshProUGUI finalText2;
    public GameObject orderlist;

    private void Awake()
    {
        Instance = this;
    }

    public void SetLevel()
    {
        int text1 = SceneManager.GetActiveScene().buildIndex + 1;
        string op = text1.ToString();
        string output=op.TrimStart('0');
        finalText.text="Level "+ output + " Completed";
    }
}
