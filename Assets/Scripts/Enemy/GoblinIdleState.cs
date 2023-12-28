using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : GoblinGroundedState
{
    public GoblinIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyGoblin enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
