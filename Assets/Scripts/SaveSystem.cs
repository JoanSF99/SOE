using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void savePlayer(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        bf.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream (path, FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            //Debug.Log("Data save: " + data.points);

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path + " Created a new PlayerData");
            // Crear un nuevo PlayerData con valores por defecto
            return new PlayerData();
        }
    }
}
