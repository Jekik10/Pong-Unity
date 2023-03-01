using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    int _p1Score;
    int _p2Score;
    public Text p1ScoreText;
    public Text p2ScoreText;
    public GameObject gameOverScreen;
    public Text gameOverText;
    public BallScript b;
    System.Random r = new System.Random();

    void Start()
    {
        _p1Score = 0;
        _p2Score = 0;
    }
    public void addScoreP1()
    {
        nextRound();
        _p1Score += 1;
        if (_p1Score == 5)
            win(1);
        p1ScoreText.text = _p1Score.ToString();
    }
    public void addScoreP2()
    {
        nextRound();
        _p2Score += 1;
        if (_p2Score == 5)
            win(2);
        p2ScoreText.text = _p2Score.ToString();
    }
    private void nextRound()
    {
        float _generated = (float)r.NextDouble() * 2f - 1f;

        //This check is intended to prevent the ball from spawning with an angle that is too small
        while (_generated < 0.05 && _generated > -0.05)
            _generated = (float)r.NextDouble() * 2f - 1f;
        float _increment = b.getIncrement();
        if (_increment > 2)
            b.setIncrement(_increment / 2);

        b.setPosition(new Vector2(0, 0));

        if (((_p1Score + _p2Score) % 2) != 0)
            b.setDirection(new Vector2(-1, _generated));
        else
            b.setDirection(new Vector2(1, _generated));
    }
    private void win(int winner)
    {
        if(winner == 1)
        {
            gameOverText.text = "Victory";
        }
        if (winner == 2)
        {
            gameOverText.text = "Defeat";
        }
        gameOverScreen.SetActive(true);
        b.stop();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
