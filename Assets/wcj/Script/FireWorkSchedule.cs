using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireWorkSchedule : MonoBehaviour
{
    //
    public int fireTimes;
    //public GameObject temp_button;
    //存储烟花的固定长度的开关信息
    public List<bool> fireSwitch;
    
    //存储烟花对应的编号，创建出来的烟花会带编号和配置信息进gameManager
    public List<int> fireNumber;
    public List<GameObject> Button;
    public bool yes = false;
    //public GameObject UI;

    //16长度每个长度的间隔因子
    public float timeFactor;
    //此schedule的总时间长
    //private float totalTime;
    public float timer = 0.0f;
    public int counter = 0;
    public bool trigger ;


    public GameObject firework;
    
    // Start is called before the first frame update
    void Start()
    {
        //totalTime = timeFactor * fireTimes;
        //fireSwitch = new List<bool>(fireTimes);
        //fireNumber = new int[fireTimes];
        trigger = false;
        Create(16);
    }

    // Update is called once per frame
    void Update()
    {
        //按键发射
        if (Input.GetKeyDown(KeyCode.T))
        {
            trigger = true;
        }
        if (trigger)
        {
            Shoot();
        }

        for (int i=0; i < fireTimes; i++)
        {
            if (Button[i].GetComponent<UIbutton>().selected)
            {
                fireSwitch[i] = true;
            }
            else
            {
                fireSwitch[i] = false;
            }

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
                //print("Fire");
                //transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                if(fireSwitch[counter] == true)
                {
                    Instantiate(firework, transform.position, Quaternion.identity);
                    
                }
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
        return timeFactor * fireTimes; 
    }

    public void Create(int num)
    {
        for(int i = 0; i<num ;i++)
        {
            fireSwitch.Add(false);
            fireNumber.Add(0);
            Button.Add(transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);

        }
        fireTimes = num;
        timeFactor = 0.5f;
    }
}


