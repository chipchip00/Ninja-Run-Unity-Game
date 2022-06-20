using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    public void setScoreText(string txt)
    {
        scoreText.text = txt;
    }
    public void changeStatusPanel(bool status)
    {
        gameOverPanel.SetActive(status);
    }
}
