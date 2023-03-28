using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkSchedulePannel : MonoBehaviour
{
    FireBox firebox;
    // Start is called before the first frame update
    void Start()
    {
        firebox = transform.parent.GetComponent<FireBox>();
    }

 
    public void NextPage()
    {
        firebox.NextPage();
    }

    public void PrePage()
    {
        firebox.PrePage();
    }

    public void CreatePage()
    {
        firebox.Add(16);
    }
}
