using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FireBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject temp;
    public List<GameObject> S_objects;
    public List<FireWorkSchedule> Schedulers;
    //= new List<FireWorkSchedule>()
    public float timer = 0.0f;
    public int counter = 0;
    public bool trigger = false;
    public float this_duration = 0.0f;
    public int index = 0;


    //void Awake()
    //{

    //}
    void Start()
    {
        //S_objects.Add(Instantiate(temp));
        //Schedulers[0] = S_objects[0].GetComponent<FireWorkSchedule>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            trigger = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            add(16);
        }
        
        if (trigger)
        {
            Execute();
        }
    }

    void Execute()
    {
        timer += Time.deltaTime;

        if (index <= Schedulers.Count - 1)
        {

            if (timer >= this_duration)
            {
                print(timer);
                Schedulers[index].trigger = true;
                this_duration += Schedulers[index].Get_duration();
                index += 1;
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
        this_duration = 0.0f;
        index = 0;
    }

    private void add(int capacity)
    {

        //Schedulers.Add(new FireWorkSchedule());
        //GameObject temp2 = Instantiate(temp)
        S_objects.Add(Instantiate(temp, transform.position, Quaternion.identity, transform));
        Schedulers.Add(S_objects[S_objects.Count - 1].GetComponent<FireWorkSchedule>());
        //Schedulers[-1].Create(capacity);
    }
}
