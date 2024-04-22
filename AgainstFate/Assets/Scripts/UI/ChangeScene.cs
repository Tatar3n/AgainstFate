using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeLevel(int scene_number)
    {
        CameraShake.startshake = false;
        FallingGround.start = false;
        RockTrapActivate.EndRockTrap = false;
        SceneManager.LoadScene(scene_number);
    }


}
