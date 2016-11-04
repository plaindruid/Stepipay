using UnityEngine;
using System.Collections;


public class Mummy : MonoBehaviour
{
   // public NavMeshAgent mummy;
    public Animator anim;
    public int animIndex;
    GameObject target;
    public GameObject[] waypoints;
    public int ran;
    public int wp;
    GameObject tempGM;


    public enum enemyStates
    {
        idle, patrol, chase, attack
    };

    public enemyStates es;

    void Start()
    {
        ran = Random.Range(0, wp);
        target = GameObject.FindGameObjectWithTag("Player");
        es = enemyStates.patrol;
        tempGM = GameObject.FindGameObjectWithTag("GameManager");

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 15f && Vector3.Distance(transform.position, target.transform.position) >= 5f)
        {
            es = enemyStates.chase;
        }
        else if (Vector3.Distance(transform.position, target.transform.position) < 5f)
        {
            es = enemyStates.attack;
        }
        else
        {
            es = enemyStates.patrol;
        }

        


        switch (es)
        {
            case enemyStates.idle:
                idleState();
                break;

            case enemyStates.patrol:
                patrolState();
                break;

            case enemyStates.chase:
                chaseState();
                break;

            case enemyStates.attack:
                attackState();
                break;
        }
    }

    void idleState()
    {
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(transform.position);
        this.gameObject.GetComponent<NavMeshAgent>().Stop();
    }

    void patrolState()
    {
        animIndex = 1;
        anim.GetComponent<Animator>().SetInteger("animIndex", animIndex);
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(waypoints[ran].transform.position);
        
    }

    void chaseState()
    {
        animIndex = 2;
        anim.GetComponent<Animator>().SetInteger("animIndex", animIndex);
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }

    void attackState()
    {
        animIndex = 3;
        anim.GetComponent<Animator>().SetInteger("animIndex", animIndex);
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WP")
        {
            int temp = Random.Range(0, wp);
            while (temp == ran)
            {
                temp = Random.Range(0, wp);
            }
            ran = temp;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tempGM.GetComponent<GameManager>().playerLife -= 20;
        }
    }
}
