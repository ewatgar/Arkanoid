using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 10;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
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
        Vector2 platformCoords = new Vector2(mouseCoordsGlobal.x,transform.position.y);
        rigidBody.MovePosition(platformCoords);
    }
}
