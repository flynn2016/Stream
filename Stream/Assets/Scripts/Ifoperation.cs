using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ifoperation : Operation
{
    public override void Toggle()
    {
        if (!operation_started&&accepting_water)
        {
            liquidoutput1.TurnOnLiquid();
            liquidoutput2.TurnOnLiquid();
        }
        else
        {
            liquidoutput1.TurnOffLiquid();
            liquidoutput2.TurnOffLiquid();
        }
        if (!operation_started&&accepting_water)
        {
            operation_started = true;
        }
        else
        {
            operation_started = false;
        }
    }

    public override void ChangeCondition(Transform button)
    {
        turning = true;
    }

    public LiquidSpawn liquidoutput1;
    public LiquidSpawn liquidoutput2;
    public GameObject Particle_1;
    public GameObject Particle_2;
    public Transform condition_1;
    public Transform condition_2;

    public enum ifStates {idle,accpeting_water,stopping_water};
    ifStates curr_state;

    private bool turning;
    private int count;
    private bool accepting_water;
    private Color accept_color;
    private int water_count;
    private int water_count_prev;
    private float timer;
    private Color red = new Color(1f, 100f / 255, 100f / 255);
    private Color blue = new Color(51f / 255, 153f / 255, 1f);
    private Color green = new Color(52f / 255, 204f / 255, 104f / 255f);
    private Color yellow = new Color(240f/255,240f/255,50f/255);

    // Start is called before the first frame update
    void Start()
    {
        liquidoutput1.TurnOffLiquid();
        liquidoutput2.TurnOffLiquid();
        curr_state = ifStates.idle;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(curr_state);
        if(curr_state == ifStates.idle)
        {
            Idle();
        }
        else if(curr_state == ifStates.accpeting_water)
        {
            Acceptwater();
        }
        else if (curr_state == ifStates.stopping_water)
        {
            Stopwater();
        }

        if (GameController.Instance.all_finished||operation_started==false)
        {
            liquidoutput1.TurnOffLiquid();
            liquidoutput2.TurnOffLiquid();
        }
    }

    void Idle()
    {
        DetectWater();
    }

    void Acceptwater()
    {
        Color cond_1 = Color.white;
        Color cond_2 = Color.white;
        if (Mathf.Abs(accept_color.r- 0.6f)< 0.01f &&
            Mathf.Abs(accept_color.g - 0.49f) < 0.01f &&
            Mathf.Abs(accept_color.b - 0.69f) < 0.01f)
        {
            cond_1 = red;
            cond_2 = blue;
            liquidoutput1.SetWaterColor(red,"_Color_g");
            liquidoutput2.SetWaterColor(blue, "_Color_b");
            GameController.Instance.color_g = red;
            GameController.Instance.color_b = blue;
        }

        else if (Mathf.Abs(accept_color.r - 0.2f) < 0.01f &&
            Mathf.Abs(accept_color.g - 0.67f) < 0.01f &&
            Mathf.Abs(accept_color.b - 0.70f) < 0.01f)
        {
            cond_1 = green;
            cond_2 = blue;
            liquidoutput1.SetWaterColor(green, "_Color_g");
            liquidoutput2.SetWaterColor(blue, "_Color_b");
            GameController.Instance.color_g = green;
            GameController.Instance.color_b = blue;
        }

        else if (Mathf.Abs(accept_color.r - 0.6f) < 0.01f &&
            Mathf.Abs(accept_color.g - 0.5f) < 0.01f &&
            Mathf.Abs(accept_color.b - 0.4f) < 0.01f)
        {
            cond_1 = green;
            cond_2 = red;
            liquidoutput1.SetWaterColor(green, "_Color_g");
            liquidoutput2.SetWaterColor(red, "_Color_b");
            GameController.Instance.color_g = green;
            GameController.Instance.color_b = red;
        }

        else if (Mathf.Abs(accept_color.r - 0.57f) < 0.01f &&
            Mathf.Abs(accept_color.g - 0.87f) < 0.01f &&
            Mathf.Abs(accept_color.b - 0.49f) < 0.01f)
        {
            cond_1 = yellow;
            cond_2 = green;
            liquidoutput1.SetWaterColor(yellow, "_Color_g");
            liquidoutput2.SetWaterColor(green, "_Color_b");
            GameController.Instance.color_g = yellow;
            GameController.Instance.color_b = green;
        }




        condition_1.GetComponent<SpriteRenderer>().color =
               Color.Lerp(condition_1.GetComponent<SpriteRenderer>().color,cond_1, 0.1f);
        condition_2.GetComponent<SpriteRenderer>().color =
            Color.Lerp(condition_2.GetComponent<SpriteRenderer>().color, cond_2, 0.1f);
        CheckCondition();
        if (timer%60 >= 1f)
        {
            if (water_count == water_count_prev)
            {
                accepting_water = false;
                curr_state = ifStates.stopping_water;
            }
            timer = 0;
            water_count_prev = water_count;
        }

        if (accepting_water)
        {
            timer += Time.deltaTime;
        }
    }

    void Stopwater()
    {
        condition_1.GetComponent<SpriteRenderer>().color =
               Color.Lerp(condition_1.GetComponent<SpriteRenderer>().color, Color.white, 0.1f);
        condition_2.GetComponent<SpriteRenderer>().color =
            Color.Lerp(condition_2.GetComponent<SpriteRenderer>().color, Color.white, 0.1f);
        if (condition_1.GetComponent<SpriteRenderer>().color == Color.white)
        {
            curr_state = ifStates.idle;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        water_count++;
        accept_color = col.GetComponent<Particle>().particle_color;
    }

    void DetectWater()
    {
        //detecting accepting water
        if (water_count > water_count_prev)
        {
            accepting_water = true;
            curr_state = ifStates.accpeting_water;
        }

    }

    void CheckCondition()
    {
        if (turning)
        {
            count += 5;
            condition_1.eulerAngles = new Vector3(condition_1.eulerAngles.x, condition_1.eulerAngles.y, condition_1.eulerAngles.z + 5);
            condition_2.eulerAngles = new Vector3(condition_2.eulerAngles.x, condition_2.eulerAngles.y, condition_2.eulerAngles.z + 5);

            if (count == 180)
            {
                count = 0;
                turning = false;
            }
        }

        if (Mathf.Abs(condition_1.eulerAngles.z) <= 0.1f)
        {
            liquidoutput1.liquidParticle = Particle_1;
            liquidoutput2.liquidParticle = Particle_2;
        }
        else
        {
            liquidoutput1.liquidParticle = Particle_2;
            liquidoutput2.liquidParticle = Particle_1;
        }
    }
}

