using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLastSibling : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt("startgrid") == 1)
        {
            olusma();
        }
    }

    public void olusma()
    {
        this.gameObject.transform.GetChild(2).SetAsLastSibling();
    }
}
