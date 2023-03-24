using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMgr : MonoBehaviour
{
    private static ToolMgr _instance;
    public static ToolMgr Instance
    {
        get
        {
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    public int FloatTransInt(float x,int y)
    {
        int ten = 1;
        for(int i=0;i<y;i++)ten = ten * 10;
        int ret = (int)(x*ten);
        return ret;
    }

    public float IntTransFloat(int x,int y)
    {
        int ten = 1;
        for(int i=0;i<y;i++)ten = ten * 10;
        float ret = ((float)x)/ten;
        return ret;
    }
}
