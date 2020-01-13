using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    public int water_threshold;
    public bool finished { get; private set;}
    private int water_count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (water_count >= water_threshold)
        {
            Debug.Log("here");
            finished = true;
            this.GetComponent<Animator>().SetBool("finished", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        water_count++;
    }
}
