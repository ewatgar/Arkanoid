using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidBody;
    FixedJoint2D playerFixedJoint;
    LevelController levelController;
    public float speed = 7;
    Vector2 initBallPos;
    Vector2 initPlayerPos;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerFixedJoint = GameObject.Find("Player").GetComponent<FixedJoint2D>();
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        initBallPos = transform.position;
        initPlayerPos = playerFixedJoint.transform.position;
        StartCoroutine(PrepareLaunch());
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
        //rigidBody.AddForce(dir*speed);
        rigidBody.velocity = dir * speed;
    }

    public IEnumerator PrepareLaunch()
    {
        playerFixedJoint.enabled = true;
        RestartPosition();

        yield return new WaitForSeconds(2);

        Vector2 initDir = transform.up;
        playerFixedJoint.enabled = false;
        Launch(initDir);
    }

    private void RestartPosition(){
        transform.position = initBallPos;
        playerFixedJoint.transform.position = initPlayerPos;
    }
}
