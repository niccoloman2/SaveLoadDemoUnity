using System.IO; //We need this for accessing files
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //we need this for serialization

public static class SaveDataManager
{
    //This is just a custom file extension for the binary file acting as our save file
    private static string saveFileExtension = "nicco";

    public static void SavePlayerData(PlayerData p_playerData)
    {
        //Initialize the formatter object
        BinaryFormatter formatter = new BinaryFormatter();

        //Specify where to save the file. Application.persistentDataPath is platform independent and would work on most platforms
        string saveFilePath = Application.persistentDataPath + "/player." + saveFileExtension;

        //We open a file stream to be able to start read/write operations.
        FileStream stream = new FileStream(saveFilePath, FileMode.Create);

        //Grabbing the data we want to save
        PlayerData dataToSave = p_playerData;

        //This just converts our object into binary
        formatter.Serialize(stream, dataToSave);
        
        //Always remember to close the FileStream
        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        //We specify the file's path we want to load
        string dataPath = Application.persistentDataPath + "/player." + saveFileExtension;

        //We have to check if there's actually a file to load
        if (File.Exists(dataPath))
        {
            //Initialize another formatter
            BinaryFormatter formatter = new BinaryFormatter();

            //Create a file stream again
            FileStream stream = new FileStream(dataPath, FileMode.Open);

            //Deserializing the file we loaded
            PlayerData result = formatter.Deserialize(stream) as PlayerData;

            //Always remember to close the stream
            stream.Close();

            //return the data object we loaded and deserialized
            return result;
        }
        else
        {
            return null;
        }
    }

}
