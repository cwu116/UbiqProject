using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowButtonID : MonoBehaviour
{
    TextMeshProUGUI text;
    public int myid;
    private List<int> fireNumber;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + 0;
        fireNumber = this.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<FireWorkSchedule>().fireNumber;
    }

    // Update is called once per frame
    public void ShowId()
    {
        text.text = "" + fireNumber[myid];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) { ShowId(); }
    }
}
