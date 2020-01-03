using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Transform currentSelection;
    bool moving;
    LayerMask Moveable = 1 << 8;
    LayerMask Clickable = 1 << 9;
    public Camera cam;

    private Vector2 offset;

    private void Update()
    {
        Drag();
        Click();

    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,10,Clickable);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("StartOperation"))
                {
                    hit.transform.parent.GetComponentInParent<Operation>().TurnOn();
                }
                else if (hit.collider.CompareTag("SetCondition"))
                {
                    hit.transform.parent.parent.GetComponent<Animator>().SetBool("isSettingCondition",true);
                }
                else if (hit.collider.CompareTag("IfCondition_set"))
                {
                    hit.transform.parent.GetComponentInParent<Operation>().SetCondition();
                }
            }
        }
    }

    private void Drag()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,10,Moveable);
            if (!moving)
            {
                if (hit.collider != null)
                {
                    if (hit.transform.CompareTag("Operation"))
                    {
                        currentSelection = hit.transform;
                        moving = true;
                        offset = new Vector2(hit.point.x-currentSelection.position.x, hit.point.y - currentSelection.position.y);
                    }
                }
            }
            else
            {
                Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 temp = Camera.main.ScreenToWorldPoint(MousePosition);
                currentSelection.position = new Vector3(temp.x-offset.x, temp.y-offset.y, 0);
            }
        }
        else
        {
            currentSelection = null;
            moving = false;
        }
    }
}
