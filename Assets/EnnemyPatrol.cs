﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnnemyPatrol : MonoBehaviour
{

    public event Action OnWaypointReached = delegate { };

    [SerializeField]
    private List<GameObject> WaypointPatrolList = new List<GameObject>();
    private int currentWaypointNumber;
    private NavMeshAgent m_navMeshAgent;

    private EnnemyAI.State state;

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        GoToNextCheckpoint();
    }

    public void GoToNextCheckpoint()
    {
        if (WaypointPatrolList.Count == (currentWaypointNumber + 1))
            currentWaypointNumber = 0;
        else currentWaypointNumber++;

        m_navMeshAgent.SetDestination(WaypointPatrolList[currentWaypointNumber].transform.position);
    }

    public bool DestinationReached()
    {
        // Check if we've reached the destination
        if (!m_navMeshAgent.pathPending)
        {
            if (m_navMeshAgent.remainingDistance <= m_navMeshAgent.stoppingDistance)
            {
                if (!m_navMeshAgent.hasPath || m_navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
