using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawn : MonoBehaviour
{
    public GameObject liquidParticle;
    public float flowRate; //how often instantiate water particle
    public float randomRange; //random spawn position at y direction

    public bool liquidon;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (liquidon)
        {
            timer += Time.deltaTime;
            if (timer > 1/flowRate)
            {
                Vector3 random_spawn = new Vector3(this.transform.position.x + Random.Range(-randomRange, randomRange), this.transform.position.y, this.transform.position.z);
                Instantiate(liquidParticle, random_spawn, Quaternion.identity, this.transform);
                timer = 0;
            }
        }

        //Debug.Log(this.name+": "+this.transform.childCount);
    }

    public void TurnOnLiquid()
    {
        liquidon = true;
    }

    public void TurnOffLiquid()
    {
        liquidon = false;
    }
}
