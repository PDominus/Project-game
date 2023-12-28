using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinGroundedState : EnemyState
{
    protected EnemyGoblin enemy;

    public GoblinGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemyGoblin enemy) : base(enemyBase, stateMachine, animBoolName)
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

        if (enemy.IsPlayerDetected())
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
