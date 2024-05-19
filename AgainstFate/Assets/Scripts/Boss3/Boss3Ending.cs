using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Ending : MonoBehaviour
{
	public Transform lastPlatform;
	public Transform player;
	public GameObject water;
    public PatternDialogueAfterDeath p;
    private bool d = true;
    public GameObject ds, ds2;
    private void Update()
    {
        if (p.IsEnd && d)
        {
            lastPlatform.gameObject.transform.position = new Vector3(player.position.x, lastPlatform.gameObject.transform.position.y, player.position.z);
            lastPlatform.gameObject.SetActive(true);
            water.SetActive(true);
            d = false;
            ds.SetActive(true);
            ds.SetActive(true);
        }
    }
   
}
