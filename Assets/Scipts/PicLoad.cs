using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PicLoad : MonoBehaviour
{
    public delegate void ClickAction();
    private ClickAction _callback;

    void Start()
    {
        
    }

    public void Load(string url, ClickAction action)
    {
        _callback = action;
        StartCoroutine(DownloadImage(url));
    }

    public IEnumerator LoadCoroutine(string url, ClickAction action)
    {
        _callback = action;
        yield return StartCoroutine(DownloadImage(url));

    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) 
            Debug.Log(request.error);
        else
        {
            Texture2D text2d = ((DownloadHandlerTexture)request.downloadHandler).texture;
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(text2d, new Rect(0.0f, 0.0f, text2d.width, text2d.height), new Vector2(0.5f, 0.5f));
            _callback?.Invoke();
        }
    }


}
