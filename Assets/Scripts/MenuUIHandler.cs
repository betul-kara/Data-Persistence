using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;

    public void StartGame()
    {
        SaveGameData.Instance.playerName = inputField.text;
        print("Name:" + SaveGameData.Instance.playerName);
        SceneManager.LoadScene(1);

        SaveGameData.Instance.LoadData();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
