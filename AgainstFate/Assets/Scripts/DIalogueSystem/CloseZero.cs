using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseZero : MonoBehaviour
{
    public GameObject panelDialog;
    public GameObject button;
    public GameObject Snake;
    public GameObject skipping;
    public GameObject namepanel;
    public GameObject name;
    public GameObject tmp;
    //[SerializeField] TextMeshProUGUI text;

    [SerializeField] float TextSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            panelDialog.SetActive(false);
            Snake.SetActive(false);
            skipping.SetActive(false);
            namepanel.SetActive(false);
            name.SetActive(false);
            tmp.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
