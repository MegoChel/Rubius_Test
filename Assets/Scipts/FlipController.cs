using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FlipController : MonoBehaviour         //Переименовать в CardController
{
    public float flipTime = 0.5f;
    public GameObject[] cards;
    public Dropdown dropdown;

    public uint counter = 0;
    private PicLoad _picLoad;
    public bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FlipAllLoadedCards()
    {
        if (counter == cards.Length)
            switch (dropdown.value)
            {
                case 0:
                    StartCoroutine(FlipAllAtOnce());
                    break;
                case 1:
                    StartCoroutine(FlipOneByOne());
                    break;
            }
    }

    private void CountAndFlip()
    {
        counter++;
        FlipAllLoadedCards();
    }

    private IEnumerator LoadAllCard()
    {
        if (counter == 0)
        foreach (var item in cards)
        {
            _picLoad = item.GetComponentInChildren<PicLoad>();
            _picLoad.Load("https://picsum.photos/seed/" + Random.value.ToString() + "/153/212", CountAndFlip);
        }
        yield return null; 
    }

    private IEnumerator FlipAllAtOnce()
    {
        //gameObject.GetComponent<Button>().interactable = false;
        //yield return StartCoroutine(LoadAllCard());
        foreach (var item in cards)
        {
            item.GetComponent<Flip>().FlipCard();
            //var seq = DOTween.Sequence();
            //item.transform.DORotate((item.transform.eulerAngles + new Vector3(0, 180, 0)), flipTime, RotateMode.Fast);
            //seq.Append(item.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), flipTime / 2));
            //seq.Append(item.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), flipTime / 2));

        }
        yield return new WaitForSeconds(flipTime);
        gameObject.GetComponent<Button>().interactable = true;
    }
    private IEnumerator FlipOneByOne()
    {
        //gameObject.GetComponent<Button>().interactable = false;
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
        if (flipped)
            foreach (GameObject item in cards)
                item.GetComponent<Flip>().FlipCard();
        else
            foreach (GameObject item in cards)
                item.GetComponent<Flip>().DownloadAndFlip();
        //flipped = !flipped;
        gameObject.GetComponent<Button>().interactable = true;
    }

    public void ButtonClick()
    {
        gameObject.GetComponent<Button>().interactable = false;
        //if (counter == cards.Length)
        if (dropdown.value == 2)
            FlipOnReady();
        else
            if (!flipped)
                StartCoroutine(LoadAllCard());
            else
            {
                FlipAllLoadedCards();
                counter = 0;
            }
        flipped = !flipped;
        //switch (dropdown.value)
        //{
        //    case 0:
        //        StartCoroutine(FlipAllAtOnce());
        //        break;
        //    case 1:
        //        StartCoroutine(FlipOneByOne());
        //        break;
        //    case 2:
        //        FlipOnReady();
        //        break;
        //}

    }
}
