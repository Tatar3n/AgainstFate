using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pattern_for_One : MonoBehaviour
{
 
    public Text FirstText;
    public GameObject FirstImage;
    public GameObject FirstPanelWord;
    public GameObject FirstNamePanel;
    public GameObject FirstSkipping;
    public GameObject FirstName;
    private bool DialStart = false;
    private bool flag = true;
    public string message;
    private void CloseVisual()
    {

        FirstImage.SetActive(false);
        FirstPanelWord.SetActive(false);
        FirstNamePanel.SetActive(false);
        FirstSkipping.SetActive(false);
        FirstName.SetActive(false);
        FirstText.text = "";
    }
    private void OpenVisual()
    {
        FirstText.text = message;
        FirstImage.SetActive(true);
        FirstPanelWord.SetActive(true);
        FirstNamePanel.SetActive(true);
        FirstSkipping.SetActive(true);
        FirstName.SetActive(true);
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        CloseVisual();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && flag)
        {
            OpenVisual();
            DialStart = true;

        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        CloseVisual();
        flag = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {

            if (DialStart)
            {
                CloseVisual();
            }
        }
    }
}


