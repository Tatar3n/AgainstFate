using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public float fadeInduration = 4f;
    public float fadeOutduration = 2f;
    private Scene _Scene;
    private AudioSource _audio;
    private IEnumerator _fadeIn;
    private IEnumerator _fadeOut;
    private bool _isPlaying;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _Scene = SceneManager.GetActiveScene();
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0f;
        _fadeIn = Fade(_audio, fadeInduration, 1f);
        _fadeOut = Fade(_audio, fadeOutduration, 0f);
        StartCoroutine(_fadeIn);
    }

    private void Update()
    {
        if (!_isPlaying && SceneManager.GetActiveScene() != _Scene)
        {
            StopCoroutine(_fadeIn);
            StartCoroutine(_fadeOut);
            _isPlaying = true;
        }

        if (_audio.volume == 0)
            Destroy(gameObject);
    }

    public IEnumerator Fade(AudioSource source, float duration, float targetVolume)
    {
        float time = 0f;
        float startVolume = source.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        yield break;
    }
}
