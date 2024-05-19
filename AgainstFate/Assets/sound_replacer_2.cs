using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_replacer_2 : MonoBehaviour
{
    public List<AudioSource> audioSources;
    private int worldAudioIndex = 0;
    private int boss2AudioIndex = 1;

    public Pattern _deva_start;
    public PatternDialogueAfterDeath _deva_end;

    private void Start()
    {
        PlayMusic_2();
    }

    public void PlayMusic_2()
    {
        audioSources[boss2AudioIndex].Pause();

        if (!_deva_start.IsEnd)
        {
            audioSources[boss2AudioIndex].Pause();
        }
        else
        {
            audioSources[worldAudioIndex].Pause();
            audioSources[boss2AudioIndex].UnPause();

            if (_deva_end.IsEnd)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss2AudioIndex].Pause();
            }
        }

    }

    private void Update()
    {
        PlayMusic_2();
    }
}
