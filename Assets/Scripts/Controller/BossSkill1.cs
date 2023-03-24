using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill1 : MonoBehaviour
{
    private static BossSkill1 _instance;
    public static BossSkill1 Instance
    {
        get
        {
            return _instance;
        }
    }
    public struct Skill1Beats
    {
        public int type;
        public int interval;
    };

    int length;
    int nowpos;
    int flag;
    Skill1Beats[] Beat = new Skill1Beats[100];
    int startpos;
    int intervalp;
    public void StartCount(int len,Skill1Beats[] beats)
    {
        length = len;
        Beat = beats;
        nowpos=0;
        flag=0;
        intervalp = 40;
        if (len % 2 == 1)
        {
            int tmp = (len - 1) / 2;
            startpos = -tmp * intervalp;
        }
        else
        {
            int tmp = len / 2 - 1;
            startpos = -tmp * intervalp - intervalp / 2;
        }
        EventMgr.Instance.AddListener("BEAT!",CreateBox);
    }

    void CreateBox(string event_name, object udata)
    {
        EventMgr.Instance.RemoveListener("BEAT!",CreateBox);
        UIRoot.Instance.init("Prefabs","Box","FunctionLayer",0);
        EventMgr.Instance.AddListener("BEAT!",CreateBeat);
    }

    void CreateBeat(string event_name, object udata)
    {
        flag++;
        if(flag == Beat[nowpos].interval)
        {
            flag = 0;
            Vector3 v = new Vector3(startpos+462.5f,140+198.0f,0);
            startpos += intervalp;
            UIRoot.Instance.init("Prefabs","DefendBeat","FunctionLayer",nowpos);
            UIRoot.Instance.MoveSon("FunctionLayer","DefendBeat",nowpos, "Point",v);
            nowpos++;
            if(nowpos == length)
            {
                EventMgr.Instance.RemoveListener("BEAT!",CreateBeat);
            }
        }
    }

    public void StartAttack()
    {

    }

    void Awake() {
        if(_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
