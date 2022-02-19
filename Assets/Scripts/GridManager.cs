using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    GameObject[][] gridArray;

    public GameObject square;

    [Range(1, 10)]
    public int gridX, gridY;

    [SerializeField]
    private float squareCurrentSizeX, squareCurrentSizeY;

    [SerializeField]
    private float defaultPositionX, defaultPositionY;


    void Start()
    {
        //squareCurrentSizeX = square.transform.localScale.x;
        //squareCurrentSizeY = square.transform.localScale.y;

        defaultPositionX = 0;
        defaultPositionY = 4.5f;

        GridSystem();
    }

    void Update()
    {
        
    }

    void GridSystem()
    {
        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridY; j++)
            {
                GameObject grid = Instantiate(square, new Vector3(defaultPositionX , defaultPositionY , 0) , Quaternion.identity);
                //image.GetComponent<RectTransform>().anchoredPosition = new Vector3(defaultPositionX + (buildingCurrentSizeX * i), defaultPositionY - (buildingCurrentSizeY * j), 0);
                //gridArray[i][j] = grid;
                defaultPositionY -= 1;
            }
            defaultPositionX += 1;
            defaultPositionY += gridY; 

        }
    }
}
