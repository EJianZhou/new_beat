using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Beatsgame;
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void clicked()
    {
        Login pack = new Login();
        pack.Register = false;
        pack.Username = "admin";
        pack.Password = "admin";
        SendToServer.AddMsgToQueue(pack);
        SendToServer.SendMsgQueue();
        EventMgr.Instance.AddListener("REnter",onMessageBack);
    }

    void onMessageBack(string event_name,object data)
    {
        EventMgr.Instance.RemoveListener(event_name,onMessageBack);
        UIRoot.Instance.uninit("MainMenu",0);
        UIRoot.Instance.TurnTo(1);
    }
}
