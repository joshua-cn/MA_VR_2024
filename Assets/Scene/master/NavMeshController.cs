using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshController: MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public Transform target;
    public Animator animator;
    public Transform home;
    public float minimumDistance = 10f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < minimumDistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(target.position);
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
