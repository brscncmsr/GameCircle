using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public GameObject stackParent;
    public GameObject stackParentPrefab;
    public GameObject dropParent;
    public Transform x, y;
    public Transform a, b;
    public List<GameObject> desserts = new List<GameObject>();
    public List<GameObject> dropList = new List<GameObject>();
    public GameObject dabag;
    public GameObject stackParentPlace;

    private void Awake()
    {
        stackParentPlace = transform.GetChild(3).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bake") || other.CompareTag("Fail"))
        {
            if(dabag.activeSelf)
                AddStack(other.gameObject);
            AudioManager.Instance.collect.Play();
        }

        if (other.gameObject.CompareTag("Plate"))
        {
            Destroy(other.gameObject);
            dabag.SetActive(true);
            AudioManager.Instance.collect.Play();
        }

        if (other.gameObject.CompareTag("Block"))
        {
            FailDropStack(desserts[desserts.Count-1].gameObject);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tezgah"))
        {
            if (stackParent.transform.childCount == 0)
            {
                StartCoroutine(LevelEndController.Instance.FailLevel());
                AudioManager.Instance.yell.Play();
                LevelEndController.Instance.anim.SetBool("isfail", true);
            }
            if (desserts.Count != 0)
            {
                DropStack(desserts[desserts.Count - 1].gameObject);
                AudioManager.Instance.collect.Play();

            }
        }
    }
    void FailDropStack(GameObject bake)
    {
        dropList.Add(bake);
        bake.gameObject.CompareTag("Untagged");
        bake.AddComponent<BoxCollider>();
        Destroy(bake.GetComponent<BoxCollider>());
        desserts.Remove(bake);
        // bake.transform.SetParent(dropParent.transform);
        int index = desserts.IndexOf(bake);
        // newDropPlace = new Vector3(dropParent.transform.position.x, dropParent.transform.position.y + index,
        //   dropParent.transform.position.z);
        //StartCoroutine(MoveBack(bake.transform, a.transform, b.transform, dropParent.transform, index));
        bake.GetComponent<BoxCollider>().enabled = false;
        //dropList[dropList.Count - 1].transform.position = new Vector3(dropList[dropList.Count - 1].transform.position.x,
        //dropList[dropList.Count - 1].transform.position.y + 1, dropList[dropList.Count - 1].transform.position.z);
        Destroy(bake);
    }

    void DropStack(GameObject bake)
    {
        dropList.Add(bake);
        bake.gameObject.CompareTag("Untagged");
        bake.AddComponent<BoxCollider>();
        Destroy(bake.GetComponent<BoxCollider>());
        desserts.Remove(bake);
       // bake.transform.SetParent(dropParent.transform);
        int index = desserts.IndexOf(bake);
        // newDropPlace = new Vector3(dropParent.transform.position.x, dropParent.transform.position.y + index,
         //   dropParent.transform.position.z);
        //StartCoroutine(MoveBack(bake.transform, a.transform, b.transform, dropParent.transform, index));
        bake.GetComponent<BoxCollider>().enabled = false;
        //dropList[dropList.Count - 1].transform.position = new Vector3(dropList[dropList.Count - 1].transform.position.x,
            //dropList[dropList.Count - 1].transform.position.y + 1, dropList[dropList.Count - 1].transform.position.z);
            stackParent.transform.position = dropParent.transform.position;
            stackParent.transform.SetParent(dropParent.transform);
    }
    void AddStack(GameObject cyc)
    {
     
        Destroy(cyc.GetComponent<BoxCollider>());
        desserts.Add(cyc);
        cyc.transform.SetParent(stackParent.transform);
        int index = desserts.IndexOf(cyc);
        StartCoroutine(MoveBack(cyc.transform,x.transform,y.transform, stackParent.transform,index));
      //  cyc.transform.position = stackParent.transform.position;
      //  cyc.GetComponent<BoxCollider>().enabled = false;
      
    }

    IEnumerator MoveBack(Transform eTransform,Transform a, Transform b,Transform backTransform,int index)
    {
   
        //eTransform.position = backTransform.position;
        float elapsedTime = 0;
        float waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            
            //eTransform.position = Vector3.Lerp(eTransform.position, new Vector3(backTransform.position.x,(float) (stackParent.position.y + index * 0.6),backTransform.position.z), (elapsedTime / waitTime));
            eTransform.position = Vector3.Lerp(eTransform.position,
                a.position, (elapsedTime / waitTime));
            eTransform.position = Vector3.Lerp(eTransform.position, b.position, (elapsedTime / waitTime));
            eTransform.position = Vector3.Lerp(eTransform.position, a.position, (elapsedTime / waitTime));
            eTransform.position = Vector3.Lerp(eTransform.position, new Vector3(backTransform.position.x,(float) (stackParent.transform.position.y + index * 0.6),backTransform.position.z), (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
 
            // Yield here
            yield return null;
        }  
        // Make sure we got there
        yield return null;
    }
   
}
