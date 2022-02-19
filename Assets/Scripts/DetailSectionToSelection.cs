using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailSectionToSelection : MonoBehaviour
{
    public GameObject barrackDeatils;
    public PutNewBuild put;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void PutHere()
    {
        put.FindArrayIndex();
    }

    public void RotateBuilding()
    {
        if (PlayerPrefs.GetString("buildingType")  == "barrackbuild")
        {

        }
    }
}
