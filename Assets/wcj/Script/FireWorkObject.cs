using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkObject : MonoBehaviour
{
    public GameObject canvas;
    bool canchange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        canchange = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("hand") && canchange)
        {
            if (InputManager.instance.rightSecondButtonOn)
            {
                if (canvas.activeSelf == false)
                    canvas.SetActive(true);
                else
                    canvas.SetActive(false);
                canchange = false;
            }
                   
        }
    }
}
