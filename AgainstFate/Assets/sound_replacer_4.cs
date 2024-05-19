using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_replacer_4 : MonoBehaviour
{
    public List<AudioSource> audioSources;
    private int worldAudioIndex = 0;
    private int boss1AudioIndex = 1;
    private int boss2AudioIndex = 2;

    private void Start()
    {
        PlayMusic_4();
    }

    
    public AdaptedPatterForCapricorn bliznec_start;
    public GameObject bliznec_end;
    public GameObject bliznec2_end;
    public Pattern vesi_start;
    public GameObject vesi_end;



    public void PlayMusic_4()
    {
        audioSources[boss1AudioIndex].Pause();
        audioSources[boss2AudioIndex].Pause();


        if (!bliznec_start.IsEnd)
        {
            Debug.Log(13);
            audioSources[boss1AudioIndex].Pause();
        }
        else
        {
            Debug.Log(25);
            audioSources[worldAudioIndex].Pause();
            audioSources[boss1AudioIndex].UnPause();

            if (bliznec_end == null && bliznec2_end == null)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss1AudioIndex].Pause();
            }
        }


        if (!vesi_start.IsEnd)
        {
            audioSources[boss2AudioIndex].Pause();
        }
        else
        {
            audioSources[worldAudioIndex].Pause();
            audioSources[boss2AudioIndex].UnPause();

            if (vesi_end == null)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss2AudioIndex].Pause();
            }
        }

    }

    void Update()
    {
        PlayMusic_4();
    }

}