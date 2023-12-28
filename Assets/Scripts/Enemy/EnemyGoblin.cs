using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : Enemy
{
    public GoblinIdleState idleState { get; private set; }
    public GoblinMoveState moveState { get; private set; }
    public GoblinBattleState battleState { get; private set; }
    public GoblinAttackState attackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        moveState = new GoblinMoveState(this, stateMachine, "Move", this);
        battleState = new GoblinBattleState(this, stateMachine, "Move", this);
        attackState = new GoblinAttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
    
}
