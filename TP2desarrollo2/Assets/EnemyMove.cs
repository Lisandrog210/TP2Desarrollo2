using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float minDist = 4;   
    [SerializeField] private Transform target;
    [SerializeField] private Transform myTransform;    
    Animator AnimatorEnemy;
    float dist;   
    bool colPiso = false;
    bool isDead;
    bool isAtacking;
    
    public bool IsAtacking
    {
        get { return isAtacking; }
        set { isAtacking = value; }
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }

    }

    private void Awake()
    {
        isDead = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        AnimatorEnemy = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();       
    }

    void Atack()
    {        
        AnimatorEnemy.SetTrigger("Atack");
        AnimatorEnemy.SetInteger("WichAtack", Random.Range(1, 4));        
    }

    void Move()
    {
        if (!isDead)
        {
            agent.SetDestination(target.position);
            AnimatorEnemy.SetFloat("Speed", 1);
        }
        else { agent.SetDestination(transform.position); }
    }



    void Update()
    { 
        dist = (Vector3.Distance(transform.position, target.position));
        AnimatorEnemy.SetFloat("DistanceToPlayer",dist);

        if ( dist >= minDist)
        {           
            Move();            
        }
        else AnimatorEnemy.SetFloat("Speed", 0);

        if (dist <= minDist)
        {
            Atack();
            isAtacking = true;
        }
        else isAtacking = false;
    }
}
