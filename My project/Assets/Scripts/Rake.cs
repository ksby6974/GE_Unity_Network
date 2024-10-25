using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public enum State
{
    Walk = 1,
    Attack = 2,
    Die = 3,
}


public class Rake : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] GameObject destination;
    [SerializeField] Animator animator;
    [SerializeField] State state;

    void Awake()
    {
        state = State.Walk;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        destination = GameObject.Find("Nexus");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(destination.transform.position);
        transform.LookAt(destination.transform.position);

        Movement_Enemy();
    }

    void Movement_Enemy()
    {
        switch (state)
        {
            case State.Walk :
                Move_Walk();
                break;

            case State.Attack :
                Move_Attack();
                break;

            case State.Die :
                Move_Die();
                break;

            default:
                break;
        }
    }

    public void Move_Walk()
    {
        animator.Play("Walk");
    }

    public void Move_Attack()
    {
        animator.Play("Attack");
    }

    public void Move_Die()
    {
        animator.Play("Die");
        PhotonNetwork.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nexus"))
        {
            Debug.Log("Ãæµ¹");
            state = State.Attack;
        }
    }
}
