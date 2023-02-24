using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkSchedule : MonoBehaviour
{
    //
    public int fireTimes;
    //存储烟花的固定长度的开关信息
    public List<bool> fireSwitch;

    //存储烟花对应的编号，创建出来的烟花会带编号和配置信息进gameManager
    public List<int> fireNumber;

    //16长度每个长度的间隔因子
    public float timeFactor;
    //此schedule的总时间长
    private float totalTime;
    public float timer = 0.0f;
    public int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        totalTime = timeFactor * fireTimes;
        fireSwitch = new List<bool>(fireTimes);
        fireNumber = new List<int>();

    }

    // Update is called once per frame
    void Update()
    {
        //Once triggered
        if (counter < fireTimes) {
            timer += Time.deltaTime;
            if (timer >= counter * timeFactor)
            {
                print("Fire");
            }
            counter += 1;
        }
    }
}


