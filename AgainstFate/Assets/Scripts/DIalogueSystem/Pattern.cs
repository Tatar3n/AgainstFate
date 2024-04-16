using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pattern : MonoBehaviour
{
    private bool a = true;
    public bool IsEnd=false;
    public bool IsStart=false;
    public string[] message;
    public int[] Arra;
    // FIRST HERO
    public Text FirstText;
    public GameObject FirstImage;
    public GameObject FirstPanelWord;
    public GameObject FirstNamePanel;
    public GameObject FirstSkipping;
    public GameObject FirstName;

    // Second HERO
    public Text SecondText;
    public GameObject SecondImage;
    public GameObject SecondPanelWord;
    public GameObject SecondNamePanel;
    public GameObject SecondSkipping;
    public GameObject SecondName;

    // Third HERO
    public Text ThirdText;
    public GameObject ThirdImage;
    public GameObject ThirdPanelWord;
    public GameObject ThirdNamePanel;
    public GameObject ThirdSkipping;
    public GameObject ThirdName;

    //Общее
    /*
    public bool[message.Length] FirstArray; // если 1 значит на текущей итерации реплика 1 персонажа, очевидно, что пересечений по единицам в трех массивах быть не должно!!
    public bool[message.Length] SecondArray;
    public bool[message.Length] ThirdArray;
    */
    [SerializeField] float TextSpeed;
    private int index = 0;
    private int flag = 0;
    // public int count;// показывает, какой герой был вызван последним
    //private int[] Array = Arra; //Заполнять только 1 2 или 3!!! по длине должно быть как массив стрингов
    //private bool[Array.Length] BA = { false } * Array.Length;
    private void FirstVisualise()
    {
        FirstImage.SetActive(true); 
        FirstPanelWord.SetActive(true);
        FirstNamePanel.SetActive(true);
        FirstSkipping.SetActive(true);
        FirstName.SetActive(true);

    }
    private void FirstClose()
    {
        FirstText.text = "";
        FirstImage.SetActive(false);
        FirstPanelWord.SetActive(false);
        FirstNamePanel.SetActive(false);
        FirstSkipping.SetActive(false);
        FirstName.SetActive(false);

    }

    private void SecondVisualise()
    {
        SecondImage.SetActive(true);
        SecondPanelWord.SetActive(true);
        SecondNamePanel.SetActive(true);
        SecondSkipping.SetActive(true);
        SecondName.SetActive(true);

    }
    private void SecondClose()
    {
        SecondText.text = "";
        SecondImage.SetActive(false);
        SecondPanelWord.SetActive(false);
        SecondNamePanel.SetActive(false);
        SecondSkipping.SetActive(false);
        SecondName.SetActive(false);

    }

    private void ThirdVisualise()
    {
        ThirdImage.SetActive(true);
        ThirdPanelWord.SetActive(true);
        ThirdNamePanel.SetActive(true);
        ThirdSkipping.SetActive(true);
        ThirdName.SetActive(true);

    }
    private void ThirdClose()
    {
        ThirdText.text = "";
        ThirdImage.SetActive(false);
        ThirdPanelWord.SetActive(false);
        ThirdNamePanel.SetActive(false);
        ThirdSkipping.SetActive(false);
        ThirdName.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && a)
        {
            a = false;
            IsStart= true;
            if (Arra[0]==1)
            {
                DoFirst(index);
                flag = 1;
            }
            else if (Arra[0] == 2)
            {
                DoSecond(index);
                flag = 2;

            }
            else if (Arra[0] == 3)
            {
                DoThird(index);
                flag = 3;

            }

        }
    }
    private void DoDialogue(int n)
    {
        if (n >= Arra.Length)
        {
            IsEnd = true;
            FirstClose();
            SecondClose();
            ThirdClose();
        }
        else if (Arra[n]==1)
        {
            SecondClose();
            ThirdClose();
            DoFirst(n);
            
        }
        else if (Arra[n]==2)
        {
            ThirdClose();
            FirstClose();
            DoSecond(n);
            
        }
        else if (Arra[n]==3) 
        {
            FirstClose();
            SecondClose();
            DoThird(n);
            
        }
    }
    IEnumerator FirstTL()
    {
        flag = Arra[index];
        int k = 0;
        FirstText.text = "";
        for (int i = 0; i < message[index].Length; i++)
        {
            //Debug.Log(k++);
            string sss = FirstText.text;
            FirstText.text = "";
            FirstText.text = sss + message[index][i];
            yield return new WaitForSeconds(TextSpeed);
        }

    }
    private void DoFirst(int n)
    {
        FirstVisualise();
        FirstText.text = message[index];
        index++;
        /*
        if (flag != Arra[index])
        {
            flag = Arra[index];
            StartCoroutine(FirstTL());
        }
        else
        {
            if (FirstText.text == message[index])
            {
                index++;
                DoDialogue(index);
            }
            else
            {
                //FirstText.text = "";
                StopAllCoroutines();
                FirstText.text = "";
                FirstText.text = message[index];
                index++;
            }
            flag = 0;
        */
        
        
    }


    IEnumerator ThirdTL()
    {
        int k = 0;
        flag = Arra[index];
        ThirdText.text = "";
        for (int i = 0; i < message[index].Length; i++)
        {
            //Debug.Log(k++);
            string sss = ThirdText.text;
            ThirdText.text = "";
            ThirdText.text = sss+message[index][i];
            yield return new WaitForSeconds(TextSpeed);
        }

    }
    private void DoThird(int n)
    {
        ThirdVisualise();
        ThirdText.text = message[index];
    index++;    
    /*
        if (flag != Arra[index])
        {
            flag = Arra[index];
            StartCoroutine(ThirdTL());
        }
        else
        {
            if (ThirdText.text == message[index])
            {
                index++;
                DoDialogue(index);
            }
            else
            {
                ThirdText.text = "";
                StopAllCoroutines();
                ThirdText.text = "";
                ThirdText.text = message[index];

                index++;
            }
            flag = 0;
        }*/

    }

    IEnumerator SecondTL()
    {
        int k = 0;
        flag = Arra[index];
        SecondText.text = "";
        for (int i = 0; i < message[index].Length; i++)
        {
            //Debug.Log(k++);
            string sss = SecondText.text;
            SecondText.text = "";
            SecondText.text = sss + message[index][i];
            yield return new WaitForSeconds(TextSpeed);
        }

    }
    private void DoSecond(int n)
    {
        SecondVisualise();
    SecondText.text = message[index];
    index++;
    /*
        if (flag != Arra[index])
        {
            flag = Arra[index];
            StartCoroutine(SecondTL());
        }
        else
        {
            if (SecondText.text == message[index])
            {
                index++;
                DoDialogue(index);
            }
            else
            {
                SecondText.text = "";
                StopAllCoroutines();
                SecondText.text = "";
                SecondText.text = message[index];

                index++;
            }
            flag = 0;
        }*/

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)  &&!a)
        {
            if (index < message.Length)
            {
                DoDialogue(index);
            }
            else
            {
                IsEnd= true;
                FirstClose();
                SecondClose();
                ThirdClose();
            }
        }
    }
}
