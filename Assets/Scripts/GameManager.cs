using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class GameManager : MonoBehaviour
{
    //canvas object
    public GameObject parentObject;

    public Image[,] gridArray;

    //prefab object
    public Image building;

    public InputField inputField;
    public GameObject inputPanel;

    public GameObject container;

    [Range(5, 16)]
    public int gridX, gridY;

    [SerializeField]
    private float buildingCurrentSizeX, buildingCurrentSizeY;

    [SerializeField]
    private float defaultPositionX, defaultPositionY;

    [HideInInspector]
    public List<Image[]> barrackList = new List<Image[]>();
    public List<Image[]> towncenterList = new List<Image[]>();
    public List<Image[]> towerList = new List<Image[]>();
    public List<Image[]> factorykList = new List<Image[]>();
    public List<Image[]> airportList = new List<Image[]>();

    [HideInInspector]
    public List<Image> soldierList = new List<Image>();
    [HideInInspector]
    public List<Image> tankList = new List<Image>();
    [HideInInspector]
    public List<Image> planeList = new List<Image>();

    [HideInInspector]
    public Image destroyObject;

    [HideInInspector]
    public int soldierCount = 0 , tankCount = 0 , planeCount = 0;
    
    [HideInInspector]
    public int barrackCount = 0 , towncenterCount = 0 , towerCount = 0 , factoryCount = 0 , airportCount = 0;



    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("startgrid" , 0);

        buildingCurrentSizeX = building.GetComponent<RectTransform>().sizeDelta.x;
        buildingCurrentSizeY = building.GetComponent<RectTransform>().sizeDelta.y;

        defaultPositionX = building.GetComponent<RectTransform>().anchoredPosition.x;
        defaultPositionY = building.GetComponent<RectTransform>().anchoredPosition.y;
    }

    void GridSystem(int grid)
    {
        
        gridX = grid;
        gridY = grid;
        if (gridX % 2 == 0)
        {
            defaultPositionX -= buildingCurrentSizeX/2 * (gridX-1);
        }
        else
        {
            defaultPositionX -= buildingCurrentSizeX * (gridX / 2);
        }

        gridArray = new Image[gridX,gridY];
        for (int i = 0; i < gridX; i++)
        {
            for (int j = (gridY - 1); j >= 0; j--)
            {
                Image image = Instantiate(building, parentObject.transform);
                image.GetComponent<RectTransform>().anchoredPosition = new Vector3(defaultPositionX + (buildingCurrentSizeX * i), defaultPositionY - (buildingCurrentSizeY * j), 0);

                gridArray[j,i] = image;
            }
        }
        PlayerPrefs.SetInt("startgrid", 1);
        container.SetActive(true);
        inputPanel.SetActive(false);


    }

    public void Dimension()
    {
        if (int.Parse(inputField.text) < 5 || int.Parse(inputField.text) > 16)
        {
            GridSystem(5);
        }
        else if (int.Parse(inputField.text) >= 5 || int.Parse(inputField.text) <= 16)
        {
            GridSystem(int.Parse(inputField.text));
        }
        else
        {
            GridSystem(5);
        }
    }



}
