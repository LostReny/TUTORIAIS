using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoldPopUp : MonoBehaviour
{
    [SerializeField] private GameObject pfGoldToUpPopUp;

    private void Start()
    {
        //TxtPopUp();
    }

    /*private void TxtPopUp()
    {
        Canvas uiCanvasOne = GameObject.Find("UICanvas1").GetComponent<Canvas>();
        Canvas uiCanvasTwo = GameObject.Find("UICanvas2").GetComponent<Canvas>();

        GoldPopUp goldPopUp = FindObjectOfType<GoldPopUp>();
        goldPopUp.PopUpText(uiCanvasOne);
        goldPopUp.PopUpText(uiCanvasTwo);
    }*/


    private void PopUpText(Canvas parentCanvas)
    {
        if (pfGoldToUpPopUp != null)
        {
            GameObject newPopUpTxt = Instantiate(pfGoldToUpPopUp, transform.position, Quaternion.identity);

            if (newPopUpTxt.GetComponent<RectTransform>() != null)
            {
                if (parentCanvas != null) 
                {
                    newPopUpTxt.transform.SetParent(parentCanvas.transform, false);
                }
                
            }
        }
    }
}
