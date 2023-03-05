using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float upperbound = 10.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.down * Time.deltaTime * speed);
        if (transform.position.y > upperbound)
        {
            Destroy(gameObject);
        }
    }
}
