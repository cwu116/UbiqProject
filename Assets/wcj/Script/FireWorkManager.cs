using System.Collections;
using System.Collections.Generic;
using Ubiq.Messaging;
using UnityEngine;

public class FireWorkManager : MonoBehaviour
{
    public static FireWorkManager instance;

    //存储创建好的不同类型的烟花
    public Dictionary<int, FireWork> fireWorkDict;
    public Dictionary<int, ParticleSystemShapeType> shapeDict; 
    int curID;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireWorkDict = new Dictionary<int, FireWork>();
        shapeDict = new Dictionary<int, ParticleSystemShapeType>();
        CreateShapeDict();

        context = NetworkScene.Register(this);
    }


    public void CreateNewFireWork(Color color, FireWorkShape shape)
    {
        FireWork fireWork = new FireWork(curID, color, shape);
        fireWorkDict.Add(curID, fireWork);
        curID++;
        context.SendJson(new Message(color, shape));
        owner = true;
    }
    
    public void CreateShapeDict()
    {
        
        shapeDict.Add(0, ParticleSystemShapeType.Sphere);
        shapeDict.Add(1, ParticleSystemShapeType.Cone);
        shapeDict.Add(2, ParticleSystemShapeType.Donut);
        shapeDict.Add(3, ParticleSystemShapeType.Mesh);
        shapeDict.Add(4, ParticleSystemShapeType.Sprite);
        shapeDict.Add(5, ParticleSystemShapeType.Hemisphere);
        shapeDict.Add(6, ParticleSystemShapeType.Circle);
        shapeDict.Add(7, ParticleSystemShapeType.Box);
        shapeDict.Add(8, ParticleSystemShapeType.Rectangle);
    }


    private NetworkContext context; // new
    private bool owner; // new

    private struct Message
    {
        //public Dictionary<int, FireWork> fireWorkDictFromOther;

        //public Message(Dictionary<int, FireWork> fireWorkDict)
        //{
        //    fireWorkDictFromOther =  new Dictionary<int, FireWork>(fireWorkDict);

        //}
 
        public Color color;
        public FireWorkShape fireworkShape;
        public Message(Color color, FireWorkShape fireworkShape )
        {
            this.color = color;
            this.fireworkShape = fireworkShape;
        }
    }

    private void FixedUpdate()
    {
        if (owner)
        {
            // 4. Send transform update messages if we are the current 'owner'

            owner = false;
        }
    }


    public void ProcessMessage(ReferenceCountedSceneGraphMessage msg)
    {
        // 3. Receive and use transform update messages from remote users
        // Here we use them to update our current position
        var data = msg.FromJson<Message>();
        FireWork fireWork = new FireWork(curID, data.color, data.fireworkShape);
        fireWorkDict.Add(curID, fireWork);
        curID++;
        //fireWorkDict = data.fireWorkDictFromOther;
    }


}
