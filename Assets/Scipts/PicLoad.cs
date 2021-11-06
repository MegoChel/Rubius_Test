using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PicLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string url = "https://picsum.photos/seed/" + Random.value.ToString() + "/153/212";
        StartCoroutine(DownloadImage(url));
    }
    public bool isLoaded = false;
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
            isLoaded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoaded)
            transform.root.gameObject.tag = "ReadyToFlip";
    }
}
