using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWall : MonoBehaviour
{
    [SerializeField] GameObject[] brickPrefabs;
    private float x0;
    private float offsetX;
    private float y0;
    private float offsetY;
    void Start()
    {
        PlaceBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceBricks(int nRows = 5, int nCols = 5, float gap = 0.5f){
        CalcOriginOffset(nCols, nRows, 1, 7);

        int currentIndex = 0;
        for (int i = 0; i < nRows; i++)
        {
            Debug.Log("i: "+i);
            Debug.Log("currentIndex: "+currentIndex);
            GameObject brickPrefab = brickPrefabs[currentIndex];
            currentIndex++;
            for (int j = 0; j < nCols; j++)
            {
                Debug.Log("j: "+j);
                float coordsX = x0 + offsetX * j;
                float coordsY = y0 + offsetY * i; //- 5;
                CreateBrick(brickPrefab, -coordsX, -coordsY);
                
            }
        }
    }

    private void CalcOriginOffset(int nCols, int nRows, float marginX, float marginY)
    {
        float camWidth = Camera.main.pixelWidth / 100;
        float camHeight = Camera.main.pixelHeight / 100;

        Vector3 brickSize = brickPrefabs[0].GetComponentInChildren<SpriteRenderer>().bounds.size; //cualquier brick sirve

        float brickWidth = brickSize.x;
        float brickHeight = brickSize.y;

        float gapX = (camWidth - brickWidth * nCols - marginX * 2) / (nCols - 1);
        if (gapX < 0) gapX = 0;
        float gapY = (camHeight - brickHeight * nRows - marginY * 2) / (nRows - 1);
        if (gapY < 0) gapY = 0;

        float rowWidth = brickWidth * nCols + gapX * (nCols - 1);
        float colHeight = brickHeight * nRows + gapY * (nRows - 1);

        x0 = -(rowWidth - brickWidth) / 2;
        y0 = -(colHeight - brickHeight) / 2;

        offsetX = brickWidth + gapX;
        offsetY = brickHeight + gapY;
    }

    private void CreateBrick(GameObject brickPrefab, float coordsX, float coordsY)
    {
        GameObject brick = Instantiate(brickPrefab);
        brick.transform.parent = gameObject.transform;
        brick.transform.localPosition = new Vector3(
            coordsX,
            coordsY,
            -1
        );
    }
}
