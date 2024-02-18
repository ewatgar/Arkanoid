using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDetector : MonoBehaviour
{
    LevelController levelController;
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        levelController.OnDie();
    }
}
