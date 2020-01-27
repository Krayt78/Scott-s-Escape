﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyNavigation : MonoBehaviour
{

    private NavMeshAgent m_navMeshAgent;

    //Serialized Fields
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 targetLastSeenPosition;

    private EnnemyAI.State state;



    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<EnnemyAI>().state;
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_navMeshAgent.Warp(transform.position);

    }


    //Reacts to the event OnTargetSighted and takes the first target in the array to start the chase
    public void ChaseTarget()
    {
        target = GetComponent<FieldOfView>().visibleTargets[0].gameObject;
        StartCoroutine(SetDestinationWithDelay(.2f));
    }

    //Reacts to the event OnTargetLost and nulls the target and sets his LastSeenPosition
    public void HandleTargetLost()
    {
        targetLastSeenPosition = target.transform.position;
        target = null;
    }


    IEnumerator SetDestinationWithDelay(float delay)
    {
        while (target)
        {
            m_navMeshAgent.SetDestination(target.transform.position);
            yield return new WaitForSeconds(delay);
        }
    }


}
