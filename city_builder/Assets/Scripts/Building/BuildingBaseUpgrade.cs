using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Upgrade
{
    public int clicksToUp;
    public Color upgradeColor;
    public Sprite upgradeSprite;
    public int goldToUp;
    public int goldWin;
}


public class BuildingBaseUpgrade : MonoBehaviour
{
    public Player player;

    public GoldBase gold;

    public Collider2D _collider;
    
    public GameObject targetObject;
    
    public int objectClickCounter = 0;
    
    [SerializeField] private List<Upgrade> upgrades = new List<Upgrade>();

    private Color lastAppliedColor;
    private SpriteRenderer spriteRenderer;
    private int currentUpgradeIndex = 0;


    private void Start()
    {
        if (targetObject != null)
        {
            spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            _collider = targetObject.GetComponent<Collider2D>();
        }
        else
        {
            Debug.LogError("Target Object não está definido.");
        }
        

    }


    public void BaseUpgrade(int currentClicks)
    {
        if (player == null || spriteRenderer == null || gold == null || currentUpgradeIndex >= upgrades.Count) return;

        objectClickCounter = currentClicks;
        
        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        if (objectClickCounter >= nextUpgrade.clicksToUp && gold.goldCounter >= nextUpgrade.goldToUp)
        {
            gold.goldCounter -= nextUpgrade.goldToUp;
            
            spriteRenderer.color = nextUpgrade.upgradeColor;
            spriteRenderer.sprite = nextUpgrade.upgradeSprite;
            gold.goldCounter += nextUpgrade.goldWin;

            currentUpgradeIndex++;
  
        }
    }
}

