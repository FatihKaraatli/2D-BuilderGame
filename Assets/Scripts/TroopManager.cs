using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TroopManager : MonoBehaviour
{

    public GameManager gameManager;

    private AudioSource audioSource;
    public AudioClip audioClipSoldier;
    public AudioClip audioClipTank_Plane;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void MakeTroop()
    {
        if (gameManager.destroyObject.gameObject.tag == "barrack")
        {
            if (gameManager.soldierList.Count > 0)
            {
                audioSource.PlayOneShot(audioClipSoldier);

                gameManager.soldierCount++;
                gameManager.soldierList[0].color = Color.green;
                gameManager.soldierList[0].tag = "soldier";
                gameManager.soldierList[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = "S1";
                gameManager.soldierList[0].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                gameManager.soldierList.RemoveAt(0);
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "barrackrotate")
        {
            if (gameManager.soldierList.Count > 0)
            {
                audioSource.PlayOneShot(audioClipSoldier);

                gameManager.soldierCount++;
                gameManager.soldierList[0].color = Color.green;
                gameManager.soldierList[0].tag = "soldier";
                gameManager.soldierList[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = "S1";
                gameManager.soldierList[0].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                gameManager.soldierList.RemoveAt(0);
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "factory")
        {
            if (gameManager.tankList.Count > 0)
            {
                audioSource.PlayOneShot(audioClipTank_Plane);

                gameManager.tankCount++;
                gameManager.tankList[0].color = Color.blue;
                gameManager.tankList[0].tag = "tank";
                gameManager.tankList[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = "T1";
                gameManager.tankList[0].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                gameManager.tankList.RemoveAt(0);
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "factoryrotate")
        {
            if (gameManager.tankList.Count > 0)
            {
                audioSource.PlayOneShot(audioClipTank_Plane);

                gameManager.tankCount++;
                gameManager.tankList[0].color = Color.blue;
                gameManager.tankList[0].tag = "tank";
                gameManager.tankList[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = "T1";
                gameManager.tankList[0].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                gameManager.tankList.RemoveAt(0);
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "airport")
        {
            if (gameManager.planeList.Count > 0)
            {
                audioSource.PlayOneShot(audioClipTank_Plane);

                gameManager.planeCount++;
                gameManager.planeList[0].color = new Color(1, 0.7f, 0,1);//orange
                gameManager.planeList[0].tag = "plane";
                gameManager.planeList[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = "P1";
                gameManager.planeList[0].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                gameManager.planeList.RemoveAt(0);
            }
        }
    }

    private void IsGridValid(Image[,] grid , int i , int j)
    {
        if (gameManager.destroyObject.gameObject.tag == "barrack" || gameManager.destroyObject.gameObject.tag == "barrackrotate")
        {
            if (i >= 0 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY)
            {
                if (grid[i, j].tag == "grid")
                {
                    gameManager.soldierList.Add(grid[i, j]);
                }
            }
        }
        if (gameManager.destroyObject.gameObject.tag == "factory" || gameManager.destroyObject.gameObject.tag == "factoryrotate")
        {
            if (i >= 0 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY)
            {
                if (grid[i, j].tag == "grid")
                {
                    gameManager.tankList.Add(grid[i, j]);
                }
            }
        }
        if (gameManager.destroyObject.gameObject.tag == "airport")
        {
            if (i >= 0 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY)
            {
                if (grid[i, j].tag == "grid")
                {
                    gameManager.planeList.Add(grid[i, j]);
                }
            }
        }
    }

    public void MakeTroopsGridArray()
    {
        if (gameManager.destroyObject.gameObject.tag == "barrack")
        {
            for (int k = 0; k < gameManager.soldierList.Count; k++)
            {
                gameManager.soldierList.RemoveAt(k);
                k--;
            }

            for (int a = 0; a < gameManager.barrackList.Count; a++)
            {
                for (int b = 0; b < gameManager.barrackList[a].Length; b++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.barrackList[a][b].GetComponent<RectTransform>().anchoredPosition)
                    {
                        if (b != 0)
                        {
                            gameManager.destroyObject = gameManager.barrackList[a][0];
                            gameManager.barrackList[a][0].GetComponent<TroopManager>().MakeTroopsGridArray(); 
                        }
                        else
                        {
                            for (int i = 0; i < gameManager.gridX; i++)
                            {
                                for (int j = 0; j < gameManager.gridY; j++)
                                {
                                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        IsGridValid(gameManager.gridArray, i + 1, j);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 1);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 2);

                                        IsGridValid(gameManager.gridArray, i, j - 1);
                                        IsGridValid(gameManager.gridArray, i, j + 3);

                                        IsGridValid(gameManager.gridArray, i - 1, j - 1);
                                        IsGridValid(gameManager.gridArray, i - 1, j + 3);

                                        IsGridValid(gameManager.gridArray, i - 2, j);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 1);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "barrackrotate")
        {
            for (int k = 0;k<gameManager.soldierList.Count; k++)
            {
                gameManager.soldierList.RemoveAt(k);
                k--;
            }

            for (int a = 0; a < gameManager.barrackList.Count; a++)
            {
                for (int b = 0; b < gameManager.barrackList[a].Length; b++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.barrackList[a][b].GetComponent<RectTransform>().anchoredPosition)
                    {
                        if (b != 0)
                        {
                            gameManager.destroyObject = gameManager.barrackList[a][0];
                            gameManager.barrackList[a][0].GetComponent<TroopManager>().MakeTroopsGridArray();
                        }
                        else
                        {
                            for (int i = 0; i < gameManager.gridX; i++)
                            {
                                for (int j = 0; j < gameManager.gridY; j++)
                                {
                                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        IsGridValid(gameManager.gridArray, i + 1, j - 1);
                                        IsGridValid(gameManager.gridArray, i + 1, j);

                                        IsGridValid(gameManager.gridArray, i, j - 2);
                                        IsGridValid(gameManager.gridArray, i, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 1, j - 2);
                                        IsGridValid(gameManager.gridArray, i - 1, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 2, j - 2);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 3, j - 1);
                                        IsGridValid(gameManager.gridArray, i - 3, j);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "factory")
        {
            for (int k = 0; k < gameManager.tankList.Count; k++)
            {
                gameManager.tankList.RemoveAt(k);
                k--;
            }

            for (int a = 0; a < gameManager.factorykList.Count; a++)
            {
                for (int b = 0; b < gameManager.factorykList[a].Length; b++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.factorykList[a][b].GetComponent<RectTransform>().anchoredPosition)
                    {
                        if (b != 0)
                        {
                            
                            gameManager.destroyObject = gameManager.factorykList[a][0];
                            gameManager.factorykList[a][0].GetComponent<TroopManager>().MakeTroopsGridArray();
                        }
                        else
                        {
                            for (int i = 0; i < gameManager.gridX; i++)
                            {
                                for (int j = 0; j < gameManager.gridY; j++)
                                {
                                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        IsGridValid(gameManager.gridArray, i + 1, j);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 1);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 2);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 3);

                                        IsGridValid(gameManager.gridArray, i, j - 1);
                                        IsGridValid(gameManager.gridArray, i, j + 4);

                                        IsGridValid(gameManager.gridArray, i - 1, j - 1);
                                        IsGridValid(gameManager.gridArray, i - 1, j + 4);

                                        IsGridValid(gameManager.gridArray, i - 2, j);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 1);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 2);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "factoryrotate")
        {
            for (int k = 0; k < gameManager.tankList.Count; k++)
            {
                gameManager.tankList.RemoveAt(k);
                k--;
            }

            for (int a = 0; a < gameManager.factorykList.Count; a++)
            {
                for (int b = 0; b < gameManager.factorykList[a].Length; b++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.factorykList[a][b].GetComponent<RectTransform>().anchoredPosition)
                    {
                        if (b != 0)
                        {

                            gameManager.destroyObject = gameManager.factorykList[a][0];
                            gameManager.factorykList[a][0].GetComponent<TroopManager>().MakeTroopsGridArray();
                        }
                        else
                        {
                            for (int i = 0; i < gameManager.gridX; i++)
                            {
                                for (int j = 0; j < gameManager.gridY; j++)
                                {
                                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        IsGridValid(gameManager.gridArray, i + 1, j);
                                        IsGridValid(gameManager.gridArray, i + 1, j - 1);

                                        IsGridValid(gameManager.gridArray, i, j - 2);
                                        IsGridValid(gameManager.gridArray, i, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 1, j - 2);
                                        IsGridValid(gameManager.gridArray, i - 1, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 2, j - 2);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 3, j - 2);
                                        IsGridValid(gameManager.gridArray, i - 3, j + 1);

                                        IsGridValid(gameManager.gridArray, i - 4, j);
                                        IsGridValid(gameManager.gridArray, i - 4, j - 1);

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (gameManager.destroyObject.gameObject.tag == "airport")
        {
            for (int k = 0; k < gameManager.planeList.Count; k++)
            {
                gameManager.planeList.RemoveAt(k);
                k--;
            }

            for (int a = 0; a < gameManager.airportList.Count; a++)
            {
                for (int b = 0; b < gameManager.airportList[a].Length; b++)
                {
                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.airportList[a][b].GetComponent<RectTransform>().anchoredPosition)
                    {
                        if (b != 0)
                        {

                            gameManager.destroyObject = gameManager.airportList[a][0];
                            gameManager.airportList[a][0].GetComponent<TroopManager>().MakeTroopsGridArray();
                        }
                        else
                        {
                            for (int i = 0; i < gameManager.gridX; i++)
                            {
                                for (int j = 0; j < gameManager.gridY; j++)
                                {
                                    if (gameManager.destroyObject.gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        IsGridValid(gameManager.gridArray, i + 1, j);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 1);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 2);
                                        IsGridValid(gameManager.gridArray, i + 1, j + 3);

                                        IsGridValid(gameManager.gridArray, i, j - 1);
                                        IsGridValid(gameManager.gridArray, i, j + 4);

                                        IsGridValid(gameManager.gridArray, i - 1, j - 1);
                                        IsGridValid(gameManager.gridArray, i - 1, j + 4);

                                        IsGridValid(gameManager.gridArray, i - 2, j - 1);
                                        IsGridValid(gameManager.gridArray, i - 2, j + 4);

                                        IsGridValid(gameManager.gridArray, i - 3, j - 1);
                                        IsGridValid(gameManager.gridArray, i - 3, j + 4);

                                        IsGridValid(gameManager.gridArray, i - 4, j);
                                        IsGridValid(gameManager.gridArray, i - 4, j + 1);
                                        IsGridValid(gameManager.gridArray, i - 4, j + 2);
                                        IsGridValid(gameManager.gridArray, i - 4, j + 3);

                                    }
                                }
                            }
                        }
                    }
                }
            }


        }
    }
}
