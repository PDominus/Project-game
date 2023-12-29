using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRunState : EnemyState
{
    private EnemyGoblin enemy;

    public GoblinRunState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyGoblin enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
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

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, enemy.rb.velocity.y);

        if(enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
