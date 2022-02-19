using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropTownCenter : MonoBehaviour
{
    private bool startDrag;
    private bool is_enter;
    public GameObject townCenterDetails;
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
        if (PlayerPrefs.GetString("buildingType") != "towncenterbuild")
        {
            CancelBuild();
        }
    }

    public void StartDragUI()
    {
        dragOffset = transform.position - Input.mousePosition;
        startDrag = true;
        PlayerPrefs.SetString("buildingType", "towncenterbuild");
        townCenterDetails.SetActive(true);
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
        townCenterDetails.SetActive(false);
    }

    public void CancelBuild()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = startPos;
        townCenterDetails.SetActive(false);
    }
}
