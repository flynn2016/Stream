using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    //public float lifetime;
    //float timer;
    public float max_yspeed;


	Rigidbody2D ridgebody;

	void Start () {
        ridgebody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
        Speedlimit();
        if (this.transform.position.y<-15f) // destroy self when pos.y lower than -15
        {
            Destroy(this.gameObject);
        }
	}

    void Speedlimit()
    {
        if (ridgebody.velocity.y < -max_yspeed)
        {
            ridgebody.velocity = new Vector2(ridgebody.velocity.x, -max_yspeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Operation"))
        {
            Destroy(this.gameObject);
        }
    }
}
