using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public Player player;

    [Header("Gold text")]
    public int gold;
    public TextMeshProUGUI goldText;

    [Header("Clicks Text")]

    public TextMeshProUGUI clicksText;


    public void Update()
    {
        goldText.text = gold.ToString();
        clicksText.text = player.clicks.ToString();
    }
}
