using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipCard()
    {
        var seq = DOTween.Sequence();
        //seq.Append(transform.DORotate((transform.eulerAngles + new Vector3(0, 90, 0)), 0.5f, RotateMode.Fast));
        //seq.Join(transform.DOScale((transform.localScale * 1.5f), 0.5f));
        //seq.Append(transform.DORotate((transform.eulerAngles + new Vector3(0, 90, 0)), 0.5f, RotateMode.Fast));
        //seq.Join(transform.DOScale((transform.localScale * 2.0f/3.0f), 0.5f));
        transform.DORotate((transform.eulerAngles + new Vector3(0, 180, 0)), 0.5f, RotateMode.Fast);
        seq.Append(transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 0.25f));
        seq.Append(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.25f));
    }
}
