using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
 
    public Transform firePoint;
    public GameObject bp;
    public bool Waiting10sek=false;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (!Waiting10sek)
            {
                Debug.Log("heuihe");
                //animator.Play("Fireball");
                Shoot();
                Waiting10sek = true;
                StartCoroutine(DoAttack());
            }
            else
            {
                Debug.Log("Wait for");
            }
        }
        
    }

    void Shoot()
    {
      
        Instantiate(bp,firePoint.position, firePoint.rotation);
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(10f);
        Waiting10sek = false;
    }
}
