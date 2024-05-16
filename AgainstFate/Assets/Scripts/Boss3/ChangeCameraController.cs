using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraController : MonoBehaviour
{
    public Camera LevelOverviewCamera;
    public Camera mainCamera;

	public void Start()
	{
        LevelOverviewCamera.rect = new Rect(0, 0, 1, 1);
    }

	public void Update()
	{
        if (Input.GetKeyDown(KeyCode.H))
        {
            SwitchToOverviewCamera();
        }
        float targetAspect = 16f / 9f;
        float currentAspect = (float)Screen.width / Screen.height;

        if (currentAspect > targetAspect)
        {
            float scale = targetAspect / currentAspect;
            LevelOverviewCamera.rect = new Rect((1 - scale) / 2, 0, scale, 1);
        }
        else
        {
            float scale = currentAspect / targetAspect;
            LevelOverviewCamera.rect = new Rect(0, (1 - scale) / 2, 1, scale);
        }
    }

    public void SwitchToOverviewCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        LevelOverviewCamera.enabled = !LevelOverviewCamera.enabled;
    }
}
