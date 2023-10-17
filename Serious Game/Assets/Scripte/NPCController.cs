using UnityEngine;
using UnityEngine.AI;

public class NPCController: MonoBehaviour
{
    public Transform[] destinations;
    private int currentDestination = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextDestination();
    }

    void Update()
    {
      
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            MoveToNextDestination();
        }
    }

    void MoveToNextDestination()
    {
        if (currentDestination < destinations.Length)
        {
            agent.SetDestination(destinations[currentDestination].position);
            currentDestination++;
        }
        else
        {
            currentDestination = 0;
            agent.SetDestination(destinations[currentDestination].position);
            currentDestination++;
        }
    }
}
