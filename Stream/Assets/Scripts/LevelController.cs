using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform[] advancedlevels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.level_unlock == true)
        {
            foreach (Transform child in advancedlevels)
            {
                child.GetComponent<BoxCollider2D>().enabled = true;
                child.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
