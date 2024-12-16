using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBaseUpgrade : MonoBehaviour
{
    public Player player;

    private bool _baseUpgrade;

    public GameObject targetObject;
    private SpriteRenderer spriteRenderer;

    public bool baseUpgrade
    {
        get { return _baseUpgrade; }
        set { _baseUpgrade = value; }
    }


     private void Start()
    {
        if (targetObject != null)
        {
            spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        }
        else
        {
            Debug.LogError("Target Object não está definido.");
        }
    }

    private void Update()
    {
        BaseUpgrade();
    }


// transformar essa parte do base upgrade em uma coroutina

    public void BaseUpgrade()
    {
           if (player != null && player.clicks == 10 && !_baseUpgrade)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.red;

                _baseUpgrade = true;
                Debug.Log("Upgrade building - cor alterada para vermelho.");
            }
            
        }
    }
}
