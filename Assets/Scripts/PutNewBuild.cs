using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PutNewBuild : MonoBehaviour
{
    public GameManager gameManager;
    public Text count;
    private AudioSource audioSource;
    public AudioClip audioClip;


    void Start()
    {
        PlayerPrefs.DeleteAll();

        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void Put()
    {
        //FindArrayIndex(this.gameObject);
    }

    public void FindArrayIndex()
    {
        if (PlayerPrefs.GetString("buildingType") == "barrackbuild")
        {
            if (PlayerPrefs.GetInt("barrackrotate") == 0)
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 0 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY - 2)
                                {
                                    if (gameManager.gridArray[i, j + 1].tag == "grid" && gameManager.gridArray[i, j + 2].tag == "grid" &&
                                        gameManager.gridArray[i - 1, j].tag == "grid" && gameManager.gridArray[i - 1, j + 1].tag == "grid" &&
                                        gameManager.gridArray[i - 1, j + 2].tag == "grid")
                                    {
                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i, j + 1].color = Color.black;
                                        gameManager.gridArray[i, j + 2].color = Color.black;
                                        gameManager.gridArray[i - 1, j].color = Color.black;
                                        gameManager.gridArray[i - 1, j + 1].color = Color.black;
                                        gameManager.gridArray[i - 1, j + 2].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "barrack";
                                        gameManager.gridArray[i, j + 1].tag = "barrack";
                                        gameManager.gridArray[i, j + 2].tag = "barrack";
                                        gameManager.gridArray[i - 1, j].tag = "barrack";
                                        gameManager.gridArray[i - 1, j + 1].tag = "barrack";
                                        gameManager.gridArray[i - 1, j + 2].tag = "barrack";

                                        //We need to collect all points of buildings so this solution prevent some errors
                                        gameManager.barrackList.Add(new Image[6]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j+1],
                                        gameManager.gridArray[i, j+2],
                                        gameManager.gridArray[i-1, j],
                                        gameManager.gridArray[i-1, j+1],
                                        gameManager.gridArray[i-1, j+2]}
                                        );

                                        //To understand which barrack we want to see
                                        gameManager.barrackCount++;
                                        count.text = "b" + gameManager.barrackCount.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 1 && i < gameManager.gridX && j > 0 && j < gameManager.gridY )
                                {
                                    if (gameManager.gridArray[i, j - 1].tag == "grid" && gameManager.gridArray[i - 1, j].tag == "grid" && 
                                        gameManager.gridArray[i - 1, j - 1].tag == "grid" &&gameManager.gridArray[i - 2, j].tag == "grid" && 
                                        gameManager.gridArray[i - 2, j - 1].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i, j - 1].color = Color.black;
                                        gameManager.gridArray[i - 1, j].color = Color.black;
                                        gameManager.gridArray[i - 1, j - 1].color = Color.black;
                                        gameManager.gridArray[i - 2, j].color = Color.black;
                                        gameManager.gridArray[i - 2, j - 1].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "barrackrotate";
                                        gameManager.gridArray[i, j - 1].tag = "barrackrotate";
                                        gameManager.gridArray[i - 1, j].tag = "barrackrotate";
                                        gameManager.gridArray[i - 1, j - 1].tag = "barrackrotate";
                                        gameManager.gridArray[i - 2, j].tag = "barrackrotate";
                                        gameManager.gridArray[i - 2, j - 1].tag = "barrackrotate";

                                        //We need to collect all points of buildings so this solution prevent some errors
                                        gameManager.barrackList.Add(new Image[6]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j - 1],
                                        gameManager.gridArray[i - 1, j],
                                        gameManager.gridArray[i - 1, j - 1],
                                        gameManager.gridArray[i - 2, j],
                                        gameManager.gridArray[i - 2, j - 1]}
                                        );

                                        //To understand which barrack we want to see
                                        gameManager.barrackCount++;
                                        count.text = "b" + gameManager.barrackList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 1, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "b" + gameManager.barrackCount.ToString();
                                        gameManager.gridArray[i - 2, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
        else if (PlayerPrefs.GetString("buildingType") == "towncenterbuild")
        {
            for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 0 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY - 1)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i, j + 1].tag == "grid" &&
                                        gameManager.gridArray[i - 1, j].tag == "grid" && gameManager.gridArray[i - 1, j + 1].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i, j + 1].color = Color.black;
                                        gameManager.gridArray[i - 1, j].color = Color.black;
                                        gameManager.gridArray[i - 1, j + 1].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "towncenter";
                                        gameManager.gridArray[i, j + 1].tag = "towncenter";
                                        gameManager.gridArray[i - 1, j].tag = "towncenter";
                                        gameManager.gridArray[i - 1, j + 1].tag = "towncenter";

                                        gameManager.towncenterList.Add(new Image[4]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j+1],
                                        gameManager.gridArray[i-1, j],
                                        gameManager.gridArray[i-1, j+1] }
                                        );

                                        gameManager.towncenterCount++;
                                        count.text = "tc" + gameManager.towncenterList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "tc" + gameManager.towncenterCount.ToString();
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "tc" + gameManager.towncenterCount.ToString();
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "tc" + gameManager.towncenterCount.ToString();
                                        gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }             
        }
        else if (PlayerPrefs.GetString("buildingType") == "towerbuild")
        {
            if (PlayerPrefs.GetInt("towerrotate") == 0)
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 1 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY - 2)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i - 1, j].tag == "grid" &&
                                        gameManager.gridArray[i - 2, j].tag == "grid" && gameManager.gridArray[i - 2, j + 1].tag == "grid" &&
                                        gameManager.gridArray[i - 2, j + 2].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i - 1, j].color = Color.black;
                                        gameManager.gridArray[i - 2, j].color = Color.black;
                                        gameManager.gridArray[i - 2, j + 1].color = Color.black;
                                        gameManager.gridArray[i - 2, j + 2].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "tower";
                                        gameManager.gridArray[i - 1, j].tag = "tower";
                                        gameManager.gridArray[i - 2, j].tag = "tower";
                                        gameManager.gridArray[i - 2, j + 1].tag = "tower";
                                        gameManager.gridArray[i - 2, j + 2].tag = "tower";

                                        gameManager.towerList.Add(new Image[5]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i-1, j],
                                        gameManager.gridArray[i-2, j],
                                        gameManager.gridArray[i-2, j+1],
                                        gameManager.gridArray[i-2, j+2] }
                                        );

                                        gameManager.towerCount++;
                                        count.text = "t" + gameManager.towerList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i - 2, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i - 2, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (PlayerPrefs.GetInt("towerrotate") == 1)
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i >= 0 && i < gameManager.gridX - 2 && j >= 0 && j < gameManager.gridY - 2)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i, j + 1].tag == "grid" &&
                                        gameManager.gridArray[i, j + 2].tag == "grid" && gameManager.gridArray[i + 1, j + 2].tag == "grid" &&
                                        gameManager.gridArray[i + 2, j + 2].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i, j + 1].color = Color.black;
                                        gameManager.gridArray[i, j + 2].color = Color.black;
                                        gameManager.gridArray[i + 1, j + 2].color = Color.black;
                                        gameManager.gridArray[i + 2, j + 2].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "tower";
                                        gameManager.gridArray[i, j + 1].tag = "tower";
                                        gameManager.gridArray[i, j + 2].tag = "tower";
                                        gameManager.gridArray[i + 1, j + 2].tag = "tower";
                                        gameManager.gridArray[i + 2, j + 2].tag = "tower";

                                        gameManager.towerList.Add(new Image[5]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j + 1],
                                        gameManager.gridArray[i, j + 2],
                                        gameManager.gridArray[i + 1, j + 2],
                                        gameManager.gridArray[i + 2, j + 2] }
                                        );

                                        gameManager.towerCount++;
                                        count.text = "t" + gameManager.towerList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i + 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i + 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i + 2, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i + 2, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (PlayerPrefs.GetInt("towerrotate") == 2)
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i >= 0 && i < gameManager.gridX - 2 && j > 1 && j < gameManager.gridY)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i + 1, j].tag == "grid" &&
                                        gameManager.gridArray[i + 2, j].tag == "grid" && gameManager.gridArray[i + 2, j - 1].tag == "grid" &&
                                        gameManager.gridArray[i + 2, j - 2].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i + 1, j].color = Color.black;
                                        gameManager.gridArray[i + 2, j].color = Color.black;
                                        gameManager.gridArray[i + 2, j - 1].color = Color.black;
                                        gameManager.gridArray[i + 2, j - 2].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "tower";
                                        gameManager.gridArray[i + 1, j].tag = "tower";
                                        gameManager.gridArray[i + 2, j].tag = "tower";
                                        gameManager.gridArray[i + 2, j - 1].tag = "tower";
                                        gameManager.gridArray[i + 2, j - 2].tag = "tower";

                                        gameManager.towerList.Add(new Image[5]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i + 1, j],
                                        gameManager.gridArray[i + 2, j],
                                        gameManager.gridArray[i + 2, j - 1],
                                        gameManager.gridArray[i + 2, j - 2] }
                                        );

                                        gameManager.towerCount++;
                                        count.text = "t" + gameManager.towerList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i + 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i + 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i + 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i + 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i + 2, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i + 2, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i + 2, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i + 2, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (PlayerPrefs.GetInt("towerrotate") == 3)
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 1 && i < gameManager.gridX && j > 1 && j < gameManager.gridY)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i, j - 1].tag == "grid" &&
                                        gameManager.gridArray[i, j - 2].tag == "grid" && gameManager.gridArray[i - 1, j - 2].tag == "grid" &&
                                        gameManager.gridArray[i - 2, j - 2].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i, j - 1].color = Color.black;
                                        gameManager.gridArray[i, j - 2].color = Color.black;
                                        gameManager.gridArray[i - 1, j - 2].color = Color.black;
                                        gameManager.gridArray[i - 2, j - 2].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "tower";
                                        gameManager.gridArray[i, j - 1].tag = "tower";
                                        gameManager.gridArray[i, j - 2].tag = "tower";
                                        gameManager.gridArray[i - 1, j - 2].tag = "tower";
                                        gameManager.gridArray[i - 2, j - 2].tag = "tower";

                                        gameManager.towerList.Add(new Image[5]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j - 1],
                                        gameManager.gridArray[i, j - 2],
                                        gameManager.gridArray[i - 1, j - 2],
                                        gameManager.gridArray[i - 2, j - 2] }
                                        );

                                        gameManager.towerCount++;
                                        count.text = "t" + gameManager.towerList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i - 1, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "t" + gameManager.towerCount.ToString();
                                        gameManager.gridArray[i - 2, j - 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (PlayerPrefs.GetString("buildingType") == "factorybuild")
        {
            if (PlayerPrefs.GetInt("factoryrotate") == 0)
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 0 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY - 3)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i, j + 1].tag == "grid" &&
                                        gameManager.gridArray[i, j + 2].tag == "grid" && gameManager.gridArray[i, j + 3].tag == "grid" &&
                                        gameManager.gridArray[i - 1, j].tag == "grid" && gameManager.gridArray[i - 1, j + 1].tag == "grid" &&
                                        gameManager.gridArray[i - 1, j + 2].tag == "grid" && gameManager.gridArray[i - 1, j + 3].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i, j + 1].color = Color.black;
                                        gameManager.gridArray[i, j + 2].color = Color.black;
                                        gameManager.gridArray[i, j + 3].color = Color.black;
                                        gameManager.gridArray[i - 1, j].color = Color.black;
                                        gameManager.gridArray[i - 1, j + 1].color = Color.black;
                                        gameManager.gridArray[i - 1, j + 2].color = Color.black;
                                        gameManager.gridArray[i - 1, j + 3].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "factory";
                                        gameManager.gridArray[i, j + 1].tag = "factory";
                                        gameManager.gridArray[i, j + 2].tag = "factory";
                                        gameManager.gridArray[i, j + 3].tag = "factory";
                                        gameManager.gridArray[i - 1, j].tag = "factory";
                                        gameManager.gridArray[i - 1, j + 1].tag = "factory";
                                        gameManager.gridArray[i - 1, j + 2].tag = "factory";
                                        gameManager.gridArray[i - 1, j + 3].tag = "factory";

                                        gameManager.factorykList.Add(new Image[8]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j+1],
                                        gameManager.gridArray[i, j+2],
                                        gameManager.gridArray[i, j+3],
                                        gameManager.gridArray[i-1, j],
                                        gameManager.gridArray[i-1, j+1],
                                        gameManager.gridArray[i-1, j+2],
                                        gameManager.gridArray[i-1, j+3] }
                                        );


                                        gameManager.factoryCount++;
                                        count.text = "f" + gameManager.factorykList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 1, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < gameManager.gridX; i++)
                {
                    for (int j = 0; j < gameManager.gridY; j++)
                    {
                        if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                        {
                            if (gameManager.gridArray[i, j].tag == "grid")
                            {
                                if (i > 2 && i < gameManager.gridX && j > 0 && j < gameManager.gridY)
                                {
                                    if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i - 1, j].tag == "grid" &&
                                        gameManager.gridArray[i - 2, j].tag == "grid" && gameManager.gridArray[i - 3, j].tag == "grid" &&
                                        gameManager.gridArray[i, j - 1].tag == "grid" && gameManager.gridArray[i - 1, j - 1].tag == "grid" &&
                                        gameManager.gridArray[i - 2, j - 1].tag == "grid" && gameManager.gridArray[i - 3, j - 1].tag == "grid")
                                    {

                                        audioSource.PlayOneShot(audioClip);

                                        gameManager.gridArray[i, j].color = Color.black;
                                        gameManager.gridArray[i - 1, j].color = Color.black;
                                        gameManager.gridArray[i - 2, j].color = Color.black;
                                        gameManager.gridArray[i - 3, j].color = Color.black;
                                        gameManager.gridArray[i, j - 1].color = Color.black;
                                        gameManager.gridArray[i - 1, j - 1].color = Color.black;
                                        gameManager.gridArray[i - 2, j - 1].color = Color.black;
                                        gameManager.gridArray[i - 3, j - 1].color = Color.black;

                                        gameManager.gridArray[i, j].tag = "factoryrotate";
                                        gameManager.gridArray[i - 1, j].tag = "factoryrotate";
                                        gameManager.gridArray[i - 2, j].tag = "factoryrotate";
                                        gameManager.gridArray[i - 3, j].tag = "factoryrotate";
                                        gameManager.gridArray[i, j - 1].tag = "factoryrotate";
                                        gameManager.gridArray[i - 1, j - 1].tag = "factoryrotate";
                                        gameManager.gridArray[i - 2, j - 1].tag = "factoryrotate";
                                        gameManager.gridArray[i - 3, j - 1].tag = "factoryrotate";

                                        gameManager.factorykList.Add(new Image[8]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i - 1, j],
                                        gameManager.gridArray[i - 2, j],
                                        gameManager.gridArray[i - 3, j],
                                        gameManager.gridArray[i, j - 1],
                                        gameManager.gridArray[i - 1, j - 1],
                                        gameManager.gridArray[i - 2, j - 1],
                                        gameManager.gridArray[i - 3, j - 1] }
                                        );

                                        gameManager.factoryCount++;
                                        count.text = "f" + gameManager.factorykList.Count.ToString();
                                        count.color = Color.white;
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;     
                                                                                                                                                       
                                        gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;     
                                                                                                                                                       
                                        gameManager.gridArray[i - 3, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 3, j ].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;    
                                                                                                                                                       
                                        gameManager.gridArray[i, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 1, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 1, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 2, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 2, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                        gameManager.gridArray[i - 3, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "f" + gameManager.factoryCount.ToString();
                                        gameManager.gridArray[i - 3, j - 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }
            }
                
        }
        else if (PlayerPrefs.GetString("buildingType") == "airportbuild")
        {
            for (int i = 0; i < gameManager.gridX; i++)
            {
                for (int j = 0; j < gameManager.gridY; j++)
                {
                    if (gameObject.GetComponent<RectTransform>().anchoredPosition == gameManager.gridArray[i, j].GetComponent<RectTransform>().anchoredPosition)
                    {
                        if (gameManager.gridArray[i, j].tag == "grid")
                        {
                            if (i > 2 && i < gameManager.gridX && j >= 0 && j < gameManager.gridY - 3)
                            {
                                if (gameManager.gridArray[i, j].tag == "grid" && gameManager.gridArray[i, j + 1].tag == "grid" &&
                                    gameManager.gridArray[i, j + 2].tag == "grid" && gameManager.gridArray[i, j + 3].tag == "grid" &&
                                    gameManager.gridArray[i - 1, j].tag == "grid" && gameManager.gridArray[i - 1, j + 1].tag == "grid" &&
                                    gameManager.gridArray[i - 1, j + 2].tag == "grid" && gameManager.gridArray[i - 1, j + 3].tag == "grid" &&
                                    gameManager.gridArray[i - 2, j].tag == "grid" && gameManager.gridArray[i - 2, j + 1].tag == "grid" &&
                                    gameManager.gridArray[i - 2, j + 2].tag == "grid" && gameManager.gridArray[i - 2, j + 3].tag == "grid" &&
                                    gameManager.gridArray[i - 3, j].tag == "grid" && gameManager.gridArray[i - 3, j + 1].tag == "grid" &&
                                    gameManager.gridArray[i - 3, j + 2].tag == "grid" && gameManager.gridArray[i - 3, j + 3].tag == "grid")
                                {

                                    audioSource.PlayOneShot(audioClip);

                                    gameManager.gridArray[i, j].color = Color.black;
                                    gameManager.gridArray[i, j + 1].color = Color.black;
                                    gameManager.gridArray[i, j + 2].color = Color.black;
                                    gameManager.gridArray[i, j + 3].color = Color.black;
                                    gameManager.gridArray[i - 1, j].color = Color.black;
                                    gameManager.gridArray[i - 1, j + 1].color = Color.black;
                                    gameManager.gridArray[i - 1, j + 2].color = Color.black;
                                    gameManager.gridArray[i - 1, j + 3].color = Color.black;
                                    gameManager.gridArray[i - 2, j].color = Color.black;
                                    gameManager.gridArray[i - 2, j + 1].color = Color.black;
                                    gameManager.gridArray[i - 2, j + 2].color = Color.black;
                                    gameManager.gridArray[i - 2, j + 3].color = Color.black;
                                    gameManager.gridArray[i - 3, j].color = Color.black;
                                    gameManager.gridArray[i - 3, j + 1].color = Color.black;
                                    gameManager.gridArray[i - 3, j + 2].color = Color.black;
                                    gameManager.gridArray[i - 3, j + 3].color = Color.black;

                                    gameManager.gridArray[i, j].tag = "airport";
                                    gameManager.gridArray[i, j + 1].tag = "airport";
                                    gameManager.gridArray[i, j + 2].tag = "airport";
                                    gameManager.gridArray[i, j + 3].tag = "airport";
                                    gameManager.gridArray[i - 1, j].tag = "airport";
                                    gameManager.gridArray[i - 1, j + 1].tag = "airport";
                                    gameManager.gridArray[i - 1, j + 2].tag = "airport";
                                    gameManager.gridArray[i - 1, j + 3].tag = "airport";
                                    gameManager.gridArray[i - 2, j].tag = "airport";
                                    gameManager.gridArray[i - 2, j + 1].tag = "airport";
                                    gameManager.gridArray[i - 2, j + 2].tag = "airport";
                                    gameManager.gridArray[i - 2, j + 3].tag = "airport";
                                    gameManager.gridArray[i - 3, j].tag = "airport";
                                    gameManager.gridArray[i - 3, j + 1].tag = "airport";
                                    gameManager.gridArray[i - 3, j + 2].tag = "airport";
                                    gameManager.gridArray[i - 3, j + 3].tag = "airport";

                                    gameManager.airportList.Add(new Image[16]  {
                                        gameManager.gridArray[i, j],
                                        gameManager.gridArray[i, j+1],
                                        gameManager.gridArray[i, j+2],
                                        gameManager.gridArray[i, j+3],
                                        gameManager.gridArray[i-1, j],
                                        gameManager.gridArray[i-1, j+1],
                                        gameManager.gridArray[i-1, j+2],
                                        gameManager.gridArray[i-1, j+3],
                                        gameManager.gridArray[i-2, j],
                                        gameManager.gridArray[i-2, j+1],
                                        gameManager.gridArray[i-2, j+2],
                                        gameManager.gridArray[i-2, j+3],
                                        gameManager.gridArray[i-3, j],
                                        gameManager.gridArray[i-3, j+1],
                                        gameManager.gridArray[i-3, j+2],
                                        gameManager.gridArray[i-3, j+3] }
                                    );


                                    gameManager.airportCount++;
                                    count.text = "a" + gameManager.airportList.Count.ToString();
                                    count.color = Color.white;
                                    gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 1, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 1, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 1, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 1, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 1, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 2, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 2, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 2, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 2, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 2, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 2, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 2, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 3, j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 3, j].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 3, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 3, j + 1].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 3, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 3, j + 2].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;

                                    gameManager.gridArray[i - 3, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "a" + gameManager.airportCount.ToString();
                                    gameManager.gridArray[i - 3, j + 3].gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                                }
                            }
                        }
                    }
                }
            }
        }   
    }

}
