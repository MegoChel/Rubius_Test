using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FlipController : MonoBehaviour         //Rename to CardController
{
    public float flipTime = 0.5f;
    public GameObject[] cards;
    public Dropdown dropdown;

    private uint counter = 0;
    private PicLoad _picLoad;
    private bool flipped = false;

    void Start()
    {
        foreach (var item in cards)
            item.GetComponent<Flip>().SetFlipTime(flipTime);
    }

    private IEnumerator FlipBack()
    {
        if (flipped)
        {
            foreach (var item in cards)
                item.GetComponent<Flip>().FlipCard();
            yield return new WaitForSeconds(flipTime);
            counter = 0;
            flipped = !flipped;
        }
    }

    private void CountAndFlip()
    {
        counter++;
        if (counter == cards.Length)
            StartCoroutine(FlipAllAtOnce());
    }

    private void LoadAllCard()
    {
        if (counter == 0)
            foreach (var item in cards)
            {
                _picLoad = item.GetComponentInChildren<PicLoad>();
                _picLoad.Load("https://picsum.photos/seed/" + Random.value.ToString() + "/153/212", CountAndFlip);
            }
    }

    private IEnumerator FlipAllAtOnce()
    {
        foreach (var item in cards)
        {
            item.GetComponent<Flip>().FlipCard();
        }
        yield return new WaitForSeconds(flipTime);
        flipped = !flipped;
        gameObject.GetComponent<Button>().interactable = true;
    }
    
    private void FlipOnReady()
    {
            foreach (GameObject item in cards)
                item.GetComponent<Flip>().DownloadAndFlip();
        flipped = !flipped;
        gameObject.GetComponent<Button>().interactable = true;      //Doesnt work correctly
    }

    private IEnumerator OneByOneCoroutine()
    {
        foreach (GameObject item in cards)
            yield return item.GetComponent<Flip>().DownloadAndFlipCoroutine();

        flipped = !flipped;
        gameObject.GetComponent<Button>().interactable = true;
    }

    IEnumerator ButtonClickCoroutine()
    {
        gameObject.GetComponent<Button>().interactable = false;
        yield return StartCoroutine(FlipBack());
        switch (dropdown.value)
        {
            case 0:
                LoadAllCard();
                break;
            case 1:
                StartCoroutine(OneByOneCoroutine());
                break;
            case 2:
                FlipOnReady();
                break;
        }
    }
    public void ButtonClick()
    {
        StartCoroutine(ButtonClickCoroutine());
    }
}
