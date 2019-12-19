using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Transform currentSelection;
    bool moving;

    public Camera cam;

    private void Update()
    {
        Drag();

        Click();


    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("StartOperation"))
                {
                    hit.transform.GetComponentInParent<Operation>().TurnOn();
                }
            }
        }
    }

    private void Drag()
    {
        if (Input.GetMouseButton(0))
        {
            if (!moving)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.transform.CompareTag("Operation"))
                    {
                        currentSelection = hit.transform;
                        moving = true;
                    }
                }
            }
            else
            {
                Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 temp = Camera.main.ScreenToWorldPoint(MousePosition);
                currentSelection.position = new Vector3(temp.x, temp.y, 0);
            }
        }
        else
        {
            currentSelection = null;
            moving = false;
        }
    }
}
