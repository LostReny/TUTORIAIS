using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<BuildingBaseUpgrade> buildingUpgrade = new List<BuildingBaseUpgrade>();

    private Vector3 pos;
    public float speed = 1f;
    

    private void Start()
    {
        // pega o objeto camera e adiciona no script
        GameObject MainCamera = GameObject.Find("Main Camera");
        if (MainCamera != null)
        {
            mainCamera = MainCamera.GetComponent<Camera>();
        }

    }

    private void Update()
    {
        MoveToMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);


            foreach (var building in buildingUpgrade)
            {
                if (hit.collider == building._collider)
                {
                    building.objectClickCounter++;
                    building.BaseUpgrade(building.objectClickCounter);
                    break;
                }
            }
        }

    }

    public void MoveToMouse()
    {
        pos = Input.mousePosition;
        pos.z = speed;
        transform.position = mainCamera.ScreenToWorldPoint(pos);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

}
