using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBaseUpgrade : MonoBehaviour
{
    private Player player;

    private bool _baseUpgrade;

    public bool baseUpgrade
    {
        get { return _baseUpgrade; }
        set { _baseUpgrade = value; }
    }

    private void Start()
    {
        
    }

    public void BaseUpgrade()
    {
        // clicar nos predios - upgrade
        _baseUpgrade = false;
    }
}
