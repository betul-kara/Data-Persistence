using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    public static SaveGameData Instance;

    public string playerName;
    public string hsPlayerName;
    public int score;
    public int highScore;

    public void Awake()
    {
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (score > highScore)
        {
            highScore = score;
            hsPlayerName = playerName;
            SaveData();
        }
    }

    [System.Serializable]
    class Data
    {
        public string HighestName;
        public int HighScore;
    }

    public void SaveData()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        Data data = new Data();

        data.HighestName = playerName;
        data.HighScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            hsPlayerName = data.HighestName;
            highScore = data.HighScore;
        }
    }
}
