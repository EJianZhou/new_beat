﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDMgr : MonoBehaviour
{
    private static IDMgr _instance;
    public static IDMgr Instance
    {
        get
        {
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Awake() {
        if(_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    public uint id;
    public uint playerID { get;set; }
    public void set_id(uint x)
    {
        id=x;
    }

    public uint get_id()
    {
        return id;
    }
}
