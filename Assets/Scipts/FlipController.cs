using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FlipController : MonoBehaviour
{
    public float flipTime = 0.5f;
    public GameObject[] cards;
    public Dropdown dropdown;
    //private ArrayList readyCards;
    //private ArrayList notReadyCards;
    //private bool onReady = false;
    // Start is called before the first frame update
    void Start()
    {
        //notReadyCards = new ArrayList(cards);

    }

    // Update is called once per frame
    void Update()
    {
        //if(notReadyCards.Count != 0)
        //    foreach (GameObject item in notReadyCards)
        //    {
        //        if (item.tag == "ReadyToFlip")
        //            {
        //                readyCards.Add(item);
        //                notReadyCards.Remove(item);
        //            }
        //    }

    }

    private IEnumerator FlipAllAtOnce()
    {
        gameObject.GetComponent<Button>().interactable = false;
        foreach (var item in cards)
        {
            var seq = DOTween.Sequence();
            item.transform.DORotate((item.transform.eulerAngles + new Vector3(0, 180, 0)), flipTime, RotateMode.Fast);
            seq.Append(item.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), flipTime / 2));
            seq.Append(item.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), flipTime / 2));
            
        }
        yield return new WaitForSeconds(flipTime);
        gameObject.GetComponent<Button>().interactable = true;
    }
    private IEnumerator FlipOneByOne()
    {
        gameObject.GetComponent<Button>().interactable = false;
        var seq = DOTween.Sequence();
        var seqf = DOTween.Sequence();
        foreach (var item in cards)
        {
            seq.Append(item.transform.DORotate((item.transform.eulerAngles + new Vector3(0, 180, 0)), flipTime, RotateMode.Fast));
            seqf.Append(item.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), flipTime / 2));
            seqf.Append(item.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), flipTime / 2));
        }
        yield return seq.WaitForCompletion();
        gameObject.GetComponent<Button>().interactable = true;
    }
    private void FlipOnReady()
    {
        
    }

    public void ButtonClick()
    {
        switch (dropdown.value)
        {
            case 0:
                StartCoroutine(FlipAllAtOnce());
                break;
            case 1:
                StartCoroutine(FlipOneByOne());
                break;
            case 2:
                FlipOnReady();
                break;
        }
         
    }
}
