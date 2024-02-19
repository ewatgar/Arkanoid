using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 10;
    public float width = 2;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        changeSize();
        keyboardControls();
    }

    void OnMouseDrag()
    {
        mouseControls();
    }


    private void keyboardControls()
    {
        float dx = Input.GetAxis("Horizontal");
        rigidBody.velocity = dx * speed * transform.right;
    }

    private void mouseControls()
    {
        Vector2 mouseCoordsPixels = Input.mousePosition;
        Vector2 mouseCoordsGlobal = Camera.main.ScreenToWorldPoint(mouseCoordsPixels);
        Vector2 platformCoords = new Vector2(mouseCoordsGlobal.x, transform.position.y);
        rigidBody.MovePosition(platformCoords);
    }

    private void changeSize()
    {
        GameObject platform = transform.Find("Platform").gameObject;
        GameObject square = platform.transform.Find("Square").gameObject;
        GameObject lCircle = platform.transform.Find("LCircle").gameObject;
        GameObject rCircle = platform.transform.Find("RCircle").gameObject;
        CapsuleCollider2D collider = transform.GetComponent<CapsuleCollider2D>();

        float squareSize = width / 2;
        float circlePos = squareSize / 2;
        float colliderSize = squareSize + 0.5f;

        square.transform.localScale = new Vector3(squareSize, 0.5f, 1);
        lCircle.transform.localPosition = new Vector3(-circlePos, 0, 0);
        rCircle.transform.localPosition = new Vector3(circlePos, 0, 0);
        collider.size = new Vector2(colliderSize,0.5f);
    }
}
