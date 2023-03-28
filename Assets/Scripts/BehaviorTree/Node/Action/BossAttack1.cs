using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTtry.AI;

public class BossAttack1 : BTActionNode
{
    public override NodeState Tick()
    {
        Debug.Log("攻击！");
        BossSkill1.Skill1Beats[] sb = new BossSkill1.Skill1Beats[3];
        sb[0].interval = 3;
        sb[0].type = 1;
        sb[1].interval = 1;
        sb[1].type = 1;
        BossSkill1.Instance.StartCount(2, sb);
        return NodeState.Success;
    }
}
