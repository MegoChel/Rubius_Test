using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip : MonoBehaviour
{
    private PicLoad _picLoad;
    // Start is called before the first frame update
    void Start()
    {
        _picLoad = gameObject.GetComponentInChildren<PicLoad>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //gameObject.GetComponent<PicLoad>().ca += FlipCard;
        //PicLoad.OnClicked += FlipCard;
    }


    void OnDisable()
    {
        //PicLoad.OnClicked -= FlipCard;
    }
    public void DownloadAndFlip()
    {
        _picLoad.Load("https://picsum.photos/seed/" + Random.value.ToString() + "/153/212", FlipCard);
    }
    public void FlipCard()
    {
        var seq = DOTween.Sequence();
        transform.DORotate((transform.eulerAngles + new Vector3(0, 180, 0)), 0.5f, RotateMode.Fast);
        seq.Append(transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 0.25f));
        seq.Append(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.25f));
    }
}
