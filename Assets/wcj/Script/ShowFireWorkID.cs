using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFireWorkID : MonoBehaviour
{
    int curId;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
       
        curId = 1;        
    }


    public void IDSwitch()
    {
        if(curId+1 <= FireWorkManager.instance.fireWorkDict.Count)
        {
            curId++;
            text.text = "FireWorkID: " + curId; 
        }
        else
        {
            curId = 1;
            text.text = "FireWorkID: " + curId;
        }
    }
}
