using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

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
        else
        {
            Debug.LogError("Target Object não está definido.");
        }
        
        if(upgrades.Count > 0)
        {
            SetValuesToUp();
        }
    }


    public void BaseUpgrade(int currentClicks)
    {
        if (player == null || spriteRenderer == null || gold == null || currentUpgradeIndex >= upgrades.Count) return;

        objectClickCounter = currentClicks;

        SliderValueToUp();
        MaxValue();

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
        slider.minValue = objectClickCounter;
        slider.value = nextUpgrade.clicksToUp;

    }

    private void SliderValueToUp()
    {
        if (currentUpgradeIndex >= upgrades.Count) return;

        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        valueToUp = nextUpgrade.clicksToUp - objectClickCounter;

        slider.value = valueToUp;
    }

    private void MaxValue()
    {
        // PS : ta errado
        //se a lista de upgrade chegar no final
        if(currentUpgradeIndex >= upgrades.Count)
        {
            Debug.Log("MaxUp");
            //txtValueToUp.text = "MAX UPGRADE";
        }

        //mostrar texto de MAX UPGRADE
    }

    // criar texto que mostra e atualiza - mostrando o quanto de ouro precisa 
    // texto estatico

    private void ValueGoldToUp()
    {
        Upgrade nextUpgrade = upgrades[currentUpgradeIndex];

        valueToUp = nextUpgrade.clicksToUp - objectClickCounter;

        if(valueToUp <= 5 && valueToUp > 0 )
        {
            txtValueToUp.text = valueToUp.ToString();
        }
        else 
        {
            txtValueToUp.text = "";
        }
        
    }
}

