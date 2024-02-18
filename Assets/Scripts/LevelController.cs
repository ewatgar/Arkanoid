using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    BrickWall brickWall;
    Ball ball;
    int score = 0;
    public int lives = 3;

    void Start()
    {
        brickWall = GameObject.Find("BrickWall").GetComponent<BrickWall>();
        ball = GameObject.Find("Ball").GetComponent<Ball>();
    }

    void Update()
    {

    }

    public void OnBrickCollided(Brick brick)
    {
        RemoveBrick(brick);
        score++;
        Debug.Log("current score: " + score);
        if (score == brickWall.totalBricks)
        {
            Debug.Log("¡Enhorabuena! ¡Has ganado!");
            EndGame();
        }
    }

    private void RemoveBrick(Brick brick)
    {
        Destroy(brick.gameObject);
    }

    private void EndGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnDie()
    {
        Debug.Log("Has muerto");
        lives--;
        if (lives > 0){
            StartCoroutine(ball.PrepareLaunch());
        } else {
            Debug.Log("Perdiste todas las vidas, reiniciando partida...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}