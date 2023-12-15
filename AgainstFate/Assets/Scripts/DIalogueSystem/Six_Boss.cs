using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Six_Boss : MonoBehaviour

{
    public GameObject ImageOfSnake;
    public GameObject SnakeName;


    public GameObject SagittariusImage;
    public GameObject SagittariusPanelWord;
    public GameObject SagittariusNamePanel;
    public GameObject SkippingSagittarius;
    public Text Sagittarius;
    public GameObject SagittariusName;



    public GameObject SnakeCimage;
    public GameObject SnakeCpanelWord;
    public GameObject SnakeCnamePanel;
    public GameObject SkippingSnakeCarrier;
    public Text SnakeC;
    public GameObject SnakeCname;


    [SerializeField] float TextSpeed;
    
        

    public PlayerMovement player;
    public CaveThrowBullet a;
    private bool flag = true;
    private int index;
    //private int[] ints = { 2, 4, 6, 7 };
    private string[] messages = 
        {
        "Это так…", //sagittarius 0
        "нелепо…", //sagittarius 1
        "Мощно ты его!", //snake 2
        "Нет, нет, нет! Я не хотел этого!", //snakecarrier 3
        "Нет, ну ты видел, как он пафосно речь толкал? ",//snake 4
        "Я ведь просто защищался, да? Он сам на меня напал…",//snakecarrier 5
        "Конечно, он сам виноват!", //snake 6
        "Ну а мы держим путь дальше. Надеюсь, земные друзья будут больше рады встрече с нами. Пойдем, проведаем рогатенького!"//snake 7

    };
   
    //private int=
    void Start()
    {
        index = 0;
    }
    private void DoDialogue()
    {
        SagittariusImage.SetActive(true);
        SagittariusName.SetActive(true);
        SagittariusNamePanel.SetActive(true);
        SagittariusPanelWord.SetActive(true);
        Sagittarius.text = messages[index];
        SkippingSagittarius.SetActive(true);
        Continue_Dialogue();
    }
    private void Continue_Dialogue()
    {
        if (index ==1) //sagittarius
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
        if (index==2 || index==4 || index==6 || index==7) //snake
        {
            SnakeC.text = "";
            SnakeCimage.SetActive(false);
            SnakeCname.SetActive(false);
            SnakeCnamePanel.SetActive(false);
            SnakeCpanelWord.SetActive(false);
            SkippingSnakeCarrier.SetActive(false);

            SagittariusImage.SetActive(false);
            SagittariusName.SetActive(false);

            ImageOfSnake.SetActive(true);
            SagittariusNamePanel.SetActive(true);
            SagittariusPanelWord.SetActive(true);
            SkippingSagittarius.SetActive(true);
            SnakeName.SetActive(true);
            Sagittarius.text = messages[index];
        }
        if (index==3 || index==5) //snakecarrier
        {
            Sagittarius.text = "";
            SagittariusImage.SetActive(false);
            SagittariusName.SetActive(false);
            SagittariusNamePanel.SetActive(false);
            SagittariusPanelWord.SetActive(false);
            SkippingSagittarius.SetActive(false);

            ImageOfSnake.SetActive(false);
            SnakeName.SetActive(false);


            SnakeC.text = messages[index];
            SnakeCimage.SetActive(true);
            SnakeCname.SetActive(true);
            SnakeCnamePanel.SetActive(true);
            SnakeCpanelWord.SetActive(true);
            SkippingSnakeCarrier.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (a.isDead && flag)
        {
            flag=  false;
            DoDialogue();
        }
        if (Input.GetKeyDown(KeyCode.N) && !flag)
        {
            index++;
            Debug.Log(index);
            if (index < messages.Length)
            {

                Continue_Dialogue();

            }
            else
            {
                Debug.Log(index);

                player.isDialog = false;
                Sagittarius.text = "";
                SnakeC.text = "";
                SagittariusImage.SetActive(false);
                SagittariusName.SetActive(false);
                SagittariusNamePanel.SetActive(false);
                SagittariusPanelWord.SetActive(false);
                SkippingSagittarius.SetActive(false);
                ImageOfSnake.SetActive(false);
                SnakeName.SetActive(false);
                Sagittarius.text = "";
                SagittariusImage.SetActive(false);
                SagittariusName.SetActive(false);
                SagittariusNamePanel.SetActive(false);
                SagittariusPanelWord.SetActive(false);
                SkippingSagittarius.SetActive(false);

                ImageOfSnake.SetActive(false);
                SnakeName.SetActive(false);
                //anim.SetActive(true);
                //playerMovement.SetActive(true);

            }
        }
    }
}
