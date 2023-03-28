using System.Collections;
using System.Collections.Generic;
using Ubiq.Messaging;
using UnityEngine;

public class CreateFireWorkManger : MonoBehaviour
{
    public static CreateFireWorkManger instance;
    public GameObject prefab;

    private NetworkContext context; // new
    private bool owner; // new

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        
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
            GameObject gameobj = Instantiate(prefab);
            gameobj.transform.position = GameObject.Find("Player").transform.position + Vector3.up * 1;
            context.SendJson(new Message(gameobj.transform.position));
        }
    }




    private struct Message
    {
        //public Dictionary<int, FireWork> fireWorkDictFromOther;

        //public Message(Dictionary<int, FireWork> fireWorkDict)
        //{
        //    fireWorkDictFromOther =  new Dictionary<int, FireWork>(fireWorkDict);

        //}

        public Vector3 transform;
        public Message(Vector3 pos)
        {
            this.transform = pos;
        }
    }



    public void ProcessMessage(ReferenceCountedSceneGraphMessage msg)
    {
        // 3. Receive and use transform update messages from remote users
        // Here we use them to update our current position
        var data = msg.FromJson<Message>();
        GameObject gameobj = Instantiate(prefab);
        gameobj.transform.position = data.transform;
        //fireWorkDict = data.fireWorkDictFromOther;
    }
}
