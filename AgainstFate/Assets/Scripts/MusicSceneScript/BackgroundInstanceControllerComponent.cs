using UnityEngine;

namespace Assets
{
    public class BackgroundInstanceControllerComponent : MonoBehaviour
    {
        [Header("Tags")]
        [Tooltip("Unique Object Tag")]
        [SerializeField] private string createdTag;
        
        private void Awake()
        {
            GameObject obj = GameObject.FindWithTag(this.createdTag);
            if (obj != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.gameObject.tag = this.createdTag;
                //DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}
