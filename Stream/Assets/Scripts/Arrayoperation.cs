using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrayoperation : Operation
{
    public override void ChangeCondition(Transform button)
    {
        AudioManager.Instance.Play_buttonon();

        if (button.name == "array_up_collider")
        {
            if (for_number != 4 && lerp_finished && !operation_started)
                for_number++;
        }
        else if (button.name == "array_down_collider")
        {
            if (for_number != 0 && lerp_finished && !operation_started)
                for_number--;
        }
    }
    public override void Toggle()
    {
        if(for_current!=0)
        operation_started = !operation_started;
        if (operation_started&&for_current!=0)
        {
            button.GetComponent<SpriteRenderer>().enabled = false;
            button_pressed.GetComponent<SpriteRenderer>().enabled = true;
            liquidOutput.TurnOnLiquid();
            started = true;
            AudioManager.Instance.Play_buttonon();
        }
        else
        {
            button.GetComponent<SpriteRenderer>().enabled = true;
            button_pressed.GetComponent<SpriteRenderer>().enabled = false;
            liquidOutput.TurnOffLiquid();
            AudioManager.Instance.Play_buttonoff();
        }
    }

    public Transform button;
    public Transform button_pressed;
    public LiquidSpawn liquidOutput;
    public Transform number_transform;
    public Color water_color;
    public Color[] array_colors;
    private bool lerp_finished = true;
    private int for_number;
    private int for_current;
    private bool started;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        ChangeNumber();
        ChangeColor();
    }
    void ChangeColor()
    {
        if (operation_started&&for_current!=0)
        {
            water_color = array_colors[for_current -1];
            GameController.Instance.color_r = water_color;
            liquidOutput.water_color = water_color;
            liquidOutput.SetWaterColor(water_color, "_Color_r");            
        }
    }
    void ChangeNumber()
    {
        if (for_current != for_number)
        {
            lerp_finished = false;
            if (for_current == 0 && for_number == 1)
            {
                OnLerp(-4.7f);
            }
            else if (for_current == 1 && for_number == 2)
            {
                OnLerp(-3.14f);
            }
            else if (for_current == 2 && for_number == 3)
            {
                OnLerp(-1.29f);
            }
            else if (for_current == 3 && for_number == 4)
            {
                OnLerp(0.59f);
            }
            else if (for_current == 1 && for_number == 0)
            {
                OnLerp(-6.4f);
            }
            else if (for_current == 2 && for_number == 1)
            {
                OnLerp(-4.7f);
            }
            else if (for_current == 3 && for_number == 2)
            {
                OnLerp(-3.14f);
            }
            else if (for_current == 4 && for_number == 3)
            {
                OnLerp(-1.29f);
            }
        }
    }

    void OnLerp(float dest_y)
    {
        if (!lerp_finished)
        {
            number_transform.localPosition = Vector2.Lerp(new Vector2(number_transform.localPosition.x, number_transform.localPosition.y),
            new Vector2(number_transform.localPosition.x, dest_y), 5f*Time.deltaTime);
        }

        if (Mathf.Abs(number_transform.transform.localPosition.y - dest_y) < 0.05f)
        {
            lerp_finished = true;
            number_transform.transform.localPosition = new Vector2(number_transform.transform.localPosition.x, dest_y);
            for_current = for_number;
        }
    }
}
