using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int _clickCounter = 0;

    public int clickCounter
    {
        get { return _clickCounter; }
        set { _clickCounter = value; }
    }

    public int clicks;

    public void Update()
    {
        OnClick();
    }

    public void OnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _clickCounter++;

            clicks = _clickCounter;
            Debug.Log(clicks);
        }
    }
}
