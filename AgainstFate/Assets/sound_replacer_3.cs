using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_replacer_3 : MonoBehaviour
{
    public List<AudioSource> audioSources;
    private int worldAudioIndex = 0;
    private int boss1AudioIndex = 1;
    private int boss2AudioIndex = 2;

    private void Start()
    {
        PlayMusic_3();
    }

    public GameObject cancer_end;
    public Pattern cancer_start;
    public Pattern riba_start;
    public GameObject riba_end;



    public void PlayMusic_3()
    {
        audioSources[boss1AudioIndex].Pause();
        audioSources[boss2AudioIndex].Pause();

        if (!cancer_start.IsEnd)
        {
            Debug.Log(13);
            audioSources[boss1AudioIndex].Pause();
        }
        else
        {
            Debug.Log(25);
            audioSources[worldAudioIndex].Pause();
            audioSources[boss1AudioIndex].UnPause();

            if (cancer_end == null)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss1AudioIndex].Pause();
            }
        }

        if (!riba_start.IsEnd)
        {
            audioSources[boss2AudioIndex].Pause();
        }
        else
        {
            audioSources[worldAudioIndex].Pause();
            audioSources[boss2AudioIndex].UnPause();

            if (riba_end == null)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss2AudioIndex].Pause();
            }
        }

    }

     void Update()
    {
        PlayMusic_3();
    }

}