// para trabalhar com JSON, as classes e vari�veis precisam ser p�blicas ou serializ�veis.
[System.Serializable]
public class PlayerData
{
    public string apelido;    
    public int pontos;
    public string data;
}

// como o json usado neste exemplo tem v�rios jogadores,
// uma classe � criada para armazenar todos os jogadores. Veja o exemplo de
// Bunny83: https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
[System.Serializable]
public class PlayerRootObject
{
    public PlayerData[] players;
}
