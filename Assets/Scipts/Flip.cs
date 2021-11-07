using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip : MonoBehaviour
{
    private PicLoad _picLoad;
    private float flipTime;
    // Start is called before the first frame update
    void Start()
    {
        _picLoad = gameObject.GetComponentInChildren<PicLoad>();

    }

    public void DownloadAndFlip()
    {
        _picLoad.Load("https://picsum.photos/seed/" + Random.value.ToString() + "/153/212", FlipCard);
    }

    public void SetFlipTime(float t)
    {
        flipTime = t;
    }

    public IEnumerator DownloadAndFlipCoroutine()
    {
        yield return _picLoad.LoadCoroutine("https://picsum.photos/seed/" + Random.value.ToString() + "/153/212", FlipCard);
    }
    public void FlipCard()
    {
        var seq = DOTween.Sequence();
        transform.DORotate((transform.eulerAngles + new Vector3(0, 180, 0)), flipTime, RotateMode.Fast);
        seq.Append(transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), flipTime / 2));
        seq.Append(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), flipTime / 2));
    }
}
