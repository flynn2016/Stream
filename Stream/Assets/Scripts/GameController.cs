using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public LiquidSpawn liquidSpawn_1;
    public LiquidSpawn liquidSpawn_2;
    public Animator goodjob;
    public Beaker [] beakers;
    private bool all_finished;

    // Start is called before the first frame update
    void Start()
    {
        liquidSpawn_1.TurnOnLiquid();
        liquidSpawn_2.TurnOnLiquid();
    }

    // Update is called once per frame
    void Update()
    {
        //hardcode for meeting
        if (beakers[0].finished && beakers[1].finished)
        {
            all_finished = true;
            goodjob.SetBool("passed",true);
        }
    }

    public void LoadNextScene()
    {
        if (all_finished)
        SceneManager.LoadScene("Array");
    }
}
