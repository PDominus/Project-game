using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblinAnimationTrigger : MonoBehaviour
{
    private EnemyGoblin enemy => GetComponentInParent<EnemyGoblin>();

    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
}
