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

        enemy.SetVelocity(2 * enemy.facingDir, enemy.rb.velocity.y);
        Debug.Log("enemy.facingDir = " + enemy.facingDir);

        if(enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            Debug.Log("Before Flipppppp");
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
            Debug.Log("Now idleeeeeeeeeeeeee");
        }
    }
}
