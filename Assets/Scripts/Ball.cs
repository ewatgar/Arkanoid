using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidBody;
    FixedJoint2D playerFixedJoint;
    LevelController levelController;
    public float speed = 7;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerFixedJoint = GameObject.Find("Player").GetComponent<FixedJoint2D>();
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        StartCoroutine(LaunchTimer());
    }

    void FixedUpdate()
    {
        //rigidBody.velocity = transform.position*speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick"){
            Brick brick = collision.gameObject.GetComponent<Brick>();
            levelController.OnBrickCollided(brick);
        }
    }
    public void Launch(Vector2 dir)
    {
        playerFixedJoint.enabled = false;
        //rigidBody.AddForce(dir*speed);
        rigidBody.velocity = dir * speed;
    }

    IEnumerator LaunchTimer()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("Pelota se lanza");

        Vector2 initDir = transform.up;
        Launch(initDir);
    }


}
