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
    System.Random r = new System.Random();

    void Start()
    {
        _p1Score = 0;
        _p2Score = 0;
    }
    private void Update()
    {
        p1ScoreText.text = _p1Score.ToString();
        p2ScoreText.text = _p2Score.ToString();
    }

    public static void addScore(int player)
    {
        /*To call a non-static function from a static function, i need to create an 
         * instance of the class that defines the non-static function and then call 
         * the function on that instance. The static scoreText fields were not being 
         * displayed in the LogicManager*/
        LogicScript logicScriptInstance = FindObjectOfType<LogicScript>();
        if (player == 1)
            logicScriptInstance.addScoreP1();
        if (player == 2)
            logicScriptInstance.addScoreP2();
    }
    public void addScoreP1()
    {
        nextRound();
        _p1Score += 1;
        p1ScoreText.text = _p1Score.ToString();
        if (_p1Score == 5)
            win(1);
    }
    public void addScoreP2()
    {
        nextRound();
        _p2Score += 1;
        p2ScoreText.text = _p2Score.ToString();
        if (_p2Score == 5)
            win(2);
    }
    private void nextRound()
    {
        float _generated = (float)r.NextDouble() * 2f - 1f;

        //This check is intended to prevent the ball from spawning with an angle that is too small
        while (_generated < 0.05 && _generated > -0.05)
            _generated = (float)r.NextDouble() * 2f - 1f;
        float _increment = BallScript.getIncrement();
        if (_increment > 2)
            BallScript.setIncrement(_increment / 2);

        BallScript.setPosition(new Vector2(0, 0));

        if (((_p1Score + _p2Score) % 2) != 0)
            BallScript.setDirection(new Vector2(-1, _generated));
        else
            BallScript.setDirection(new Vector2(1, _generated));
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
        BallScript.stop();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
