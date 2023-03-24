using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private int attackHash;
    private BossFSM mFsmSystem;
    private Animator manimstor;
    public Beats beats;
    private void Awake()
    {
        Debug.Log(1);
        MakeFSM();
        manimstor = GetComponent<Animator>();
        attackHash = Animator.StringToHash("Attack");
        EventMgr.Instance.AddListener("BossAttack", IdleToAttack);
        EventMgr.Instance.AddListener("BossIdle", AttackToIdle);
    }
    void IdleToAttack(string event_name, object udata)
    {
        if (mFsmSystem.CurrentState.StateID==BossStateID.Idle) mFsmSystem.CurrentState.Reason();
    }

    void AttackToIdle(string event_name, object udata)
    {
        if (mFsmSystem.CurrentState.StateID == BossStateID.Attack) mFsmSystem.CurrentState.Reason();
    }





    private void Update()
    {
        //Debug.Log("update");
        //Debug.Log(mFsmSystem.CurrentState);
        mFsmSystem.refresh(beats);
    }

    public void MakeFSM()
    {
        mFsmSystem = new BossFSM();

        BossIdleState bossIdleState = new BossIdleState(mFsmSystem, this);
        bossIdleState.AddTransition(BossTransition.IdleToAttack, BossStateID.Attack);

        BossAttackState bossAttackState = new BossAttackState(mFsmSystem, this);
        bossAttackState.AddTransition(BossTransition.AttackToIdle, BossStateID.Idle);

        mFsmSystem.AddState(bossIdleState);
        mFsmSystem.AddState(bossAttackState);

        Debug.Log(1);


    }

    public void Attack()
    {
        manimstor.Play("Attack");
        //Debug.Log("播放攻击动画....");
    }

    public void Idle()
    {
        manimstor.Play("Idle");
        //Debug.Log("播放 Idle 动画中....");
        /*if (manimstor.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            manimstor.Play("Idle");
            Debug.Log("播放 Idle 动画中....");
        }
        if (manimstor.GetCurrentAnimatorStateInfo(0).fullPathHash == attackHash) Debug.Log(1);
        if (manimstor.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) Debug.Log(2);*/

    }




}