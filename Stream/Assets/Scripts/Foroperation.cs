using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foroperation : Operation
{
    public override void ChangeCondition(Transform button)
    {
        if (button.name == "for_up_collider")
        {
            if (for_number != 0 && lerp_finished && !operating)
                for_number--;
        }
        else if (button.name == "for_down_collider")
        {
            if (for_number != 4 && lerp_finished && !operating)
                for_number++;
        }
    }

    public override void Toggle()
    {
        if (filled & for_current != 0)
        {
            if (curr_state == forStates.full)
            {
                curr_state = forStates.releasing_water;
                operating = true;
                temp_pos = this.transform.position;
                temp_pos.x -= 0.8f;
            }
        }
    }

    public TriggerCounter outputcount;
    public LiquidSpawn liquidoutput;
    public LiquidSpawn liquidinput;
    public Transform measure_transform;
    public Transform number_transform;
    public SpriteRenderer lighton;
    public SpriteRenderer lightoff;

    private Color water_color;
    public int total_water;
    public int curr_water;
    public bool filled { private set; get; }
    private int water_count;
    private int water_count_prev;
    private int for_number;
    private int for_current;
    private bool lerp_finished = true;
    private bool operating;
    private int loop_times;
    private Vector2 temp_pos;
    public enum forStates { idle, accepting_water, full, releasing_water};
    private forStates curr_state;

    // Start is called before the first frame update
    void Start()
    {
        curr_water = total_water;
        liquidoutput.TurnOffLiquid();
    }

    // Update is called once per frame
    void Update()
    {
        if (curr_state == forStates.idle)
        {
            Idle();
            ChangeNumber();
        }

        else if (curr_state == forStates.accepting_water)
        {
            DetectColor();
            Accept_water();
            ChangeNumber();
            Checkfilled();
        }

        else if (curr_state == forStates.full)
        {
            Full();
            ChangeNumber();
            Checkfilled();
        }

        else if (curr_state == forStates.releasing_water)
        {
            Release_water();
        }

        if (GameController.Instance.all_finished)
        {
            liquidoutput.TurnOffLiquid();
        }

    }

    void Idle()
    {
        if (water_count > 0)
        {
            curr_state = forStates.accepting_water;
        }
    }

    void Accept_water()
    {
    }

    void Release_water()
    {
        StartOperation();
        measure_transform.localPosition = new Vector2(measure_transform.localPosition.x, -5 + 5 * (float)curr_water / total_water);
    }

    void Full()
    {
        lighton.enabled = true;
        lightoff.enabled = false;
        measure_transform.localPosition = new Vector2(measure_transform.localPosition.x, -5 + 5 * (float)curr_water / total_water);
    }

    void DetectColor()
    {
        //detecting water color
        measure_transform.GetComponent<SpriteRenderer>().color = water_color;
        liquidoutput.GetComponent<LiquidSpawn>().water_color = water_color;
    }

    void StartOperation()
    {
        if (operating)
        {
            if (outputcount.output_count>(int)(total_water/for_current))
            {
                loop_times++;
                liquidoutput.TurnOffLiquid();
                outputcount.output_count = 0;
                if (loop_times == for_current)
                {
                    operating = false;
                    curr_state = forStates.idle;
                    water_count = 0;
                }
            }
            else
            {
                this.transform.position = new Vector2(temp_pos.x+0.7f +3*loop_times, transform.position.y);
                liquidoutput.TurnOnLiquid();
            }
        }
    }
    void ChangeNumber()
    {
        if (for_current != for_number)
        {
            lerp_finished = false;
            if (for_current==0 &&for_number == 1)
            {
                OnLerp(-1.6f);
            }
            else if(for_current == 1 && for_number == 2)
            {
                OnLerp(0f);
            }
            else if (for_current == 2 && for_number == 3)
            {
                OnLerp(1.85f);
            }
            else if (for_current == 3 && for_number == 4)
            {
                OnLerp(3.7f);
            }
            else if (for_current == 1 && for_number == 0)
            {
                OnLerp(-3.14f);
            }
            else if (for_current == 2 && for_number == 1)
            {
                OnLerp(-1.6f);
            }
            else if (for_current == 3 && for_number == 2)
            {
                OnLerp(0f);
            }
            else if (for_current == 4 && for_number == 3)
            {
                OnLerp(1.85f);
            }
        }
    }
    void OnLerp(float dest_y)
    {
        if (!lerp_finished)
        {
            number_transform.localPosition = Vector2.Lerp(new Vector2(number_transform.localPosition.x, number_transform.localPosition.y),
            new Vector2(number_transform.localPosition.x, dest_y), 0.05f);
        }

        if (Mathf.Abs(number_transform.transform.localPosition.y - dest_y) < 0.05f)
        {
            lerp_finished = true;
            number_transform.transform.localPosition = new Vector2(number_transform.transform.localPosition.x,dest_y);
            for_current = for_number;
        }
    }
    void Checkfilled()
    {
        if (filled)
        {
            liquidinput.TurnOffLiquid();
            curr_state = forStates.full;
        }

        else
        {
            if (measure_transform.localPosition.y > 0)
            {
                filled = true;
            }
            else
            {
                lighton.enabled = false;
                lightoff.enabled = true;
                measure_transform.localPosition = new Vector2(measure_transform.localPosition.x, -5.0f + ((float)water_count / 50));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        water_color = col.transform.GetComponent<Particle>().particle_color;
        water_count++;
    }
}
