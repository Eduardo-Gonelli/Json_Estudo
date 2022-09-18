using UnityEngine;

public class UIManager : MonoBehaviour
{
    DataManager dataManager;
    public TMPro.TextMeshProUGUI textMeshProUGUI;    
    public PlayerRootObject playersObj;
    
    void Start()
    {
        // retrieves the persistent DataManager object
        dataManager = FindObjectOfType<DataManager>();
        // Unity's JsonUtility only supports objects like top-level nodes,
        // so we have to access the root object identified with square brackets in the JSON file.
        // From Bunny83: https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
        // the value "players" links each player with PlayerRootObject.players 
        playersObj = JsonUtility.FromJson<PlayerRootObject>("{\"players\":" + dataManager.json + "}");
        // reset the UI text
        textMeshProUGUI.text = "";
        // update the UI text from the recovered data
        for(int i = 0; i < playersObj.players.Length; i++)
        {            
            textMeshProUGUI.text += "Name: " + playersObj.players[i].name + ", Age: " + playersObj.players[i].age + ", Score: " + playersObj.players[i].score + "\n";
        }
    }
}
