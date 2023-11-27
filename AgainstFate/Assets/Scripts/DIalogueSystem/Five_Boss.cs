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
    //[SerializeField] TextMeshProUGUI text1;
    public Text SnakeC;
    public Text Sagittarius;
    //[SerializeField] TextMeshProUGUI Sagittariustext;
    [SerializeField] float TextSpeed;
    public GameObject SnakeCname;
    public GameObject SagittariusName;
   
    
    //public GameObject playerMovement;

    private int index = 1;
    private bool flag = true;
    private string[] messages = { "Очень смело с твоей стороны вновь появиться здесь, друг.",//0
            "Ты правда настолько глуп, что решил, что я пропущу тебя наверх?", //1
        "Что? Да что я вам всем сделал? ", //2
        "Ты хоть представляешь, сколько всего я преодолел, чтобы вернуться?",//3
    "Ты думаешь, мне есть до этого дело? ",//4
        "Гороскоп предсказывал, что нам суждено было встретиться вновь.\n" ,
            " Надеюсь, ты вдоволь насладился жизнью среди людей. ",//5
        "А теперь, приготовься пасть от моей руки!"};//6

    // Start is called before the first frame update
    void Start()
    {

     
        index= 0;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && flag)
        {
           
          
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
            index++;
            if (index<messages.Length)
            {
                
                Continue_Dialogue();

            }
            else
            {
               
                Sagittarius.text = "";
                SnakeC.text = "";
                SagittariusImage.SetActive(false);
                SagittariusName.SetActive(false);
                SagittariusNamePanel.SetActive(false);
                SagittariusPanelWord.SetActive(false);
                SkippingSagittarius.SetActive(false) ;
                //anim.SetActive(true);
                //playerMovement.SetActive(true);
                
            }
        }
    }
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
    
};
