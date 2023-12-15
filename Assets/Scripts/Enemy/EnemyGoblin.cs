using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : Enemy
{
    public GoblinIdleState idleState { get; private set; }
    public GoblinRunState runState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        runState = new GoblinRunState(this, stateMachine, "Run", this);
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
