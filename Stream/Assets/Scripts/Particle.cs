using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
	public float lifetime;
    public float maxySpeed;
    float timer;

	Rigidbody2D ridgebody;

	void Start () {
        ridgebody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
        Speedlimit();

        timer += Time.deltaTime;
        if (timer > lifetime||this.transform.position.y<-15f)
        {
            Destroy(this.gameObject);
        }
	}

    void Speedlimit()
    {
        if (ridgebody.velocity.y < -maxySpeed)
        {
            ridgebody.velocity = new Vector2(ridgebody.velocity.x, -maxySpeed);
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
