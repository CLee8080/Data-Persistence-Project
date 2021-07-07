using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistance : MonoBehaviour
{

    public static DataPersistance Instance;
    public string playerName;
    public string playersBestScore;
    public int bestScore = 0;



    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();
    }


    [System.Serializable]

    class SaveData
    {
        public string playersBestScore;
        public int bestScore;
    }




    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.playersBestScore = playerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playersBestScore = data.playersBestScore;
            bestScore = data.bestScore;
        }
    }
}
