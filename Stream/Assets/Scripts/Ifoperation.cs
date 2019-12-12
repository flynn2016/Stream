using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ifoperation : MonoBehaviour
{
    public LiquidSpawn liquidoutput1;
    public LiquidSpawn liquidoutput2;

    // Start is called before the first frame update
    void Start()
    {
        liquidoutput1.liquidon = false;
        liquidoutput2.liquidon = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 temp = Camera.main.ScreenToWorldPoint(MousePosition);
        this.transform.position = new Vector3(temp.x,temp.y,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("StreamCollider"))
        {
            Debug.Log("here");
            liquidoutput1.liquidon = true;
            liquidoutput2.liquidon = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("StreamCollider"))
        {
            liquidoutput1.liquidon = false;
            liquidoutput2.liquidon = false;
        }
    }
}
