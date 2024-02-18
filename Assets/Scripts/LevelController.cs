using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    BrickWall brickWall;
    int score = 0;

    void Start()
    {
        brickWall = GameObject.Find("BrickWall").GetComponent<BrickWall>();
    }

    void Update()
    {
        
    }

    public void OnBrickCollided(Brick brick){
        RemoveBrick(brick);
        score++;
        Debug.Log("current score: "+score);
        if (score == brickWall.totalBricks){
            Debug.Log("¡Enhorabuena! ¡Has ganado!");
            EndGame();
        }
    }

    private void RemoveBrick(Brick brick){
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
}