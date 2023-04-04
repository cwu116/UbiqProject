using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Ubiq.Messaging;
using UnityEditor;
//using UnityEditor.Rendering.LookDev;

public class FireBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject temp;
    public List<GameObject> S_objects;
    public List<FireWorkSchedule> Schedulers;
    //public List<GameObject> Button;
    //= new List<FireWorkSchedule>()
    public float timer = 0.0f;
    public int counter = 0;
    public bool trigger = false;
    private bool last_trigger;
    public float this_duration = 0.0f;
    public int index = 0;
    private int last_onScreen = 0;
    public int onScreen;


    // network part
    private NetworkContext context;

    private struct Message
    {
        public bool trigger;

        public Message(bool tr)
        {
            this.trigger = tr;
        }
    }


    public void Xianshi()
    {
        Schedulers[last_onScreen].Unsee();
        Schedulers[onScreen].See();
        last_onScreen = onScreen;
    }
    void Start()
    {
        //S_objects.Add(Instantiate(temp));
        //Schedulers[0] = S_objects[0].GetComponent<FireWorkSchedule>();
        Initialize();
        last_onScreen = 0;
        onScreen = 0;
        last_trigger = trigger;
        Add(16);
        context = NetworkScene.Register(this);
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage msg)
    {
        var data = msg.FromJson<Message>();
        trigger = data.trigger;
        last_trigger = trigger;
    }


    private void FixedUpdate()
    {
        if (last_trigger != trigger)
        {
            context.SendJson(new Message(trigger));
            last_trigger = trigger;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            trigger = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Add(16);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NextPage();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PrePage();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Schedulers[onScreen].See();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Schedulers[onScreen].Unsee();
        }

        if (trigger)
        {
            Execute();
        }


    }

    public void PrePage()
    {
        onScreen += S_objects.Count;
        onScreen -= 1;
        onScreen %= S_objects.Count;
        Xianshi();
    }

    public void NextPage()
    {
        onScreen += 1;
        onScreen %= S_objects.Count;
        Xianshi();
    }

    void Execute()
    {
        timer += Time.deltaTime;

        if (index <= Schedulers.Count - 1)
        {

            if (timer >= this_duration)
            {
                //print(timer);
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

    public void Add(int capacity)
    {

        S_objects.Add(Instantiate(temp, transform.position, transform.rotation, transform));
        Schedulers.Add(S_objects[S_objects.Count - 1].GetComponent<FireWorkSchedule>());
        Schedulers[S_objects.Count - 1].Create(capacity);
        onScreen = S_objects.Count - 1;
        Xianshi();
    }
}
