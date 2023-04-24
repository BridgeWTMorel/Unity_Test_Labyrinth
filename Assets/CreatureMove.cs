using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureMove : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent navAgent;
    public Transform[] points;
    private int pointCount;
    public GameObject swordCollider;
    private bool attacking = false;
    private float timer, attackTime = 1f, speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, points.Length);
        navAgent.SetDestination(points[rand].position);
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        swordCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        GameObject enemy = GameObject.Find("Enemy");
        Transform playerTransform = player.transform;
        Vector3 playerPosition = playerTransform.position;
        Transform enemyTransform = enemy.transform;
        Vector3 enemyPosition = enemyTransform.position;

        if (Vector3.Distance (enemyPosition, playerPosition) < 3 && Time.timeScale == 1)
        {
            anim.SetTrigger("Attack");
            attacking = true;
            swordCollider.SetActive(true);
            timer = 0;
        }

        if (Vector3.Distance (enemyPosition, playerPosition) < 6 && Time.timeScale == 1)
        {
            navAgent.SetDestination(playerPosition);
            Debug.Log("Found Player, Changed to attack mode.");
        }

        if(attacking)
        {
            if(timer >= attackTime)
            {
                attacking = false;
                swordCollider.SetActive(false);
                anim.SetBool("Walk", true);
            } else
            {
                timer += Time.deltaTime;
            }
        }

        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            int rand = Random.Range(0, points.Length);
            navAgent.SetDestination(points[rand].position);
            ++pointCount;
            Debug.Log("Arrived! Point Count = " + pointCount);
        }
    }
}
