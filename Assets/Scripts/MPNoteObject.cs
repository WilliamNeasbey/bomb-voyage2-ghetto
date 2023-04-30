using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPNoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hiteffect, goodEffect, perfectEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManagerDance.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("hit");
                    MPGameManager.instance.NormalHit();
                    Instantiate(hiteffect, transform.position, hiteffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("good");
                    MPGameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);

                }
                else
                {
                    Debug.Log("perfect");
                    MPGameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    /* private void OnTriggerExit2D(Collider2D other)
     {
         if (other.tag == "Activator")
         {
             canBePressed = false;

             GameManagerDance.instance.NoteMissed();
             Instantiate(missEffect, transform.position, missEffect.transform.rotation);


         }
     }
    */

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

                Instantiate(missEffect, transform.position, missEffect.transform.rotation);

                MPGameManager.instance.NoteMissed();

            }
        }
    }
}
