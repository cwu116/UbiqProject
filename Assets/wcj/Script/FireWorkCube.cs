using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkCube : MonoBehaviour
{
    [SerializeField] List<GameObject> fireWorkButton;
    [SerializeField] List<bool> fireWorkSwitch;
    [SerializeField] GameObject fireWorkPrefab;
    [SerializeField] int factor;

    [SerializeField]bool trigger;

    GameObject lastPrefab;
    bool coroutineTriggered;
    int counter;
    int fireTimes;
    
    // Start is called before the first frame update
    void Start()
    {
        fireTimes = 16;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fireWorkButton.Count; i++)
        {
            if (fireWorkButton[i].GetComponent<UIbutton>().selected)
            {
                fireWorkSwitch[i] = true;
            }
            else
            {
                fireWorkSwitch[i] = false;
            }

        }

        if (trigger)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (counter < fireTimes && coroutineTriggered == false)
        {
            StartCoroutine("ShootFireWork");
            coroutineTriggered = true;
        }
        if(counter >= fireTimes)
        {
            Initialize();
        }        
    }

    IEnumerator ShootFireWork()
    {
        while (true)
        {
            if (fireWorkSwitch[counter] == true)
            {
                lastPrefab = Instantiate(fireWorkPrefab, transform.position, fireWorkPrefab.transform.rotation);

            }         
            counter += 1;
            Debug.LogError(counter);
            yield return new WaitForSeconds(factor);
            if(lastPrefab != null)
            Destroy(lastPrefab);
        }
     
    }

    private void Initialize()
    {
        fireTimes = 16;
        counter = 0;
        trigger = false;
        coroutineTriggered = false;
        StopCoroutine("ShootFireWork");
        Debug.LogError("Stop");
    }
}
