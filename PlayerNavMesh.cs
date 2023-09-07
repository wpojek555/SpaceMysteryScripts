using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerNavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform movePositionTransform;
    public Transform patrolPath;
    public Animator anim;
    public Animator anim2;
    public bool isChasing;
    public GameObject man;
    bool isEnemySpotted;
    public AudioSource EnemySpotted;
    public AudioClip enemy;
    public AudioClip enemyAtacking;
    bool isEnemyAtacked;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        float dist = Vector3.Distance(movePositionTransform.position, transform.position);
        Debug.Log(dist);

            if(dist >= 17f || !isChasing)
            {
                navMeshAgent.destination = patrolPath.position;
            isEnemySpotted = false;
            isEnemyAtacked = false;
            if (dist <= 4f)
            {
                navMeshAgent.destination = transform.position;
                transform.LookAt(movePositionTransform.position);
                transform.Rotate(0f, 33f, 0f);
                man.SetActive(false);
                anim.SetBool("isAttacking", true);
                anim2.SetBool("isAttacking", true);
            }

        }
            else
            {
            if (isEnemySpotted == false)
            {
                isEnemySpotted = true;
                EnemySpotted.clip = enemy;
                EnemySpotted.Play();
            }
        
            navMeshAgent.destination = movePositionTransform.position;
            if (dist <= 4f)
            {
                navMeshAgent.destination = transform.position;
                if (isEnemyAtacked == false)
                {
                    isEnemyAtacked = true;
                    EnemySpotted.clip = enemyAtacking;
                    EnemySpotted.Play();
                }
                man.SetActive(false);
                anim.SetBool("isAttacking", true);
                anim2.SetBool("isAttacking", true);
            }
        }
            
        navMeshAgent.autoBraking = true;

    }
}
