using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public SpriteRenderer default_sprite;
    public SpriteRenderer mouseOn;
    public SpriteRenderer click;

    void Start()
    {
        default_sprite = this.GetComponent<SpriteRenderer>();
        mouseOn = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        click = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void MouseOn()
    {
        default_sprite.enabled = false;
        mouseOn.enabled = true;
        click.enabled = false;
    }
    public void Default()
    {
        default_sprite.enabled = true;
        mouseOn.enabled = false;
        click.enabled = false;
    }

    public void Click()
    {
        default_sprite.enabled = false;
        mouseOn.enabled = false;
        click.enabled = true;
    }


    void OnMouseOver()
    {
        MouseOn();
    }

    void OnMouseExit()
    {
        Default();
    }

    void OnMouseDown()
    {
        Click();
    }
}