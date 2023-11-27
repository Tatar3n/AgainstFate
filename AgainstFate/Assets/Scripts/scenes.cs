using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scenes : MonoBehaviour
{
  
    public void change_to_testwalk(int n)
        {
      
        //SceneManager.LoadScene("TestWalk");
        SceneManager.LoadScene(n);
        
    }


}
