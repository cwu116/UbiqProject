using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FireBox : MonoBehaviour
{
    // Start is called before the first frame update
    public List<FireWorkSchedule> Schedules = new List<FireWorkSchedule>();
    public float timer = 0.0f;
    public int counter = 0;
    public bool trigger = false;
    private float this_duration = 0.0f;
    private int index = 0;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            trigger = true;
        }
    }

    void Execute()
    {
        if (index <= Schedulers.Length - 1)
        {
            this_duration = Schedulers[index].Get_duration();
        }
    }
}
