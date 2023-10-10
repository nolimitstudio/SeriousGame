using UnityEngine;
using UnityEngine.AI;

public class RandomNavMeshMovement : MonoBehaviour
{
    public Transform[] destinationPoints;
    private NavMeshAgent navMeshAgent;
    private bool isLookingForNewDestination = false;
    public float timeBetweenDestinations = 2f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        
        SetRandomDestination();
    }

    private void Update()
    {
       
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            
            if (!isLookingForNewDestination)
            {
                isLookingForNewDestination = true;
                Invoke("SetRandomDestination", timeBetweenDestinations);
                 navMeshAgent.Stop();
            }
        }
    }

    private void SetRandomDestination()
    {
         
        if (destinationPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, destinationPoints.Length);
            Vector3 randomDestination = destinationPoints[randomIndex].position;

         
            navMeshAgent.SetDestination(randomDestination);
            isLookingForNewDestination = false; 
            navMeshAgent.Resume();
        }
    }
}
