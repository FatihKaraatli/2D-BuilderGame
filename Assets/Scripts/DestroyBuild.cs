using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class DestroyBuild : MonoBehaviour
{
    public GameManager gameManager;
    public Text count;

    public GameObject gridBarrackInfo;
    public GameObject gridTownCenterInfo;
    public GameObject gridTowerInfo;
    public GameObject gridFactoryInfo;
    public GameObject gridAirportInfo;

    public DragAndDropBarrack dragBarrack;
    public DragAndDropTownCenter dragTownCenter;
    public DragAndDropTower dragTower;
    public DragAndDropFactory dragFactory;
    public DragAndDropAirport dragAirport;

    [SerializeField] private TroopMovement troopMovement;

    private AudioSource audioSource;
    public AudioClip audioClip;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Destroy()
    {
        if (this.gameObject.tag != "grid")
        {
            dragBarrack.CancelBuild();
            dragTownCenter.CancelBuild();
            dragTower.CancelBuild();
            dragFactory.CancelBuild();
            dragAirport.CancelBuild();
        }
        if (this.gameObject.tag == "barrack" || this.gameObject.tag == "barrackrotate")
        {
            gridBarrackInfo.SetActive(true);
            gridTownCenterInfo.SetActive(false);
            gridTowerInfo.SetActive(false);
            gridFactoryInfo.SetActive(false);
            gridAirportInfo.SetActive(false);

            troopMovement.gridSoldierInfo.SetActive(false);
            troopMovement.gridTankInfo.SetActive(false);
            troopMovement.gridPlaneInfo.SetActive(false);

            for (int i = 0; i < gameManager.barrackList.Count; i++)
            {
                for (int j = 0; j < gameManager.barrackList[i].Length; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.barrackList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.barrackList[i][j];
                    }
                }
            }
        }
        else if (this.gameObject.tag == "towncenter")
        {
            gridBarrackInfo.SetActive(false);
            gridTownCenterInfo.SetActive(true);
            gridTowerInfo.SetActive(false);
            gridFactoryInfo.SetActive(false);
            gridAirportInfo.SetActive(false);

            troopMovement.gridSoldierInfo.SetActive(false);
            troopMovement.gridTankInfo.SetActive(false);
            troopMovement.gridPlaneInfo.SetActive(false);

            for (int i = 0; i < gameManager.towncenterList.Count; i++)
                {
                for (int j = 0; j < gameManager.towncenterList[i].Length; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.towncenterList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.towncenterList[i][j];
                    }
                }
            }
        }
        else if (this.gameObject.tag == "tower")
        {
            gridBarrackInfo.SetActive(false);
            gridTownCenterInfo.SetActive(false);
            gridTowerInfo.SetActive(true);
            gridFactoryInfo.SetActive(false);
            gridAirportInfo.SetActive(false);

            troopMovement.gridSoldierInfo.SetActive(false);
            troopMovement.gridTankInfo.SetActive(false);
            troopMovement.gridPlaneInfo.SetActive(false);

            for (int i = 0; i < gameManager.towerList.Count; i++)
            {
                for (int j = 0; j < gameManager.towerList[i].Length; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.towerList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.towerList[i][j];
                    }
                }
            }
        }
        else if (this.gameObject.tag == "factory" || this.gameObject.tag == "factoryrotate")
        {
            gridBarrackInfo.SetActive(false);
            gridTownCenterInfo.SetActive(false);
            gridTowerInfo.SetActive(false);
            gridFactoryInfo.SetActive(true);
            gridAirportInfo.SetActive(false);

            troopMovement.gridSoldierInfo.SetActive(false);
            troopMovement.gridTankInfo.SetActive(false);
            troopMovement.gridPlaneInfo.SetActive(false);

            for (int i = 0; i < gameManager.factorykList.Count; i++)
            {
                for (int j = 0; j < gameManager.factorykList[i].Length; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.factorykList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.factorykList[i][j];
                    }
                }
            }
        }
        else if (this.gameObject.tag == "airport")
        {
            gridBarrackInfo.SetActive(false);
            gridTownCenterInfo.SetActive(false);
            gridTowerInfo.SetActive(false);
            gridFactoryInfo.SetActive(false);
            gridAirportInfo.SetActive(true);

            troopMovement.gridSoldierInfo.SetActive(false);
            troopMovement.gridTankInfo.SetActive(false);
            troopMovement.gridPlaneInfo.SetActive(false);

            for (int i = 0; i < gameManager.airportList.Count; i++)
            {
                for (int j = 0; j < gameManager.airportList[i].Length; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.airportList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        gameManager.destroyObject = gameManager.airportList[i][j];
                    }
                }
            }
        }
    }

    public void FindBarrack()
    {
        if (gameManager.destroyObject.gameObject.tag == "barrack" || gameManager.destroyObject.gameObject.tag == "barrackrotate")
        {
            for (int i = 0; i < gameManager.barrackList.Count; i++)
            {
                for (int j = 0; j < gameManager.barrackList[i].Length; j++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.barrackList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        audioSource.PlayOneShot(audioClip);

                        for (int k = 0; k < gameManager.barrackList[i].Length; k++)
                        {
                            gameManager.barrackList[i][k].color = Color.white;
                            gameManager.barrackList[i][k].tag = "grid";
                            gameManager.barrackList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
                            gameManager.barrackList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                        }
                        gameManager.barrackList.RemoveAt(i);
                        gridBarrackInfo.SetActive(false);
                        return;
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "towncenter")
        {
            for (int i = 0; i < gameManager.towncenterList.Count; i++)
            {
                for (int j = 0; j < gameManager.towncenterList[i].Length; j++)
                {
                    audioSource.PlayOneShot(audioClip);

                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.towncenterList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        for (int k = 0; k < gameManager.towncenterList[i].Length; k++)
                        {
                            gameManager.towncenterList[i][k].color = Color.white;
                            gameManager.towncenterList[i][k].tag = "grid";
                            gameManager.towncenterList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
                            gameManager.towncenterList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                        }
                        gameManager.towncenterList.RemoveAt(i);
                        gridTownCenterInfo.SetActive(false);
                        return;
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "tower")
        {
            for (int i = 0; i < gameManager.towerList.Count; i++)
            {
                for (int j = 0; j < gameManager.towerList[i].Length; j++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.towerList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        audioSource.PlayOneShot(audioClip);

                        for (int k = 0; k < gameManager.towerList[i].Length; k++)
                        {
                            gameManager.towerList[i][k].color = Color.white;
                            gameManager.towerList[i][k].tag = "grid";
                            gameManager.towerList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
                            gameManager.towerList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                        }
                        gameManager.towerList.RemoveAt(i);
                        gridTowerInfo.SetActive(false);
                        return;
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "factory" || gameManager.destroyObject.gameObject.tag == "factoryrotate")
        {
            for (int i = 0; i < gameManager.factorykList.Count; i++)
            {
                for (int j = 0; j < gameManager.factorykList[i].Length; j++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.factorykList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        audioSource.PlayOneShot(audioClip);

                        for (int k = 0; k < gameManager.factorykList[i].Length; k++)
                        {
                            gameManager.factorykList[i][k].color = Color.white;
                            gameManager.factorykList[i][k].tag = "grid";
                            gameManager.factorykList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
                            gameManager.factorykList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                        }
                        gameManager.factorykList.RemoveAt(i);
                        gridFactoryInfo.SetActive(false);
                        return;
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "airport")
        {
            for (int i = 0; i < gameManager.airportList.Count; i++)
            {
                for (int j = 0; j < gameManager.airportList[i].Length; j++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.airportList[i][j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        audioSource.PlayOneShot(audioClip);

                        for (int k = 0; k < gameManager.airportList[i].Length; k++)
                        {
                            gameManager.airportList[i][k].color = Color.white;
                            gameManager.airportList[i][k].tag = "grid";
                            gameManager.airportList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().text = ".";
                            gameManager.airportList[i][k].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                        }
                        gameManager.airportList.RemoveAt(i);
                        gridAirportInfo.SetActive(false);
                        return;
                    }
                }
            }
        }
    }

    public void DestroyButton()
    {
        FindBarrack();
    }


}
