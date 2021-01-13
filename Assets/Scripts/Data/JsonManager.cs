using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class JsonManager : MonoBehaviour {

    public static JsonManager s_Instance;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Writes a class into a Json file.
    /// </summary>
    /// <param name="fileName">Name of the Json file.</param>
    /// <param name="dataToWrite">Class to write into Json.</param>
    public void WriteJson(string fileName, object dataToWrite)
    {
        string data = JsonUtility.ToJson(dataToWrite, true);

        //File.WriteAllText(Application.dataPath + "/JsonFiles/" + fileName + ".json", data);
        File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".json", data);
    }

    /// <summary>
    /// Returns JsonData object, with which you can acces all the json values.
    /// </summary>
    /// <param name="fileName">Name of the Json file.</param>
    /// <returns></returns>
    public JsonData GetJsonData(string fileName)
    {
        //string path = File.ReadAllText(Application.dataPath + "/JsonFiles/" + fileName + ".json");
        string path = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");

        return JsonMapper.ToObject(path);
    }
}
