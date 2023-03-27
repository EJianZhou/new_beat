using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingController : MonoBehaviour
{
    float x,st,en;
    float speed;
    int times,nowtime;
    public GameObject ir,or;
    RectTransform irmt,ormt;
    // Start is called before the first frame update
    private void Start() {
        x=ToolMgr.Instance.GetRingTime();
        st=400;
        en=200;
        irmt = ir.GetComponent<Image>().GetComponent<RectTransform>();
        ormt = or.GetComponent<Image>().GetComponent<RectTransform>();
        irmt.sizeDelta = new Vector2(en,en);
        ormt.sizeDelta = new Vector2(st,st);
        
        times = (int)(25*x);
        speed = (st-en)/times;

        nowtime=0;
        EventMgr.Instance.AddListener("ROperation",doupdate);
    }
    private float abs(float xx)
    {
        return xx>0?xx:-xx;
    }
    private void doupdate(string event_name, object udata)
    {
        if(nowtime<times)
        {
            st-=speed;
            nowtime++;

        }
        else
        {
            UIRoot.Instance.uninit("Ring",0);
            EventMgr.Instance.RemoveListener("ROperation",doupdate);
        }
    }

    private void Update() {
        ormt.sizeDelta = new Vector2(st,st);
    }
}
