using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseOver : MonoBehaviour
{
    public Transform shaded_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        this.GetComponent<Renderer>().enabled = false;
        shaded_text.GetComponent<Renderer>().enabled = true;
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().enabled = true;
        shaded_text.GetComponent<Renderer>().enabled = false;
    }

    void OnMouseDown()
    {
        Debug.Log("here");
        SceneManager.LoadScene("SampleScene");
    }
}
