using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIntelligence : MonoBehaviour
{
    public int routine;
    public float stopwatch;
    public Animator enemyAnimation;
    public Quaternion angle;
    public float grade;

    public GameObject target;
    public float speed;
    public NavMeshAgent AI;
    public bool attacking;

    private void Start()
    {
        enemyAnimation = GetComponent<Animator>();
        AI = GetComponent<NavMeshAgent>();
        AI.speed = speed;
        target = GameObject.Find("Player");
    }


    public void EnemyBehavior()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            enemyAnimation.SetBool("run", false);
            stopwatch += 1 * Time.deltaTime;

            if (stopwatch >= 3)
            {
                // Random number between 0 and 1
                routine = Random.Range(0, 2);
                stopwatch = 0;
            }

            switch (routine)
            {
                // We cancel the walkinghh animation so that the enemy remains still
                case 0:
                    enemyAnimation.SetBool("walk", false);
                    break;

                // The enemy walks
                case 1:
                    // Determine direction of travel
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    routine++;
                    break;

                case 2:
                    // Activate the walking animation
                    enemyAnimation.SetBool("walk", true);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;
            }
        }
        else // At a distance of less than 5 meters the enemy follows us.
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1.5 && !attacking)
            {
                enemyAnimation.SetBool("walk", false);
                enemyAnimation.SetBool("run", true);
                AI.SetDestination(target.transform.position);
                enemyAnimation.SetBool("attack", false);
            }
            else
            {

                enemyAnimation.SetBool("walk", false);
                enemyAnimation.SetBool("run", false);

                attacking = true;
                enemyAnimation.SetBool("attack", true);
                StartCoroutine(cancelAttack());
            }
        }
    }

    public IEnumerator cancelAttack()
    {
        yield return new WaitForSeconds(3.8f);
        enemyAnimation.SetBool("attack", false);
        attacking = false;
    }


    private void Update()
    {
        EnemyBehavior();
    }
}
