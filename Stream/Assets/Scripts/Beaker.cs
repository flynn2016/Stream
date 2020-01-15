using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    public int water_threshold;
    public bool finished { get; private set;}
    private int water_count_1;
    private int water_count_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((water_count_1 >= water_threshold&&this.name=="Beaker_1")||
            (water_count_2 >= water_threshold&&this.name =="Beaker_2"))
        {
            Debug.Log("here");
            finished = true;
            this.GetComponent<Animator>().SetBool("finished", true);
        }
        Debug.Log(this.name+" "+water_count_1+" "+water_count_2);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.name == "Water_1(Clone)")
        {
            water_count_1++;
        }

        else if (col.transform.name == "Water_2(Clone)")
        {
            water_count_2++;
        }
    }
}
