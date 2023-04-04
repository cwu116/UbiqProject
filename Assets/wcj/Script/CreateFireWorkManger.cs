using System.Collections;
using System.Collections.Generic;
using Ubiq.Messaging;
using UnityEngine;

public class CreateFireWorkManger : MonoBehaviour
{
    public static CreateFireWorkManger instance;
    public GameObject prefab;
    public Material skyboxMat;
    private NetworkContext context; // new
    private bool owner; // new

    float count;
    int cd;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        cd = 5;
        count = 5;
    }

    private void Start()
    {
        context = NetworkScene.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewFireWork();
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            LauchFireWork();
        }

        count += Time.deltaTime;
    }

    public void CreateNewFireWork()
    {
        if (count > cd)
        {
            GameObject gameobj = Instantiate(prefab);
            gameobj.transform.position = GameObject.Find("Player").transform.position + Vector3.up * 1;
            gameobj.transform.rotation = GameObject.Find("Player").transform.rotation;
            gameobj.transform.parent = this.gameObject.transform;
            context.SendJson(new Message(gameobj.transform.position, gameobj.transform.rotation,0));
            count = 0;
        }
    }

    public void LauchFireWork()
    {
        FireBox [] fireboxs = transform.GetComponentsInChildren<FireBox>();
        foreach( var x in fireboxs)
        {
            x.trigger = true;
        }
        context.SendJson(new MessageLaunch(1));
        RenderSettings.skybox = skyboxMat;
    }


    private struct Message
    {
  

        public Vector3 transform;
        public Quaternion rotation;
        public int id;
        public Message(Vector3 pos, Quaternion rotation,int id)
        {
            this.transform = pos;
            this.rotation = rotation;
            this.id = id;
        }
    }

    private struct MessageLaunch
    {
        public int id;
        public MessageLaunch(int id)
        {
            this.id = id;
        }
    }



    public void ProcessMessage(ReferenceCountedSceneGraphMessage msg)
    {
        // 3. Receive and use transform update messages from remote users
        // Here we use them to update our current position
        var data = msg.FromJson<Message>();
        if (data.id == 0)
        {
            GameObject gameobj = Instantiate(prefab);
            gameobj.transform.position = data.transform;
            gameobj.transform.rotation = data.rotation;
            gameobj.transform.parent = this.gameObject.transform;
        }
        else if (data.id == 1)
        {
            FireBox[] fireboxs = transform.GetComponentsInChildren<FireBox>();
            foreach (var x in fireboxs)
            {
                x.trigger = true;
            }
            RenderSettings.skybox = skyboxMat;
        }
    }
}
