using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI bestScore;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerData.instance.LoadScore();
        updateBestScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GetFieldData();
    }
    public void GetFieldData()
    {
        PlayerData.instance.playerName = nameField.text;
    }
    void updateBestScore()
    {
        bestScore.text = "Best Score : " + PlayerData.instance.bestPlayerName + " : " + PlayerData.instance.bestPlayerScore;

    }
}
