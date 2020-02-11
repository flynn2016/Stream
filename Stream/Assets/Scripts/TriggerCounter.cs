using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCounter : MonoBehaviour
{
    public int output_count;
    public bool Detect_red;
    public bool Detect_blue;
    public bool Detect_green;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Particle_red"&&Detect_red)
            output_count++;
        else if (col.tag == "Particle_blue" && Detect_blue)
            output_count++;
        else if (col.tag == "Particle_green" && Detect_green)
            output_count++;

        this.GetComponentInParent<Foroperation>().curr_water--;
    }
}
