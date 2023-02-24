using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkSchedule : MonoBehaviour
{
    //存储烟花的16长度的开关信息
    public List<bool> fireSwitch;

    //存储烟花对应的编号，创建出来的烟花会带编号和配置信息进gameManager
    public List<int> fireNumber;

    //16长度每个长度的间隔因子
    public float timeFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        fireSwitch = new List<bool>();
        fireNumber = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


