using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewFireWorkManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public static NewFireWorkManager instance;
    public List<GameObject> fireWorkDict;
    void Start()
    {
        //fireWorkDict = new List<GameObject>();
        GameObject gb = (GameObject)Resources.Load("Prefabs/flyball");
        fireWorkDict.Add(gb);
        MakeNewFW(Vector3.forward, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeNewFW(Vector3 color, int Shape, int index)
    {
        GameObject gb = (GameObject)Resources.Load("Prefabs/flyball");
        gb.GetComponent<Renderer>().sharedMaterial.color = Color.white;

        fireWorkDict.Add(gb);
    }
}
