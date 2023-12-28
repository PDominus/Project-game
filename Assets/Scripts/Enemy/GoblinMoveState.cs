using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoveState : GoblinGroundedState
{
    public GoblinMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyGoblin enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

        if(enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
