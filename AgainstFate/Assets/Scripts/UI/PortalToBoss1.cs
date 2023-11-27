using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToBoss1 : MonoBehaviour
{
    public int sceneIndex;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

           
            SceneManager.LoadScene(sceneIndex);

        }
    }

}
