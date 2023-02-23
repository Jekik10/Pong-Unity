using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int p1Score;
    public int p2Score;
    public Text p1ScoreText;
    public Text p2ScoreText;
    public GameObject gameOverScreen;
    public Text gameOverText;
    public ScriptPalla palla;

    void Start()
    {
        p1Score = 0;
        p2Score = 0;
        palla = GameObject.FindWithTag("Palla").GetComponent<ScriptPalla>();
    }

    public void addScoreP1()
    {
        palla.restart();
        p1Score += 1;
        p1ScoreText.text = p1Score.ToString();
        if (p1Score == 5)
            win(1);
        

    }
    public void addScoreP2()
    {
        palla.restart();
        p2Score += 1;
        p2ScoreText.text = p2Score.ToString();
        if (p2Score == 5)
            win(2);
        

    }
    private void win(int winner)
    {
        if(winner == 1)
        {
            gameOverText.text = "Il vincitore è il Player1";
        }
        if (winner == 2)
        {
            gameOverText.text = "Il vincitore è il Player2";
        }
        gameOverScreen.SetActive(true);
        palla.stop();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public Vector2 getCoordinates()
    {
        return palla.getCoordinates();
    }
}
