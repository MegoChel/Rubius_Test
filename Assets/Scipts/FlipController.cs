using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipController : MonoBehaviour
{
    public GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipAllAtOnce()
    {
        foreach (var item in cards)
        {
            item.GetComponent<Flip>().FlipCard();
        }
    }
    public void FlipOneByOne()
    {
        var seq = DOTween.Sequence();
        foreach (var item in cards)
        {
            //seq.Append(item.GetComponent<Flip>().FlipCard());
        }
    }
}
