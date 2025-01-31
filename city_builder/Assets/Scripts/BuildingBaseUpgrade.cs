using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public int clicksToUp;
    public Color upgradeColor;
}


public class BuildingBaseUpgrade : MonoBehaviour
{
    public Player player;

    public int _clicksForUpgrade;

    public GameObject targetObject;
   [SerializeField] private List<Upgrade> upgrades = new List<Upgrade>();

    private Color lastAppliedColor;
    private SpriteRenderer spriteRenderer;


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


    /*public void BaseUpgrade()
    {
        //pego o valor de clique do player e transformo em uma variavel
        _clicksForUpgrade = player.clicks;

        if (player != null && _clicksForUpgrade == 10 && _clicksForUpgrade < 20)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.red;

                //_baseUpgrade = true;
                Debug.Log("Upgrade building - cor alterada para vermelho.");
            }
        }

        else if (player != null && _clicksForUpgrade == 20 && _clicksForUpgrade < 40)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.yellow;

                //_baseUpgrade = true;
                Debug.Log("Upgrade building - cor alterada para amarelo.");
            }
        }

    }
    */
    //

    private void BaseUpgrade()
    {
        if (player == null || spriteRenderer == null) return;
        
        _clicksForUpgrade = player.clicks;

        // Verifica qual upgrade aplicar com base nos cliques
        foreach (Upgrade upgrade in upgrades)
        {
            if (_clicksForUpgrade >= upgrade.clicksToUp )
            {
                spriteRenderer.color = upgrade.upgradeColor;
                //Debug.Log($"Upgrade aplicado - Cor alterada para {upgrade.upgradeColor}");
            }
        }
    }
}

