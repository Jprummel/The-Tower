using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadData : MonoBehaviour
{
    public static void Save<T>(string filename, T data) where T : class
    {
        using (Stream stream = File.OpenWrite(Application.persistentDataPath + "/" + filename))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static T Load<T>(string filename) where T : class
    {
        if (File.Exists(Application.persistentDataPath + "/" + filename))
        {
            try
            {
                using (Stream stream = File.OpenRead(Application.persistentDataPath + "/" + filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream) as T;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        return default(T);
    }
}