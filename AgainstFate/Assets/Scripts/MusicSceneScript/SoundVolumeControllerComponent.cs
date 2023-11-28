using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class SoundVolumeControllerComponent : MonoBehaviour
    {
        [Header("Components")]
        [Tooltip("Audio Source Does Тot Connect Automatically")]
        [SerializeField] private AudioSource audio;
        [Tooltip("Slider Search Using A Tag")]
        [SerializeField] private Slider slider;
        [Tooltip("Text Search Using A Tag")]
        [SerializeField] private Text text;
    
        [Header("Keys")]
        [Tooltip("Save Data PlayerPrefs Key")]
        [SerializeField] private string saveVolumeKey;
    
        [Header("Tags")]
        [Tooltip("Volume Control Slider Tag")]
        [SerializeField] private string sliderTag;
        [Tooltip("Volume Control Text Tag")]
        [SerializeField] private string textVolumeTag;
    
        [Header("Parameters")]
        [Tooltip("Sound Volume Value")]
        [SerializeField] [Range(0.0f, 1.0f)] private float volume;
    
        private void Awake()
        {    
            // Checks whether a save is available in the registry.
            if (PlayerPrefs.HasKey(this.saveVolumeKey))
            {
                this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
                this.audio.volume = this.volume;
                
                // Search for and connect the slider.
                GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
                if (sliderObj != null)
                {
                    this.slider = sliderObj.GetComponent<Slider>();
                    this.slider.value = this.volume;
                }
            }
            else
            {
                // Setting the default volume.
                this.volume = 0.5f;
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
                this.audio.volume = this.volume;
            }
        }
    
        private void LateUpdate()
        {
            // Search for and connect the slider.
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.volume = slider.value;
                
                // Check the volume, is stored in the registry if different.
                if (this.audio.volume != this.volume)
                {
                    PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
                }
                
                // Search and connect text for volume output.
                GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
                if (textObj != null)
                {
                    this.text = textObj.GetComponent<Text>();

                    this.text.text = Mathf.Round(this.volume * 100) + "%"; // Converts the volume value to a percentage. (from 0% to 100%)
                }
            }

            this.audio.volume = this.volume;
        }
    }
}
