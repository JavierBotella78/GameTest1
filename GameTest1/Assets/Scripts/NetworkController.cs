using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());
    }

    /*IEnumerator GetTexts()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            StartCoroutine(GetText());
        }
    }*/
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://catfact.ninja/fact");

        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }


    }

    IEnumerator PostText()
    {
        UnityWebRequest www = UnityWebRequest.Post("https://catfact.ninja/fact", "Test");

        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Post success
            Debug.Log("Success");
        }


    }
}
