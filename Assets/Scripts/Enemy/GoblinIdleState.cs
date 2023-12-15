using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : EnemyState
{
    private EnemyGoblin enemy;

    public GoblinIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyGoblin enemy) : base(enemy, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        stateTimer = 0;
        Debug.Log("Before Exit Idle StateTimer issss " + stateTimer);
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("stateTimer = " + stateTimer);
        if(stateTimer < 0)
        {
            Debug.Log("stateTimer < 0 !!!!!!!!!!!!!!!");
            stateMachine.ChangeState(enemy.runState);
            Debug.Log("enemy.runState is OK");
        }
        Debug.Log("enemy.runState is OKKKKKKKKKKKKK");
    }
}
