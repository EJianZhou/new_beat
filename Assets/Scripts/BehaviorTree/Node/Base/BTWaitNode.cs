using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTtry.AI;
using System;

public class BTWaitNode : BTNode
{
    private int beatVal, num = 0;
    public BTWaitNode(int beatVal)
    {
        this.beatVal = beatVal;
        EventMgr.Instance.AddListener("BEAT!", ValUpdate);
    }
    public override NodeState Tick()
    {
        Debug.Log("puz" + num);
        if (num == beatVal)
        {
            num = 0;
            return NodeState.Success;
        }
        return NodeState.Running;
    }

    public void ValUpdate(string event_name, object udata)
    {
        num++;
    }


}
