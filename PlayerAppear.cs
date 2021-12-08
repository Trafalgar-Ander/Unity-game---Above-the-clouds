using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppear : MonoBehaviour
{

    public GameObject bornPlayer;

    // Start is called before the first frame update
    void Start()
    {
        bornPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bornPlayer.SetActive(true);
            bornPlayer.transform.position = new Vector3(0.1f, 6.3f, 0);
        }
    }
}
