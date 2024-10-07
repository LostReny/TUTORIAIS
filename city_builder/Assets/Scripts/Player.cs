using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _onClick;
    private BuildingBaseUpgrade baseBuildUpgrade; 

    public bool onClick
    {
        get { return _onClick; }
        set { _onClick = value; }
    }

    public void Update()
    {
        OnClick();
    }

    public void OnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _onClick = true;
            //baseBuildUpgrade.baseUpgrade = true;
            Debug.Log("Upgrade");
        }
        if (Input.GetMouseButtonUp(0))
        {
            _onClick = false;
            //baseBuildUpgrade.baseUpgrade = false;
        }
    }

    // clicar nos predios - upgrade 

}
