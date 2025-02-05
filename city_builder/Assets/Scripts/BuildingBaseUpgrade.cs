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

    public Collider2D _collider;

    public GameObject targetObject;
   [SerializeField] private List<Upgrade> upgrades = new List<Upgrade>();

    private Color lastAppliedColor;
    private SpriteRenderer spriteRenderer;
    private int objectClickCounter = 0;


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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (_collider != null && _collider.OverlapPoint(mousePosition))
            {
                objectClickCounter++;  // Incrementa apenas quando clica no objeto
                BaseUpgrade(objectClickCounter);  // Passa o contador específico
            }
        }
    }

    private void BaseUpgrade(int currentClicks)
    {
        if (player == null || spriteRenderer == null) return;

        _clicksForUpgrade = currentClicks;

        foreach (Upgrade upgrade in upgrades)
        {
            if (_clicksForUpgrade >= upgrade.clicksToUp)
            {
                spriteRenderer.color = upgrade.upgradeColor;

            }
        }
    }
}

