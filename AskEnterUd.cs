using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskEnterUd : MonoBehaviour
{
    public GameObject udDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            udDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            udDialog.SetActive(false);
        }
    }
}
