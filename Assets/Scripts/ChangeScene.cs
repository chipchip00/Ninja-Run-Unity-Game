using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void About()
    {
        SceneManager.LoadScene("AboutScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
