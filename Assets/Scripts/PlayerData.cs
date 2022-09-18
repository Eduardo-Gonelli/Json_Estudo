// to work with JSON, classes and variables need to be public or serializable.

// this is the player data represented as a common class.
[System.Serializable]
public class PlayerData
{
    public string name;
    public string age;
    public string score;
}

// as the json format used in this example has several players,
// a class is created to store all the players. See example from
// Bunny83: https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
[System.Serializable]
public class PlayerRootObject
{
    public PlayerData[] players;
}

// json format used as example
// [{"name":"Ed","age":"40","score":"999"},{"name":"Edd","age":"40","score":"999"}, {"name":"Eddy","age":"25","score":"999"}]
