using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : Node
{
    private EnemyController ai;
    private float range;
    private Transform target;
    private Transform origin;


    void Start()
    {
       
    }
    public RangeNode(EnemyController ai,float range, Transform target, Transform origin)
    {
        this.ai = ai;
        this.range = range;
        this.target = target;
        this.origin = origin;
    }
    // Start is called before the first frame update
    public override NodeState Evaluate()
    {
       // float distance = Vector3.Distance(target.position, origin.position);
        return ai.playerInAttackRange ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
