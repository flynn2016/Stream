using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject explain_text;
    public Container[] containers;
    public bool all_finished;
    public Color color_r;
    public Color color_g;
    public Color color_b;

    public static bool level_unlock;
    private static bool level_1_passed;
    private static bool level_2_passed;
    private static bool level_3_passed;

    private bool playonce;
    private bool win_once;

    // Start is called before the first frame update
    void Start()
    {
        if (liquidSpawns.Length!=0)
        {
            liquidSpawns[0].TurnOnLiquid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckWater();
        all_finished = true;
        
        for (int i=0;i<containers.Length;i++)
        {
            all_finished &= containers[i].finished;
        }

        //hardcode for meeting
        if (all_finished)
        {
            if (!win_once) {
                win_once = true;
                AudioManager.Instance.Play_winning();
            }

            for (int i = 0; i < liquidSpawns.Length; i++)
            {
                liquidSpawns[i].TurnOffLiquid();
            }

            goodjob.SetBool("passed",true);
            goodjob.GetComponent<Button>().enabled = true;

            if (SceneManager.GetActiveScene().name == "If")
            {
                level_1_passed = true;
            }
            else if (SceneManager.GetActiveScene().name == "For")
            {
                level_2_passed = true;
            }
            else if (SceneManager.GetActiveScene().name == "Array")
            {
                level_3_passed = true;
            }

            if (level_1_passed && level_2_passed && level_3_passed)
            {
                level_unlock = true;
            }
        }
    }

    private void CheckWater()
    {
        bool temp = false;
        foreach (LiquidSpawn spwaner in liquidSpawns)
        {
            temp |= spwaner.Liquidon;
        }

        if (temp&&!AudioManager.Instance.Water.isPlaying&&!playonce)
        {
            AudioManager.Instance.Play_water();
            playonce = true;
        }

        if (!temp && AudioManager.Instance.Water.isPlaying)
        {
            AudioManager.Instance.Stop_water();
            playonce = false;
        }
    }

    public void LoadNextScene()
    {
        if (all_finished)
        SceneManager.LoadScene("Levels");
    }

    public void press_gj()
    {
        AudioManager.Instance.Play_waterdrop();
        goodjob.GetComponent<Image>().enabled = false;
        explain_text.SetActive(true);
    }
}
