using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void RemoveBrick(Brick brick){
        Destroy(brick.gameObject);
    }

    public void OnBrickCollided(Brick brick){
        RemoveBrick(brick);
        score++;
        Debug.Log("current score: "+score);
    }
}
