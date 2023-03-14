using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

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
    //private NewFireWorkManager man;

    public GameObject firework;
 
    public void See()
    {
        transform.GetChild(0).gameObject.SetActive(true);

    }
    
    public void Unsee()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //totalTime = timeFactor * fireTimes;
        //fireSwitch = new List<bool>(fireTimes);
        //fireNumber = new int[fireTimes];
        trigger = false;
        //Unsee();
        //Create(16);
        //man = GameObject.Find("FireworkManager").GetComponent<NewFireWorkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //按键发射
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    trigger = true;
        //}
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

    private void ChangeFWShapeColor(GameObject ob, int id)
    {
        ParticleSystem.MainModule settings = ob.GetComponent<ParticleSystem>().main;
        settings.startColor = FireWorkManager.instance.fireWorkDict[id].fireWorkColor;
        GameObject Around = ob.transform.GetChild(0).gameObject;
        GameObject Blast = ob.transform.GetChild(1).gameObject;
        ParticleSystem.MainModule settingsAround = Around.GetComponent<ParticleSystem>().main;
        settingsAround.startColor = FireWorkManager.instance.fireWorkDict[id].fireWorkColor;
        ParticleSystem.MainModule settingsBlast = Blast.GetComponent<ParticleSystem>().main;
        settingsBlast.startColor = FireWorkManager.instance.fireWorkDict[id].fireWorkColor;

        ParticleSystem.ShapeModule Blastshape = Blast.GetComponent<ParticleSystem>().shape;
        Blastshape.shapeType = FireWorkManager.instance.shapeDict[(int)FireWorkManager.instance.fireWorkDict[id].fireWorkShape];
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
                    GameObject ob = Instantiate(firework, transform.position, firework.transform.rotation);
                    ChangeFWShapeColor(ob, fireNumber[counter]);
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


