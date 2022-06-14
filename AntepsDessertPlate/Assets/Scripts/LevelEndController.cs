using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    public static LevelEndController Instance;
    public Animator anim;
    public int WantedSuccesPercentage;
    public int score;
    public GameObject stackParent;
    private bool isCalculeted=false;
    private String tag;
    private bool isFail = false;
    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tezgah"))
        {
            anim.SetBool("isfinish", true);
            if (!isCalculeted)
            {
                CalculateFinish();
            }
        }

        if (isCalculeted&&isFail)
        {
            SetColor(Color.red);
        }
    }

    public void CalculateFinish()
    {
      
        int totalobject = stackParent.transform.childCount;
        for (int i = 0; i < stackParent.transform.childCount; i++)
        {
            tag = stackParent.transform.GetChild((i)).tag;
            if (tag == "Bake")
            {
                score +=1;
                stackParent.transform.SetParent((null));
            }
        }

        int result = score * 100 / totalobject;
        if (result >= WantedSuccesPercentage)
        {
            anim.SetBool("issucces", true);
            StartCoroutine(FinishLevel());

        }
        else
        {
            anim.SetBool("isfail", true);
            isFail = true;
            StartCoroutine(FailLevel());
        }
        if (result - WantedSuccesPercentage >= 30 && result - WantedSuccesPercentage <= 50)
        {
            UIManager.Instance.finalText2.text = "Good";
        }
        else if (result - WantedSuccesPercentage >= 20 && result-WantedSuccesPercentage<=30)
        {
            UIManager.Instance.finalText2.text = " Very Good";
        }
        else if (result - WantedSuccesPercentage >= 5 && result - WantedSuccesPercentage <= 19)
        {
            UIManager.Instance.finalText2.text = " Perfect";
        }


        isCalculeted = true;
    }

    public void SetColor(Color playerColor)
    {
        GameObject customer = anim.gameObject.transform.GetChild((0)).gameObject;
        customer.GetComponent<SkinnedMeshRenderer>().material.color=Color.Lerp(Color.white, playerColor, Mathf.PingPong(Time.time, 1));
        GameObject canvas = anim.gameObject.transform.GetChild(2).gameObject;
        canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public IEnumerator FinishLevel()
    {
        UIManager.Instance.orderlist.SetActive(false);
        UIManager.Instance.SetLevel();
        AudioManager.Instance.happy.Play();
        yield return new WaitForSeconds(2f);
        UIManager.Instance.FinalCanvas.SetActive((true));
        Time.timeScale = 0f;
    }
    public IEnumerator FailLevel()
    {
        AudioManager.Instance.yell.Play();
        yield return new WaitForSeconds(2f);
        UIManager.Instance.orderlist.SetActive(false);
        UIManager.Instance.FailCanvas.SetActive((true));
        Time.timeScale = 0f;
    }
}
