using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcController : MonoBehaviour
{

    public Transform currentGoal;
    public Transform[] goals = new Transform[3];
    public int goalIndex;
    
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentGoal = goals[0];
        agent.destination = currentGoal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
