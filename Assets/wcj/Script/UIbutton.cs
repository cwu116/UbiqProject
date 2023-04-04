using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ubiq.Messaging;
using Ubiq.Samples.Boids;

public class UIbutton : MonoBehaviour
{
    Button btn;
    Image img;
    //private bool owner;
    public bool selected;
    //private bool last_selected;
    private NetworkContext context;
    // Start is called before the first frame update
    
    private struct Message
    {
        public bool select;

        public Message(bool select)
        {
            this.select = select;
        }
    }

    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        img = this.gameObject.GetComponent<Image>();
        //btn.onClick.AddListener(TaskOnClick);
        //last_selected = selected;
        context = NetworkScene.Register(this);
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage msg)
    {
        var data = msg.FromJson<Message>();
        selected = data.select;
        //last_selected = selected;
        ShowColor();
    }

    void Update()
    {
        //if (last_selected != selected)
        //{
        //    context.SendJson(new Message(selected));
        //    Debug.Log("changed and sended.");
        //    last_selected = selected;
        //}
    }

    public void Sendmsg()
    {
        context.SendJson(new Message(selected));
        Debug.Log("changed and sended.");
    }

    public void ChangeColor()
    {
        if(selected == false)
        {
            selected = true;
            img.color = Color.red;
        }
        else
        {
            selected = false;
            img.color = Color.white;
        }
    }

    private void ShowColor()
    {
        if(selected == false)
        {
            img.color = Color.white;
        }
        else
        {
            img.color = Color.red;
        }
    }
}
