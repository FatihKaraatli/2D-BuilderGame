using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropTower : MonoBehaviour
{
    private bool startDrag;
    private bool is_enter;
    private int is_rotate = 3;
    public GameObject towerDetails;
    private Vector2 startPos;
    private Vector3 dragOffset;

    [SerializeField] private DestroyBuild destroyBuild;
    [SerializeField] private TroopMovement troopMovement;


    private void Start()
    {
        startPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }
    private void Update()
    {
        if (startDrag)
        {
            destroyBuild.gridBarrackInfo.SetActive(false);
            destroyBuild.gridTownCenterInfo.SetActive(false);
            destroyBuild.gridTowerInfo.SetActive(false);
            destroyBuild.gridFactoryInfo.SetActive(false);
            destroyBuild.gridAirportInfo.SetActive(false);

            troopMovement.gridSoldierInfo.SetActive(false);
            troopMovement.gridTankInfo.SetActive(false);
            troopMovement.gridPlaneInfo.SetActive(false);

            transform.position = Input.mousePosition + dragOffset;
        }
        if (PlayerPrefs.GetString("buildingType") != "towerbuild")
        {
            CancelBuild();
        }
    }

    public void StartDragUI()
    {
        dragOffset = transform.position - Input.mousePosition;
        startDrag = true;
        PlayerPrefs.SetString("buildingType", "towerbuild");
        towerDetails.SetActive(true);
    }

    public void StopDragUI()
    {
        startDrag = false;
    }

    private void BuildingHelperMethod(GameObject gameObject)
    {
        if (is_enter)
        {
            gameObject.gameObject.GetComponent<PutNewBuild>().FindArrayIndex();
            is_rotate = 3;
            PlayerPrefs.SetInt("towerrotate", 0);
            is_enter = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("grid"))
        {
            BuildingHelperMethod(collision.gameObject);
        }
    }

    public void PutHere()
    {
        is_enter = true;
        gameObject.GetComponent<RectTransform>().anchoredPosition = startPos;
        gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        towerDetails.SetActive(false);
    }

    public void RotateBuilding()
    {
        if (is_rotate == 3)
        {
            PlayerPrefs.SetInt("towerrotate", 3);
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
            is_rotate = 2;
        }
        else if(is_rotate == 2)
        {
            PlayerPrefs.SetInt("towerrotate", 2);
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            is_rotate = 1;
        }
        else if (is_rotate == 1)
        {
            PlayerPrefs.SetInt("towerrotate", 1);
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 270);
            is_rotate = 0;
        }
        else if (is_rotate == 0)
        {
            PlayerPrefs.SetInt("towerrotate", 0);
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            is_rotate = 3;
        }
    }

    public void CancelBuild()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = startPos;
        gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        PlayerPrefs.SetInt("towerrotate", 0);
        towerDetails.SetActive(false);
    }
}
