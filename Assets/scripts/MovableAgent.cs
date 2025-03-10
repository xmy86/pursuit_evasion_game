// MovableAgent.cs
using UnityEngine;
using UnityEngine.AI;

public abstract class MovableAgent : MonoBehaviour
{
    protected float moveSpeed;
    protected float turnSpeed;
    protected NavMeshAgent navMeshAgent;
    protected bool isHeuristicMode;

    protected abstract void SetMovementAttributes();
    
    protected virtual void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetMovementAttributes();
        navMeshAgent.speed = moveSpeed;
        navMeshAgent.angularSpeed = turnSpeed;
    }

    protected void Move(Vector3 targetWaypoint) // Agent's motion logic
    /*
    Select heuristic motion and Navmesh automatic navigation motion...
    by selecting in the interactive interface or switching with the Q key.
    */
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isHeuristicMode = !isHeuristicMode;

            if (isHeuristicMode)
            {
                navMeshAgent.enabled = false;
            }
            else
            {
                navMeshAgent.enabled = true;
                NavmeshMove(targetWaypoint);
            }
        }

        if (isHeuristicMode)
        {
            HeuristicMove();
        }
        else
        {
            NavmeshMove(targetWaypoint);
        }
    }

    protected void NavmeshMove(Vector3 waypoint)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(waypoint);
        }
    }

    protected void HeuristicMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
