using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ifoperation : Operation
{
    public override void TurnOn()
    {
        liquidoutput1.TurnOnLiquid();
        liquidoutput2.TurnOnLiquid();
    }

    public override void TurnOff()
    {
        liquidoutput1.TurnOffLiquid();
        liquidoutput2.TurnOffLiquid();
    }

    public LiquidSpawn liquidoutput1;
    public LiquidSpawn liquidoutput2;

    // Start is called before the first frame update
    void Start()
    {
        liquidoutput1.TurnOffLiquid();
        liquidoutput2.TurnOffLiquid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("StreamCollider"))
        {
            TurnOff();
        }
    }
}
