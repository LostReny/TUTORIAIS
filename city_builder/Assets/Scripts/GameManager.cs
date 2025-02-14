using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public Player player;
    public GoldBase goldBase;
    public BuildingBaseUpgrade upgrade;

    [Header("Gold text")]
    public int gold;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI goldTextToUp;

    [Header("Clicks Text")]

    public TextMeshProUGUI clicksText;


    public void Update()
    {
        goldText.text = goldBase.goldCounter.ToString();
        clicksText.text = player.clicks.ToString();
    }


}
