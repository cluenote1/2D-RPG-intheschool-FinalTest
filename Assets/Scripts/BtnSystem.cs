using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSystem : MonoBehaviour
{
    public void GameExit()
    {
        Application.Quit();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void SelectSceneChange()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
