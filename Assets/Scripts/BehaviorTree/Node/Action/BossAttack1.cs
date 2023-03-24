using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTtry.AI;

public class BossAttack1 : BTActionNode
{
    public override NodeState Tick()
    {
        Debug.Log("攻击！");
        return NodeState.Success;
    }
}
