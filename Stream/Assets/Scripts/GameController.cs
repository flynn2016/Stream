using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public SpriteRenderer instruction;
    public GameObject particle_r;
    public GameObject particle_g;
    public GameObject particle_b;
    public LiquidSpawn [] liquidSpawns;
    public Animator goodjob;
    public Container[] containers;
    public bool all_finished;
    public Color color_r;
    public Color color_g;
    public Color color_b;

    private static int test;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(test);
        test++;
        if (liquidSpawns.Length!=0)
        {
            liquidSpawns[0].TurnOnLiquid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        all_finished = true;

        for (int i=0;i<containers.Length;i++)
        {
            all_finished &= containers[i].finished;
        }

        //hardcode for meeting
        if (all_finished)
        {
            for (int i = 0; i < liquidSpawns.Length; i++)
            {
                liquidSpawns[i].TurnOffLiquid();
            }
            goodjob.SetBool("passed",true);
        }
    }

    public void LoadNextScene()
    {
        if (all_finished)
        SceneManager.LoadScene("Levels");
    }
}
