using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackNode : Node
{
    private NavMeshAgent agent;
    private EnemyController ai;

    // Start is called before the first frame update
  public AttackNode(NavMeshAgent agent,EnemyController ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        agent.isStopped = true;
        return NodeState.RUNNING;
    }
}
