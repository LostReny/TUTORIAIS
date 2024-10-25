using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBaseUpgrade : MonoBehaviour
{
    public Player player;

    private bool _baseUpgrade;

    private Color color;

    public bool baseUpgrade
    {
        get { return _baseUpgrade; }
        set { _baseUpgrade = value; }
    }

    private void Update()
    {
        BaseUpgrade();
    }

    public void BaseUpgrade()
    {
        // clicar nos predios - upgrade
        if(player.clicks == 10)
        {
            color = Color.red;
            Debug.Log("Upgrade building");
        } 
        else
        {
            return;
        }
    }
}
