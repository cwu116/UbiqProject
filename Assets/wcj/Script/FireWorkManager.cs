using System.Collections;
using System.Collections.Generic;
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
        CreateShapeDict();

    }


    public void CreateNewFireWork(Color color, FireWorkShape shape)
    {
        FireWork fireWork = new FireWork(curID, color, shape);
        fireWorkDict.Add(curID, fireWork);
        curID++;
    }
    
    public void CreateShapeDict()
    {
        fireWorkDict = new Dictionary<int, FireWork>();
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
    

    
}
