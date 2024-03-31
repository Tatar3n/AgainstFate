using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Five_Boss : MonoBehaviour    
{

    public GameObject SnakeCimage;
    public GameObject SagittariusImage;
    public GameObject SnakeCpanelWord;
    public GameObject SagittariusPanelWord;
    public GameObject SnakeCnamePanel;
    public GameObject SagittariusNamePanel;
    public GameObject SkippingSagittarius;
    public GameObject SkippingSnakeCarrier;
    public SpriteRenderer sagitarius;
    public GameObject expl;
    public GameObject expl2;
    //[SerializeField] TextMeshProUGUI text1;
    public Text SnakeC;
    public Text Sagittarius;
    //[SerializeField] TextMeshProUGUI Sagittariustext;
    [SerializeField] float TextSpeed;
    public GameObject SnakeCname;
    public GameObject SagittariusName;


    public bool IsEnd = false;
    public PlayerMovement player;
    //public GameObject playerMovement;
    private ParticleSystem ps;
    private ParticleSystem ps2;
    private int index = 1;
    private bool flag = true;
    private string[] messages = { "Очень смело с твоей стороны вновь появиться здесь, друг.",//0
            "Ты правда настолько глуп, что решил, что я пропущу тебя наверх?", //1
        "Что? Да что я вам всем сделал? ", //2
        "Ты хоть представляешь, сколько всего я преодолел, чтобы вернуться?",//3
    "Ты думаешь, мне есть до этого дело? ",//4
        "Гороскоп предсказывал, что нам суждено было встретиться вновь.\n" ,//5
            " Надеюсь, ты вдоволь насладился жизнью среди людей. ",//6
        "А теперь, приготовься пасть от моей руки!"};//7

    // Start is called before the first frame update
    void Start()
    {
        ps = expl.GetComponent<ParticleSystem>();
        ps2 = expl.GetComponent<ParticleSystem>();

        index = 0;
        //Sagittarius.text = messages[index];
    }
    
    IEnumerator TypeLineSnakeC()
    {
        SnakeC.text = "";
        int k = 0;
        
        for(int i= 0; i < messages[index].Length; i++)
        {
            //Debug.Log(k++);
            SnakeC.text += messages[index][i];
            yield return new WaitForSeconds(TextSpeed);
        }
        
    }
    IEnumerator TypeLineSagittarius()
    {
        //Debug.Log("olol" + index);
        Sagittarius.text = "";
        if (index == messages.Length)
        {
            Mathf.Min(1, 2);
        }
        foreach (char c in messages[Mathf.Min(index,7)].ToCharArray())
        {
            Sagittarius.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && flag)
        {

            player.isDialog = true;
            flag = false;
            SagittariusImage.SetActive(true);
            SagittariusName.SetActive(true);
            SagittariusNamePanel.SetActive(true);
            SagittariusPanelWord.SetActive(true);
            Sagittarius.text = messages[index]; 
            SkippingSagittarius.SetActive(true);
            
        }
    }
    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            //index++;

            if (index<messages.Length)
            {
                
                if ( index==2 || index==3)//слова змееносца
                {
                    //Debug.Log(index);
                    
                    if (SnakeC.text == messages[index])
                    {
                        //index++;
                        if (index == 3)
                        {
                            index++;
                            Continue_Sagittarius();
                        }
                        else
                        {
                            
                            Continue_SnakeC();
                            index++;
                        }
                       
                        
                        //StopAllCoroutines();

                    }
                    else
                    {
                        //StopCoroutine(TypeLineSnakeC()) ;
                        //Continue_SnakeC();
                        StopAllCoroutines();
                        SnakeC.text = messages[index];
                        
                    }
                    
                }
                else //слова стрельца
                {
                    
                    if (Sagittarius.text == messages[index])
                    {
                        index++;
                        //Debug.Log(messages[index]);
                        
                        
                        if (index == 2)
                        {
                            Continue_SnakeC();
                        }
                        else
                        {
                            Continue_Sagittarius();
                        }
                        
                        
                        //Debug.Log(messages[index]);
                        
                        //StopAllCoroutines();

                    }
                    else
                    {

                        //StopCoroutine(TypeLineSagittarius()) ;
                        //Debug.Log("Вызывем континью стрельца");
                        //Continue_Sagittarius();
                        StopAllCoroutines();
                        if (index == messages.Length)
                        {
                            sagitarius.enabled = false;
                            player.isDialog = false;
                            Sagittarius.text = "";
                            SnakeC.text = "";
                            SagittariusImage.SetActive(false);
                            SagittariusName.SetActive(false);
                            SagittariusNamePanel.SetActive(false);
                            SagittariusPanelWord.SetActive(false);
                            SkippingSagittarius.SetActive(false);
                            ps.Play();
                            ps2.Play();
                        }
                        else
                        { Sagittarius.text = messages[index]; }
                        
                    }

                }

            }
            
            else
            {
                sagitarius.enabled = false;
                player.isDialog = false;
                Sagittarius.text = "";
                SnakeC.text = "";
                SagittariusImage.SetActive(false);
                SagittariusName.SetActive(false);
                SagittariusNamePanel.SetActive(false);
                SagittariusPanelWord.SetActive(false);
                SkippingSagittarius.SetActive(false) ;
                ps.Play();
                ps2.Play();
                //anim.SetActive(true);
                //playerMovement.SetActive(true);

            }
        }
    }
    
private void Continue_SnakeC()
    {
        Sagittarius.text = "";
        SagittariusImage.SetActive(false);
        SagittariusName.SetActive(false);
        SagittariusNamePanel.SetActive(false);
        SagittariusPanelWord.SetActive(false);
        SkippingSagittarius.SetActive(false);
        //index++;
        //SnakeC.text = "";
            //SnakeC.text = messages[index];

            SnakeCimage.SetActive(true);
            SnakeCname.SetActive(true);
            SnakeCnamePanel.SetActive(true);
            SnakeCpanelWord.SetActive(true);
            SkippingSnakeCarrier.SetActive(true);
            StartCoroutine(TypeLineSnakeC());


    }
    private void Continue_Sagittarius()
    {
        
            //Sagittarius.text = string.Empty;
            
            SnakeC.text = "";
            SnakeCimage.SetActive(false);
            SnakeCname.SetActive(false);
            SnakeCnamePanel.SetActive(false);
            SnakeCpanelWord.SetActive(false);
            SkippingSnakeCarrier.SetActive(false);
           // Sagittarius.text = messages[index];
            SagittariusImage.SetActive(true);
            SagittariusName.SetActive(true);
            SagittariusNamePanel.SetActive(true);
            SagittariusPanelWord.SetActive(true);
            SkippingSagittarius.SetActive(true);
        if (index < messages.Length)
        {
            StartCoroutine(TypeLineSagittarius());
        }
        else
        {
            sagitarius.enabled = false;
            player.isDialog = false;
            Sagittarius.text = "";
            SnakeC.text = "";
            SagittariusImage.SetActive(false);
            SagittariusName.SetActive(false);
            SagittariusNamePanel.SetActive(false);
            SagittariusPanelWord.SetActive(false);
            SkippingSagittarius.SetActive(false);
            ps.Play();
            ps2.Play();
        }
            
        
       
    }
    /*
    private void Continue_Dialogue()
    {
        if (index==2 || index==3)
        {

            Sagittarius.text = "";
            SagittariusImage.SetActive(false);
            SagittariusName.SetActive(false);
            SagittariusNamePanel.SetActive(false);
            SagittariusPanelWord.SetActive(false);
            SkippingSagittarius.SetActive(false) ;
            SnakeC.text = messages[index];
            SnakeCimage.SetActive(true);
            SnakeCname.SetActive(true);
            SnakeCnamePanel.SetActive(true);
            SnakeCpanelWord.SetActive(true);
            SkippingSnakeCarrier.SetActive(true);
        }
        else
        {
            SnakeC.text = "";
            SnakeCimage.SetActive(false);
            SnakeCname.SetActive(false);
            SnakeCnamePanel.SetActive(false);
            SnakeCpanelWord.SetActive(false);
            SkippingSnakeCarrier.SetActive(false);
            Sagittarius.text = messages[index];
            SagittariusImage.SetActive(true);
            SagittariusName.SetActive(true);
            SagittariusNamePanel.SetActive(true);
            SagittariusPanelWord.SetActive(true);
            SkippingSagittarius.SetActive(true);
        }
    }
    */
};
    
