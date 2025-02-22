using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

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

    [Header("UI Upgrade to Update")]
    public int valueToUp;
    public TextMeshProUGUI txtValueToUp;

    [Header("Slider")]
    public Slider slider; 
    
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
        

        ValueGoldToUp();
        SetValuesToUp();

        slider.gameObject.SetActive(true);

    }


    public void BaseUpgrade(int currentClicks)
    {
        if (player == null || spriteRenderer == null || gold == null || currentUpgradeIndex >= upgrades.Count) return;

        objectClickCounter = currentClicks;

        ValueGoldToUp();
        SliderValueToUp();

        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        if (objectClickCounter >= nextUpgrade.clicksToUp && gold.goldCounter >= nextUpgrade.goldToUp)
        {
            gold.goldCounter -= nextUpgrade.goldToUp;
            
            spriteRenderer.color = nextUpgrade.upgradeColor;
            spriteRenderer.sprite = nextUpgrade.upgradeSprite;
            gold.goldCounter += nextUpgrade.goldWin;

            currentUpgradeIndex++;
            
            SetValuesToUp();
        }
    }

    private void SetValuesToUp()
    {
        if (currentUpgradeIndex >= upgrades.Count) return;
        
        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        slider.maxValue = nextUpgrade.clicksToUp - objectClickCounter;
        slider.value = slider.maxValue;

    }

    private void SliderValueToUp()
    {
        if (currentUpgradeIndex >= upgrades.Count) return;

        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        valueToUp = nextUpgrade.clicksToUp - objectClickCounter;

        slider.value = valueToUp;
    }



    private void ValueGoldToUp()
    {
        // ultimo valor da lista
        int lastUpgrade = upgrades.Count - 1;

        if (currentUpgradeIndex >= lastUpgrade)
        {
            txtValueToUp.text = "MAX UP";
            slider.gameObject.SetActive(false);
            
            return;
        }


        // lista e valor de ouro
        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        valueToUp = nextUpgrade.goldToUp;

        txtValueToUp.text = "Gold:" + valueToUp.ToString();
  
    }
}

