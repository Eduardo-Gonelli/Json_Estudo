using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// @author: https://github.com/Eduardo-Gonelli
/// Last Update: 2023/09/18
/// </summary>

public class DataManager : MonoBehaviour
{
    // evento para carregar os dados
    public delegate void OnDataLoaded(string jsonData);
    public static event OnDataLoaded onDataLoaded;

    // url para receber os dados
    private string url_load_data = "http://localhost/senac_aulas/gsd2023/03_sistema/recuperar.php";
    // url para enviar os dados
    private string url_send_data = "http://localhost/senac_aulas/gsd2023/03_sistema/adicionar.php";
    public string json;
        
    void Start()
    {        
        DontDestroyOnLoad(this); // n�o destroi o objeto ao trocar de cena        
    }

    public void LoadData()
    {
        StartCoroutine("LoadDataFromJson");
        
    }

    IEnumerator LoadDataFromJson()
    {        
        WWWForm form = new WWWForm();
        // adiciona o campo da chave secreta
        form.AddField("chave_secreta", "123456");
        // prepara a requisi��o
        UnityWebRequest www = UnityWebRequest.Post(url_load_data, form);
        // ignora o certificado de seguran�a https (para http apenas se o servidor n�o suportar https)
        www.certificateHandler = new ByPassHTTPSCertificate();
        // envia a requisi��o e aguarda pela resposta        
        yield return www.SendWebRequest();
        // verifica se houve erro na requisi��o
        if(www.result != UnityWebRequest.Result.Success)
        {
            // exibe o erro
            Debug.Log(www.error);
        }
        else
        {
            // exemplo de https://stackoverflow.com/questions/66683347/parsing-json-from-api-url-in-unity-via-c-sharp por Art Zolina III
            // transforma o resultado em um objeto json
            json = www.downloadHandler.text;
            //Debug.Log(json);
            onDataLoaded?.Invoke(json);
        }
    }

    // prepara a inser��o de dados
    public void InsertData(string apelido, int pontos)
    {
        StartCoroutine(InsertNewData(apelido, pontos));
    }

    // envia o formul�rio para o servidor
    IEnumerator InsertNewData(string apelido, int pontos)
    {
        // prepara o formul�rio
        WWWForm form = new WWWForm();
        form.AddField("apelido", apelido);        
        form.AddField("pontos", pontos);        
        // envia o formul�rio para o servidor
        using(UnityWebRequest www = UnityWebRequest.Post(url_send_data, form))
        {
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Novos dados inseridos");
            }
        }
    }
}
