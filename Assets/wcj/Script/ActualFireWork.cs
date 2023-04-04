using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualFireWork : MonoBehaviour
{

    float count;
    int CD;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        CD = 5;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= CD) Destroy(this.gameObject);
    }
}
