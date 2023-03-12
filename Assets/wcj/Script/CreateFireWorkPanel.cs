using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateFireWorkPanel : MonoBehaviour
{
    
    public Dropdown dropDownBar;
    public Image colorImg;
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Button finishBtn;

    Color curColor = new Color(1,1,1,1);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        curColor.r = slider1.value;
        curColor.g = slider3.value;
        curColor.b = slider2.value;
        colorImg.color = curColor; 
    }

    public void OnClickFinishButton()
    {
        int data = dropDownBar.value;
        FireWorkShape shape = (FireWorkShape)data;
        FireWorkManager.instance.CreateNewFireWork(colorImg.color,shape);
        //this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
