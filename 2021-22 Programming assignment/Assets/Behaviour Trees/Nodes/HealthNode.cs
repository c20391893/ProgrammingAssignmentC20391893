using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode: Node
{
private EnemyController ai;
    private EnemyStats ES;
    private float threshold;

    public HealthNode(EnemyController ai, EnemyStats ES,float threshold)
    {
       this.ai = ai;
        this.ES = ES;
       this.threshold = threshold;
    }

   public override NodeState Evaluate()
    {
       return ES.GetCurrentHealth() <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
        
    }
 }
