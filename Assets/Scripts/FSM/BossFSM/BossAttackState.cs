using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    public BossAttackState(BossFSM fsm, BossController player) : base(fsm, player)
    {
        mStateID = BossStateID.Attack;
    }

    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void Act()
    {
        mPlayer.Attack();
        //mAttackTimer += Time.deltaTime;
        //if (mAttackTimer > mAttackTime)
        //{
        //mPlayer.Attack(targets[0]);
        //mAttackTimer = 0;
        //}
    }

    public override void Reason()
    {
        mFSM.PerformTransition(BossTransition.AttackToIdle);
    }



}