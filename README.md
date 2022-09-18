# Unity_Json
Simple project made in unity to retrieve json data from a server and load it into a UI.

To use the project you need to create a json file with the format:

[{"name":"value","age":"value","score":"value"},{"name":"value","age":"value","score":"value "}]

Enter as many name, age and score elements as you like.

In the DataManager file, change the url variable to the location where your .json file is saved.

Start play from the PersistentData scene.

The Main scene will display the data from the json file in a TextMeshProGUI text. 
