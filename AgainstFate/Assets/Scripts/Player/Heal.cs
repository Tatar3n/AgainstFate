using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Heal : MonoBehaviour

{
    [SerializeField] Image uiFill;

    public GameObject colorful_pic;
    public GameObject gray_pic;
    public PlayerMovement player;
    public GameObject GrayCircle;
    public GameObject GreenCircle;
    public bool Waiting10sek = false;
    private bool istimer = false;
    private bool IsUsed = false;
    public int Duration;
    [SerializeField] public HP hP;
    [SerializeField] public PlayerHP php;
    public float HealingTouch = 20f;
    private int remainingDuration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && !player.isDialog && !IsUsed)
        {
            if (!Waiting10sek)
            {
               
                Waiting10sek = true;
                //Being(Duration);
                IsUsed= true;
                StartCoroutine(DoHeal());
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

    IEnumerator DoHeal()
    {
        //TODO анимацию отхила (что-нибудь с водой)
        hP.nowHP = hP.maxHP;
        php.SetHealth(hP.nowHP);
        yield return new WaitForSeconds(1f);
        MakeWaveBlackWhite();
        
    }
    private  void MakeWaveBlackWhite()
    {
        colorful_pic.SetActive(false);
        gray_pic.SetActive(true);
        GreenCircle.SetActive(false);
        GrayCircle.SetActive(true);
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
        Waiting10sek = false;
    }
}
