using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    // use the server path of your json file here
    private string url = "http://localhost/senac_aulas/senac_aulas_exemplos/grad_gsd/ex_json_php/data.json";
    public string json;
    public byte[] data;
    
    void Start()
    {
        // persists the data
        DontDestroyOnLoad(this);
        StartCoroutine("LoadDataFromJson");
    }

    IEnumerator LoadDataFromJson()
    {
        // load data from file
        UnityWebRequest www = UnityWebRequest.Get(url);
        // bypass https security (for http only if your server do not support https)
        www.certificateHandler = new ByPassHTTPSCertificate();
        // wait for page response
        yield return www.SendWebRequest();
        // if the page do not laod
        if(www.result != UnityWebRequest.Result.Success)
        {
            // handle the error
            Debug.Log(www.error);
        }
        else
        {
            // example from https://stackoverflow.com/questions/66683347/parsing-json-from-api-url-in-unity-via-c-sharp by Art Zolina III
            // get results as text
            json = www.downloadHandler.text;
            //Debug.Log(json);
            // results as binary data
            data = www.downloadHandler.data;
            SceneManager.LoadScene("Main");
        }
    }
}
