using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFireWorkPanel : MonoBehaviour
{
    public GameObject content;
    public GameObject prefab;
    [HideInInspector]
    public List<int> IDList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckNew();
    }

    void CheckNew()
    {
        if (FireWorkManager.instance.fireWorkDict == null) return;
        foreach (var x in FireWorkManager.instance.fireWorkDict)
        {
            if (IDList.Contains(x.Key) == false)
            {
                IDList.Add(x.Key);
                GameObject instance = Instantiate(prefab,content.transform);
                TMP_Text mText = instance.transform.Find("ID").GetComponent<TMP_Text>();
                TMP_Text mText1 = instance.transform.Find("Shape").GetComponent<TMP_Text>();
                Image img = instance.GetComponent<Image>();
                mText.text = "ID" + x.Key;
                int id =(int)FireWorkManager.instance.fireWorkDict[x.Key].fireWorkShape;
                mText1.text = FireWorkManager.instance.shapeDict[id].ToString();
                img.color = x.Value.fireWorkColor;
            }
        }
    }
}
