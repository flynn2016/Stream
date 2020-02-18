using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public int water_threshold;
    public bool finished { get; private set; }

    public bool target_red;
    public bool target_green;
    public bool target_blue;
    public bool check_color;
    public Color target_color;
    private int water_count_red;
    private int water_count_blue;
    private int water_count_green;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            if (target_red && (water_count_red > water_threshold) && water_count_green == 0 && water_count_blue == 0
                || target_green && (water_count_green > water_threshold) && water_count_red == 0 && water_count_blue == 0
                || target_blue && (water_count_blue > water_threshold) && water_count_red == 0 && water_count_green == 0)
            {
                AudioManager.Instance.Play_beakerfull(); 
                this.GetComponent<Animator>().SetBool("finished", true);
                finished = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Color temp = col.transform.GetComponent<Particle>().particle_color;

        if (col.tag == "Particle_red")
        {
            if (check_color&&target_red)
            {
                if (Mathf.Abs(temp.r - target_color.r)<0.01f && Mathf.Abs(temp.g - target_color.g) < 0.01f&& Mathf.Abs(temp.b - target_color.b) < 0.01f)
                {
                    water_count_red++;
                }
            }
            else
            {
                water_count_red++;
            }
        }
        else if (col.tag == "Particle_green")
        {
            if (check_color&&target_green)
            {
                if (Mathf.Abs(temp.r - target_color.r) < 0.01f && Mathf.Abs(temp.g - target_color.g) < 0.01f && Mathf.Abs(temp.b - target_color.b) < 0.01f)
                {
                    water_count_green++;
                }
            }
            else
            {
                water_count_green++;
            }
        }
        else if (col.tag == "Particle_blue")
        {
            if (check_color&&target_blue)
            {
                if (Mathf.Abs(temp.r - target_color.r) < 0.01f && Mathf.Abs(temp.g - target_color.g) < 0.01f && Mathf.Abs(temp.b - target_color.b) < 0.01f)
                {
                    water_count_blue++;
                }
            }
            else
            {
                water_count_blue++;
            }
        }
    }
}
