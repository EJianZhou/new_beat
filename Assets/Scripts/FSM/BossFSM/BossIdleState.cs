using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(BossFSM fsm, BossController player) : base(fsm, player)
    {
        mStateID = BossStateID.Idle;
    }

    public override void Act()
    {
        mPlayer.Idle();
    }

    public override void Reason()
    {
        mFSM.PerformTransition(BossTransition.IdleToAttack);
    }
}