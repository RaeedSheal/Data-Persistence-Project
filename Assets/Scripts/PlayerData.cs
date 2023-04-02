using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public string playerName;
    public int playerScore;
    public string bestPlayerName;
    public int bestPlayerScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;

    }

    public void SaveScore(int score)
    {
        if (score > bestPlayerScore)//heighest score
        {
            SaveData data = new SaveData();
            data.playerName = playerName;
            data.playerScore = score;

            string json = JsonUtility.ToJson(data);// transform to Json String

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); //Save json string in file
        }
        else
        {
            return;
        }
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json"; // get path
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestPlayerScore = data.playerScore;
        }
    }
}
