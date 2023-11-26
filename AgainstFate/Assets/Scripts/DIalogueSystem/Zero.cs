using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Zero : MonoBehaviour
{
    public GameObject panelDialog;
    public Button myButton;
    public GameObject Snake;
    public GameObject skipping;
    public GameObject namepanel;
    public GameObject name;
    public string[] message;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] float TextSpeed;
    private int index;
    /*
    private void myButton_Click(object sender, EventArgs e)
    { }
    */
    void Start()
    {
        text.text = string.Empty;
        //myButton.onClick.AddListener(MouseClick);
        //myButton.Click += new EventHandler(myButton_Click);
        //Controls.Add(myButton);
        StartDialog();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (text.text == message[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = message[index];
            }
        }
    }
    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
        
        Snake.SetActive(true);
        panelDialog.SetActive(true);
        skipping.SetActive(true);
        namepanel.SetActive(true);
        name.SetActive(true);
       // button.SetActive(true);
        
    }
    IEnumerator TypeLine()
    {
        foreach (char c in message[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }
    void IsNextLine()
    {
        if (index < message.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            
            panelDialog.SetActive(false);
            Snake.SetActive(false);
            skipping.SetActive(false) ;
            namepanel.SetActive(false); 
            name.SetActive(false);
        }

    }
}

    /*
    // Start is called before the first frame update
    void Start()
    {
        panelDialog.SetActive(false);
        imageSnake.SetActive(false);
    }
    void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in message[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }
    void IsNextLine()
    {
        if (index<message.Length)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    //при соприкосновении с коллайдером запукает диалог. Единственная функция запускающая диалог!!!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            panelDialog.SetActive(true);
            dialog.text = message[0];
            dialogStart = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        panelDialog.SetActive(false);
        dialogStart = false;
    }

    private void Update()
    {
        if (dialogStart == true && Input.GetMouseButtonDown(0))
        {
            if (text.text == message[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = message[index];
            }
            
        }
    }
}
    */