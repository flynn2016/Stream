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

    public override void ChangeCondition()
    {
        turning = true;
    }

    public LiquidSpawn liquidoutput1;
    public LiquidSpawn liquidoutput2;
    public GameObject Particle_red;
    public GameObject Particle_blue;
    public Transform condition;
    private bool turning;
    private int count;
    private bool accepting_water;
    private int water_count;
    private int water_count_prev;

    // Start is called before the first frame update
    void Start()
    {
        liquidoutput1.TurnOffLiquid();
        liquidoutput2.TurnOffLiquid();
    }

    // Update is called once per frame
    void Update()
    {
        if (turning)
        {
            count += 5;
            condition.eulerAngles = new Vector3(condition.eulerAngles.x, condition.eulerAngles.y, condition.eulerAngles.z + 5);
            if (count == 180)
            {
                count = 0;
                turning = false;
            }
        }

        if(Mathf.Abs(condition.eulerAngles.z)<= 0.1f)
        {
            liquidoutput1.liquidParticle = Particle_blue;
            liquidoutput2.liquidParticle = Particle_red;
        }
        else
        {
            liquidoutput1.liquidParticle = Particle_red;
            liquidoutput2.liquidParticle = Particle_blue;
        }

        //dumb way to detect exit water flow
        if (water_count > water_count_prev)
        {
            accepting_water = true;
        }
        else
        {
            accepting_water = false;
        }

        water_count_prev = water_count;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        water_count++;
    }
}

