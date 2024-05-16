using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RangedAttackController : MonoBehaviour
{
    [SerializeField] Image uiFill;
    public Transform firePoint;
    public GameObject bp;
    public PlayerMovement player;
    public bool Waiting10sek=false;
    private bool istimer = false;
    public int Duration;
    private int remainingDuration;
    public Animator animator;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && !player.isDialog)
        {
            if (!Waiting10sek)
            {
                //TODO Turning on the timer

                //animator.Play("Fireball");
                animator.Play("FireAttack");
                StartCoroutine(ReadyToAttack());
               
                Waiting10sek = true;
                Being(Duration);
                
                StartCoroutine(DoAttack());
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
    void Shoot()
    {
      
        Instantiate(bp,firePoint.position, firePoint.rotation);
    }
    IEnumerator ReadyToAttack()
    {
        yield return new WaitForSeconds(0.3f);
        Shoot();
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(10f);
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
        istimer= false;
    }
}
