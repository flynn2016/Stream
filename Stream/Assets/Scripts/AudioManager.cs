using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;
    public AudioSource Water;

    public AudioClip Beaker_full;
    public AudioClip Water_sound;
    public AudioClip Button_on;
    public AudioClip Button_off;
    public AudioClip Clink;
    public AudioClip For_full;
    public AudioClip Water_drop;
    public AudioClip turning_table;
    public AudioClip win_sound;

    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        BGM.Play();
    }
    public void Play_beakerfull()
    {
        SFX.PlayOneShot(Beaker_full);
    }

    public void Play_water()
    {
        if(!Water.isPlaying)
        Water.Play();
    }

    public void Stop_water()
    {
        if (Water.isPlaying)
        Water.Stop();
    }

    public void Play_buttonon()
    {
        SFX.PlayOneShot(Button_on);
    }

    public void Play_buttonoff()
    {
        SFX.PlayOneShot(Button_off);
    }

    public void Play_clink()
    {
        SFX.PlayOneShot(Clink);
    }

    public void Play_for_full()
    {
        SFX.PlayOneShot(For_full);
    }
    public void Play_turning()
    {
        SFX.PlayOneShot(turning_table);
    }

    public void Play_winning()
    {
        SFX.PlayOneShot(win_sound);
    }
    public void Play_waterdrop()
    {
        SFX.PlayOneShot(Water_drop);
    }
}
