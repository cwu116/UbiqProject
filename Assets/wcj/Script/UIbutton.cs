using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbutton : MonoBehaviour
{
    Button btn;
    Image img;
    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        img = this.gameObject.GetComponent<Image>();
    }

    public void ChangeColor()
    {
        if(selected == false)
        {
            selected = true;
            img.color = Color.red;
        }
        else
        {
            selected = false;
            img.color = Color.white;
        }
    }
}
