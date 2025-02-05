using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBase : MonoBehaviour
{
    [SerializeField] private int _goldCounter = 0;

    public int goldCounter
    {
        get { return _goldCounter; }
        set { _goldCounter = value; }
    }

    private void Start()
    {
        StartCoroutine(GoldEverySecond());
    }

    private IEnumerator GoldEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _goldCounter++;
        }
    }
}
