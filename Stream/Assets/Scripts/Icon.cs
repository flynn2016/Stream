using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Icon : MonoBehaviour
{
    public SpriteRenderer default_sprite;
    public SpriteRenderer mouseOn;
    public SpriteRenderer click;

    private bool instruction_toggle;
    private bool is_mouseover;

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
        if(!is_mouseover)
            MouseOn();
        is_mouseover = true;
    }

    void OnMouseExit()
    {
        is_mouseover = false;
        Default();
    }

    private void OnMouseDown()
    {
        Click();
    }

    void OnMouseUp()
    {
        if (this.name == "ChooseLevel")
        {
            SceneManager.LoadScene("Levels");
        }
        else if(this.name == "Exit")
        {
            Application.Quit();
        }
        else if(this.name == "instruction")
        {
            if (!instruction_toggle)
            {
                GameController.Instance.instruction.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GameController.Instance.instruction.GetComponent<SpriteRenderer>().enabled = false;
            }
            instruction_toggle = !instruction_toggle;
        }
        else if(this.name == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}