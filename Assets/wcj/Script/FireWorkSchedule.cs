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
    public int[] fireNumber;

    //16长度每个长度的间隔因子
    public float timeFactor;
    //此schedule的总时间长
    private float totalTime;
    public float timer = 0.0f;
    public int counter = 0;
    public bool trigger ;
    
    // Start is called before the first frame update
    void Start()
    {
        totalTime = timeFactor * fireTimes;
        //fireSwitch = new List<bool>(fireTimes);
        //fireNumber = new int[fireTimes];
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 按键发射
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    trigger = true;
        //}
        if (trigger)
        {
            Shoot();
        }

        
        //Once triggered

    }

    public void Shoot()
    {
        if (counter < fireTimes)
        {
            timer += Time.deltaTime;
            if (timer >= counter * timeFactor)
            {
                print("Fire");
                transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                counter += 1;
            }

        }
        else
        {
            Initialize();
        }
        
        
    }
    private void Initialize()
    {
        timer = 0.0f;
        counter = 0;
        trigger = false;
    }

    public float Get_duration()
    {
        return totalTime; 
    }
}


