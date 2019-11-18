using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidParticle : MonoBehaviour
{
    public float collider_ontime;
    float timer;
    float timer_destory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > collider_ontime)
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (this.transform.localPosition.y < -20f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Container")
        {
            timer_destory += Time.deltaTime;
            if(timer>1f)
            Destroy(this.gameObject);
        }
    }
}
