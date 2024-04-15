using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShieldController : MonoBehaviour

{
    [SerializeField] Image uiFill;
    public Transform firePoint;
    public PlayerMovement player;
    public bool Waiting10sek = false;
    private bool istimer = false;
    public int Duration;
    private int remainingDuration;
    public GameObject ShieldImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && !player.isDialog)
        {
            if (!Waiting10sek)
            {
                //animator.Play("Fireball");
               // Shield();
                Waiting10sek = true;
                Being(Duration);
                StartCoroutine(DoProtect());
            }
            else
            {
                Debug.Log("Wait for");
            }
        }
    }
    private void Being(int Second)
    {
        remainingDuration = Second;
        if (!istimer)
        {
            StartCoroutine(UpdateTimer());
        }

        istimer = true;
    }
  
    IEnumerator DoProtect()
    {
        ShieldImage.SetActive(true);
        yield return new WaitForSeconds(3f);
        ShieldImage.SetActive(false);
        Waiting10sek = false;
    }
   
    IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {

            // uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);

        }
        istimer = false;
    }
}
