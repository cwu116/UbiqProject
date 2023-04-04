using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFireWorkID : MonoBehaviour
{
    int curId;
    int curNum;
    TextMeshProUGUI text;
    private List<int> fireNumber; 
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        fireNumber = this.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<FireWorkSchedule>().fireNumber;
        curId = 0;
        curNum = 0;
        text.text = "Num " + curNum + "ID " + curId;
    }

    //private void UpdateNumber()
    //{
    //    fireNumber = this.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<FireWorkSchedule>().fireNumber;
    //}
    public void NumSwitchUp()
    {
        if (curNum  < 15)
        {
            curNum++;
            text.text = "Num " + curNum + "ID " + fireNumber[curNum];
            curId = fireNumber[curNum];
        }
        else
        {
            curNum = 0;
            text.text = "Num " + curNum + "ID " + fireNumber[curNum];
            curId = fireNumber[curNum];
        }
    }
    public void NumSwitchDown()
    {
        if (curNum > 0)
        {
            curNum--;
            text.text = "Num " + curNum + "ID " + fireNumber[curNum];
            curId = fireNumber[curNum];
        }
        else
        {
            curNum = 15;
            text.text = "Num " + curNum + "ID " + fireNumber[curNum];
            curId = fireNumber[curNum];
        }
    }

    public void IDSwitchUp()
    {
        if(curId < FireWorkManager.instance.fireWorkDict.Count-1)
        {
            curId++;
            text.text = "Num " + curNum + "ID " + curId; 
        }
        else
        {
            curId = 0;
            text.text = "Num " + curNum + "ID " + curId;
        }
    }
    public void IDSwitchDown()
    {
        if (curId > 0)
        {
            curId--;
            text.text = "Num " + curNum + "ID " + curId;
        }
        else
        {
            curId = FireWorkManager.instance.fireWorkDict.Count - 1;
            text.text = "Num " + curNum + "ID " + curId;
        }
    }
    public void ApplyID()
    {
        fireNumber[curNum] = curId;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.KeypadEnter)) {ApplyID();}  
    //}
}
