using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    public List<AudioSource> audioSources;
    private int worldAudioIndex = 0;
    private int boss1AudioIndex = 1;
    private int boss2AudioIndex = 2;

    private void Start()
    {
        PlayMusic();
    }

    public LeoStartAttack leo_trigger;
    public PatternDialogueAfterDeath leo_pattern;

    
    public Pattern aria_death_switch;
    public PatternDialogueAfterDeath aria_death_marker;
    


    public void PlayMusic()
    {
        audioSources[boss1AudioIndex].Pause();
        audioSources[boss2AudioIndex].Pause();

        if (!aria_death_switch.IsEnd)
        {
            audioSources[boss1AudioIndex].Pause();
        }
        else
        {
            audioSources[worldAudioIndex].Pause();
            audioSources[boss1AudioIndex].UnPause();

            if (aria_death_marker.IsEnd)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss1AudioIndex].Pause();
            }
        }

        if (!leo_trigger.p.IsEnd)
        {
            audioSources[boss2AudioIndex].Pause();
        }
        else
        {
            audioSources[worldAudioIndex].Pause();
            audioSources[boss2AudioIndex].UnPause();

            if (leo_pattern.IsEnd)
            {
                audioSources[worldAudioIndex].UnPause();
                audioSources[boss2AudioIndex].Pause();
            }
        }

    }

    private void Update()
    {
        PlayMusic();
    }

}