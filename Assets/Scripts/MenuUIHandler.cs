using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder (1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;

    private void Update()
    {
        DataPersistance.Instance.playerName = nameInputField.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataPersistance.Instance.SavePlayer();

#if  UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }
}
