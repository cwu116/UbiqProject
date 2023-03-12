using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkManager : MonoBehaviour
{
    public static FireWorkManager instance;

    //存储创建好的不同类型的烟花
    public Dictionary<int, FireWork> fireWorkDict;
    int curID;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireWorkDict = new Dictionary<int, FireWork>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewFireWork(Color color, FireWorkShape shape)
    {
        FireWork fireWork = new FireWork(curID, color, shape);
        fireWorkDict.Add(curID, fireWork);
        curID++;
    }

    public void PrintElement()
    {
        foreach (var item in fireWorkDict)
        {
            Debug.Log("Id is " + item.Key + " Color is " + item.Value.fireWorkColor + " Shape is " + item.Value.fireWorkShape);
        }
    }
}
