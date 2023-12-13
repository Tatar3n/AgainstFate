using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Four : MonoBehaviour
{
    public GameObject panel;
    public GameObject image;
    public GameObject NamePanel;
    public GameObject Name;
    public Text dialog;
    public string message = " Ёти платформы выгл€д€т очень гор€чими! \nЅудь осторожен!";
    public bool DialStart = false;
    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {


    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && flag)
        {
            panel.SetActive(true);
            //dialog.SetActive(true);
            image.SetActive(true);
            Name.SetActive(true);
            NamePanel.SetActive(true);
            dialog.text = message;
            DialStart = true;
            flag = false;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        panel.SetActive(false);
        //dialog.SetActive(false);
        image.SetActive(false);
        Name.SetActive(false);
        NamePanel.SetActive(false);
        dialog.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (DialStart)
            {
                panel.SetActive(false);
                //dialog.SetActive(false);
                image.SetActive(false);
                Name.SetActive(false);
                NamePanel.SetActive(false);
                dialog.text = "";
            }
        }
    }
}
