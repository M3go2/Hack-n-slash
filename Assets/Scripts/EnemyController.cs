using System.Collections;
using UnityEngine;

using UnityEngine.AI;

public class EnemyController : MonoBehaviour

{
    CharacterStats stats;

    public Transform Player;

    NavMeshAgent agent;

    public float attackRadius = 5;

    Animator animator;

    bool canAttack = true;

    float attackCooldown = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<CharacterStats>();

        animator = GetComponentInChildren<Animator>();

    }



    // Update is called once per frame

    void Update()

    {

        animator.SetFloat("Speed", agent.velocity.magnitude);

        float distance = Vector3.Distance(transform.position, LevelManager.Instance.player.position);

        agent.SetDestination(LevelManager.Instance.player.position);



        if (distance < attackRadius)

        {

            if (distance <= agent.stoppingDistance)

            {

                if (canAttack)
                {

                    StartCoroutine(cooldown());

                    //Play attack animation

                    animator.SetTrigger("Attack");

                }

            }

        }

    }







    IEnumerator cooldown()

    {

        canAttack = false;

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;

    }



    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Player"))
        {

            Debug.Log("Player Contacted!");
            stats.ChangeHealth(-other.GetComponentInParent<CharacterStats>().power);

            //Reduce health
        }
    }
    public void DamagePlayer()
    {
        LevelManager.Instance.player.GetComponent<CharacterStats>().ChangeHealth(-stats.power);
    }

}

