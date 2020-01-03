using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawn : MonoBehaviour
{
    public GameObject liquidParticle;

    [Range(0,100)]
    public float flowRate; //how often instantiate water particle

    [Range(0, 1f)]
    public float randomRange; //random spawn position at y direction

    public bool Liquidon { get; private set; }
    private float timer;

    void Start()
    {
        
    }
    void Update()
    {
        if (Liquidon)
        {
            timer += Time.deltaTime;
            if (timer > 1/flowRate)
            {
                Vector3 random_spawn = new Vector3(this.transform.position.x + Random.Range(-randomRange, randomRange), this.transform.position.y, this.transform.position.z);
                Instantiate(liquidParticle, random_spawn, Quaternion.identity, this.transform);
                timer = 0;
            }
        }
    }

    public void TurnOnLiquid()
    {
        Liquidon = true;
    }

    public void TurnOffLiquid()
    {
        Liquidon = false;
    }

    public void SwapParticle()
    {

    }
}
