using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlotOne: MonoBehaviour
{
    public GameObject plot_one; 
    void Update()
    {     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            plot_one.SetActive(true);
        }
            
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            plot_one.SetActive(false);
        }
    }
}
