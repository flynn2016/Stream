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
        if(this.name=="Start")
            SceneManager.LoadScene("Levels");
        else if(this.name == "Level1")
            SceneManager.LoadScene("If");
        else if (this.name == "Level2")
            SceneManager.LoadScene("For");
        else if (this.name == "Level3")
            SceneManager.LoadScene("Array");
        else if (this.name == "Level4")
            SceneManager.LoadScene("level_4");
        else if (this.name == "Level5")
            SceneManager.LoadScene("level_5");
        else if (this.name == "Level6")
            SceneManager.LoadScene("level_6");
    }
}
