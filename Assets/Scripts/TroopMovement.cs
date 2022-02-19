using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TroopMovement : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private DestroyBuild destroyBuild;

    public GameObject gridSoldierInfo;
    public GameObject gridTankInfo;
    public GameObject gridPlaneInfo;

    public DragAndDropBarrack dragBarrack;
    public DragAndDropTownCenter dragTownCenter;
    public DragAndDropTower dragTower;
    public DragAndDropFactory dragFactory;
    public DragAndDropAirport dragAirport;

    private AudioSource audioSource;
    public AudioClip audioClipSoldier;
    public AudioClip audioClipTank_Plane;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    public void TroopManagement()
    {
        if (this.gameObject.tag != "grid")
        {
            dragBarrack.CancelBuild();
            dragTownCenter.CancelBuild();
            dragTower.CancelBuild();
            dragFactory.CancelBuild();
            dragAirport.CancelBuild();
        }

        if (this.gameObject.tag == "soldier")
        {
            gridSoldierInfo.SetActive(true);
            gridTankInfo.SetActive(false);
            gridPlaneInfo.SetActive(false);

            destroyBuild.gridBarrackInfo.SetActive(false);
            destroyBuild.gridTownCenterInfo.SetActive(false);
            destroyBuild.gridTowerInfo.SetActive(false);
            destroyBuild.gridFactoryInfo.SetActive(false);
            destroyBuild.gridAirportInfo.SetActive(false);
            for (int i = 0; i < gameManager.gridX; i++)
            {
                for (int j = 0; j < gameManager.gridY; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.gridArray[i, j];
                    }
                }
            }
        }
        else if (this.gameObject.tag == "tank")
        {
            gridSoldierInfo.SetActive(false);
            gridTankInfo.SetActive(true);
            gridPlaneInfo.SetActive(false);

            destroyBuild.gridBarrackInfo.SetActive(false);
            destroyBuild.gridTownCenterInfo.SetActive(false);
            destroyBuild.gridTowerInfo.SetActive(false);
            destroyBuild.gridFactoryInfo.SetActive(false);
            destroyBuild.gridAirportInfo.SetActive(false);
            for (int i = 0; i < gameManager.gridX; i++)
            {
                for (int j = 0; j < gameManager.gridY; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.gridArray[i, j];
                    }
                }
            }
        }
        else if (this.gameObject.tag == "plane")
        {
            gridSoldierInfo.SetActive(false);
            gridTankInfo.SetActive(false);
            gridPlaneInfo.SetActive(true);

            destroyBuild.gridBarrackInfo.SetActive(false);
            destroyBuild.gridTownCenterInfo.SetActive(false);
            destroyBuild.gridTowerInfo.SetActive(false);
            destroyBuild.gridFactoryInfo.SetActive(false);
            destroyBuild.gridAirportInfo.SetActive(false);
            for (int i = 0; i < gameManager.gridX; i++)
            {
                for (int j = 0; j < gameManager.gridY; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.gridArray[i, j];
                    }
                }
            }
        }

        if (gameManager.destroyObject.tag == "soldier")
        {
            if (this.gameObject.tag == "grid")
            {
                this.gameObject.GetComponent<Image>().color = Color.green;
                this.gameObject.tag = "soldier";
                this.gameObject.transform.GetChild(0).GetComponent<Text>().text = "S1";
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;

                MovementDestroy();
            }
        }
        if (gameManager.destroyObject.tag == "tank")
        {
            if (this.gameObject.tag == "grid")
            {
                this.gameObject.GetComponent<Image>().color = Color.blue;
                this.gameObject.tag = "tank";
                this.gameObject.transform.GetChild(0).GetComponent<Text>().text = "T1";
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;

                MovementDestroy();
            }
        }
        if (gameManager.destroyObject.tag == "plane")
        {
            if (this.gameObject.tag == "grid")
            {
                this.gameObject.GetComponent<Image>().color = new Color(1, 0.7f, 0, 1);//orange
                this.gameObject.tag = "plane";
                this.gameObject.transform.GetChild(0).GetComponent<Text>().text = "P1";
                this.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;

                MovementDestroy();
            }
        }
    
    }

    public void DestroyTroopButton()
    {
        if (gameManager.destroyObject.tag == "soldier")
        {
            audioSource.PlayOneShot(audioClipSoldier);
        }
        else if((gameManager.destroyObject.tag == "plane" || gameManager.destroyObject.tag == "tank"))
        {
            audioSource.PlayOneShot(audioClipTank_Plane);
        }
        gameManager.destroyObject.color = Color.white;
        gameManager.destroyObject.tag = "grid";
        gameManager.destroyObject.gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
        gameManager.destroyObject.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;

        gridSoldierInfo.SetActive(false);
        gridTankInfo.SetActive(false);
        gridPlaneInfo.SetActive(false);
    }

    private void MovementDestroy()
    {
        gameManager.destroyObject.color = Color.white;
        gameManager.destroyObject.tag = "grid";
        gameManager.destroyObject.gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
        gameManager.destroyObject.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;

        gridSoldierInfo.SetActive(false);
        gridTankInfo.SetActive(false);
        gridPlaneInfo.SetActive(false);
    }
}
