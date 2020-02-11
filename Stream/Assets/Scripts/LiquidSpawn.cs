using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawn : MonoBehaviour
{
    public GameObject liquidParticle;
    public Material alphacut;
    public bool On;
    public Color water_color;
    [Range(0,100)]
    public float flowRate; //how often instantiate water particle

    [Range(0, 1f)]
    public float randomRange; //random spawn position at y direction

    public bool Liquidon { get; private set; }
    public Transform parent;
    private float timer;

    void Awake()
    {
        if (alphacut != null)
        {
            alphacut.shader = Shader.Find("Water2D/Metaballs_Simple");
        }
    }
    void Start()
    {
        if (On)
        {
            TurnOnLiquid();
            SetWaterColor(water_color,"_Color_r");
        }
        else
        {
            TurnOffLiquid();
        }
    }
    void Update()
    {
        if (Liquidon)
        {
            timer += Time.deltaTime;
            if (timer > 1/flowRate)
            {
                Vector3 random_spawn = new Vector3(this.transform.position.x + Random.Range(-randomRange, randomRange), this.transform.position.y, this.transform.position.z);
                GameObject temp = Instantiate(liquidParticle, random_spawn, Quaternion.identity, parent.transform);
                //born with color and tags
                if (liquidParticle.name == "Particle_r")
                {
                    GameController.Instance.color_r = water_color;
                    temp.GetComponent<Particle>().particle_color = GameController.Instance.color_r;
                    temp.tag = "Particle_red";
                    SetWaterColor(water_color, "_Color_r");
                }
                else if (liquidParticle.name == "Particle_b")
                {
                    temp.GetComponent<Particle>().particle_color = GameController.Instance.color_b;
                    temp.tag = "Particle_blue";
                }
                else if (liquidParticle.name == "Particle_g")
                {
                    temp.GetComponent<Particle>().particle_color = GameController.Instance.color_g;
                    temp.tag = "Particle_green";
                }
                timer = 0;
            }
        }
    }

    public void SetWaterColor(Color color, string color_name)
    {
        if(alphacut!=null)
        alphacut.SetColor(color_name, color);
    }

    public void TurnOnLiquid()
    {
        Liquidon = true;
    }

    public void TurnOffLiquid()
    {
        Liquidon = false;
    }
}
