using UnityEngine;

public class UIManager : MonoBehaviour
{
    DataManager dataManager;
    public TMPro.TextMeshProUGUI textMeshProUGUI;    
    public PlayerRootObject playersObj;
    // campos para receber input de texto para o player e para o score
    public TMPro.TMP_InputField inputFieldPlayer;
    public TMPro.TMP_InputField inputFieldScore;
    public GameObject contentScroll;
    
    void Start()
    {
        // retrieves the persistent DataManager object
        // localiza o data manager persistente
        dataManager = FindObjectOfType<DataManager>();
    }

    public void CarregarDados()
    {
        dataManager.LoadData();
    }

    public void SalvaNovosDados()
    {
        // chama o método InsertData passando o apelido do jogador e a pontuação
        dataManager.InsertData(inputFieldPlayer.text, int.Parse(inputFieldScore.text)); 
        // aguarda 1 segundo e carrega os dados novamente
        Invoke("CarregarDados", 1f);
    }


    private void OnEnable()
    {        
        // inscreve-se no evento
        DataManager.onDataLoaded += UpdateUI;
    }
    
    private void OnDisable()
    {        
        // cancela a inscrição no evento
        DataManager.onDataLoaded -= UpdateUI;
    }
    
    // esta função é chamada quando o evento é disparado
    void UpdateUI(string json)
    {        
        // O JsonUtility do Unity só suporta objetos como nós de nível superior,        
        // Então precisamos acessar o objeto raiz identificado com colchetes no arquivo JSON.
        // Exemplo de Bunny83: https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html        
        // o valor "players" liga cada jogador com PlayerRootObject.players
        playersObj = JsonUtility.FromJson<PlayerRootObject>("{\"players\":" + json + "}");        
        // atualiza a ui com os dados novos
        for(int i = 0; i < playersObj.players.Length; i++)
        {
            // reseta o texto do textMeshProUGUI
            textMeshProUGUI.text = "";
            // cria um novo textMeshProUGUI para cada jogador
            TMPro.TextMeshProUGUI newTMP = Instantiate(textMeshProUGUI, contentScroll.transform);
            newTMP.text += "Apelido: " + 
                playersObj.players[i].apelido + 
                "\nPontuação: " + playersObj.players[i].pontos + 
                "\nData: " + playersObj.players[i].data +
                "\n\n";
        }
    }
}
