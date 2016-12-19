using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SphereCollider))]
public class EnemyAI : MonoBehaviour
{
    #region Public Enumerations
    public enum _enemyStates
    {
        Idle,
        Chase,
        Patrolling,
		Attacking
    };

    public enum _EnemyAggressive
    {
        Hideable,
        UnHideable
    };

    public enum _IdleType
    {
        Searching,
        Idle_on_Place
    };


    Transform target;
    public _enemyStates Enemy_States;
    public _EnemyAggressive Enemy_Aggressives;
    public _IdleType Enemy_IdleTypes;
    #endregion

    #region Public Variables

	public Animator anim;
    public GameObject[] EyeSight;
    public Transform[] Waypoints;
    public float Search_duration;


    #endregion

    #region Private Variables
    float Temp_enemy_Radius, Lower_Enemy_Radius;
    float Temp_Enemy_Eyes, Lower_Enemy_Eyes;
    _enemyStates Temp_enemy_States;
    _IdleType Temp_Idle_type;
    float searching_time,chase_time;
    Transform target_waypoint;
    bool Eyesight_lowered = false;
    #endregion


    SphereCollider EnemySense;
    // Use this for initialization

    void OnEnable()
    {
        if (Enemy_Aggressives == _EnemyAggressive.Hideable)
        {
            ButtonControllers._hide_player += LesserView;
            ButtonControllers._unhide_player += ResetView;
        }
    }

    void OnDisable()
    {
        if (Enemy_Aggressives == _EnemyAggressive.Hideable)
        {
            ButtonControllers._hide_player -= LesserView;
            ButtonControllers._unhide_player -= ResetView;
        }
    }

    void Awake()
    {
        EnemySense = GetComponent<SphereCollider>();
        target = GameObject.Find("Player").transform;  
        #region Eyes ng Enemy
        if (!EnemySense.isTrigger)
        {
            EnemySense.isTrigger = true;
        }
        if (EyeSight.Length > 0)
        {
            Temp_Enemy_Eyes = 10;
            foreach (GameObject go in EyeSight)
            {
                go.GetComponent<EnemyEyes>().eye_distance = Temp_Enemy_Eyes;
            }
        }
        else
        {
            Debug.LogWarning("No Eyes gameobject attach"); 
        }

        #endregion

        Temp_enemy_Radius = EnemySense.radius;
        Lower_Enemy_Radius = EnemySense.radius * 0.25f;
        Temp_enemy_States = Enemy_States;
        Temp_Idle_type = Enemy_IdleTypes;
        target_waypoint = ChangeWaypoint();
    
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (Enemy_States)
        {
            case _enemyStates.Idle:
				Idle(); 
				break;
            case _enemyStates.Chase:
                Chase();
				
                break;
            case _enemyStates.Patrolling:
                Patrol(); 
				break;
			case _enemyStates.Attacking:
				AnimationCotrollers("Attacking"); 
				break;
	        default:
                break;
        }
    }

    void Idle()
    {
		
        if (Enemy_IdleTypes == _IdleType.Idle_on_Place)
        {
            GetComponent<NavMeshAgent>().SetDestination(transform.position);

        }

        if (Enemy_IdleTypes == _IdleType.Searching)
        {
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Searching();
        }
    }

    void Chase()
    {
		chase_time += Time.deltaTime;
		if (chase_time <= Search_duration)
		{
			AnimationCotrollers("Running"); 
			GetComponent<NavMeshAgent>().SetDestination(target.position);
			//Animation codes dito
		}
		else
		{
			chase_time = 0;
            Enemy_States = Temp_enemy_States;
            Enemy_IdleTypes = Temp_Idle_type;
        }

		if (GetComponent<NavMeshAgent> ().remainingDistance <= GetComponent<NavMeshAgent> ().stoppingDistance) 
		{
			chase_time = 0;
			Enemy_States = _enemyStates.Attacking; 
		}
        // Debug.Log(GetComponent<NavMeshAgent>().remainingDistance.ToString()); 
    }

    void OnTriggerEnter(Collider col)
    {
		if (col.tag == "Player")
        {
            target = col.transform;
            Enemy_States = _enemyStates.Idle;
            Enemy_IdleTypes = _IdleType.Searching;
        }
    }

    void Patrol()
    {
        Debug.Log(target_waypoint.name);
		AnimationCotrollers("Walking"); 
        if(GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance)
        {
            target_waypoint = ChangeWaypoint();
            GetComponent<NavMeshAgent>().SetDestination(target_waypoint.position);
        }
        else
        {
            //Debug.Log("Weeeeeako"); 
            GetComponent<NavMeshAgent>().SetDestination(target_waypoint.position);
        }
    }

    Transform ChangeWaypoint()
    {
        Transform res_waypoint;
        if (Waypoints.Length > 0)
        {
            int RandomPoint;
            RandomPoint = Random.Range(0, Waypoints.Length);
            res_waypoint = Waypoints[RandomPoint];
        }
        else
        {
            res_waypoint = transform;
        }

        return res_waypoint;

    }

    void Searching()
    {
        searching_time += Time.deltaTime;
        if (searching_time <= Search_duration)
        {
            Debug.Log("Searching");
			AnimationCotrollers("Idle"); 
            //Animation codes dito
        }
        else
        {
            searching_time = 0;
            Enemy_States = Temp_enemy_States;
            Enemy_IdleTypes = Temp_Idle_type;
        }
    }

    void OnTriggerExit(Collider col)
    {
		if (col.tag == "Player" && Enemy_States != _enemyStates.Chase)
        {
            Enemy_States = _enemyStates.Idle;
        }
    }

    void LesserView()
    {
        EnemySense.radius = Lower_Enemy_Radius;
        if (EyeSight.Length > 0 && !Eyesight_lowered )
        {
            Eyesight_lowered = true;
            foreach (GameObject go in EyeSight)
            {
                Lower_Enemy_Eyes = go.GetComponent<EnemyEyes>().eye_distance * 0.25f;  // kukunin nya yung 25% ng total range ng vision kada eye.
                go.GetComponent<EnemyEyes>().eye_distance = Lower_Enemy_Eyes;
            }
        }
    }

    void ResetView()
    {
        EnemySense.radius = Temp_enemy_Radius;
        if (EyeSight.Length > 0 && Eyesight_lowered)
        {
            Eyesight_lowered = false;
            foreach (GameObject go in EyeSight)
            {
                go.GetComponent<EnemyEyes>().eye_distance = Temp_Enemy_Eyes; // Ibabalik nya yung  total range ng vision kada eye.

            }
        }
    }

	void AnimationCotrollers(string Anim)
	{
		switch (Anim) 
		{
		case "Idle":
			anim.SetBool ("Idle", true); 
			anim.SetBool ("Running", false); 
			anim.SetBool ("Walking", false); 
			anim.SetBool ("Attacking", false); 
			break;
		case "Walking":
			anim.SetBool ("Idle", false); 
			anim.SetBool ("Running", false); 
			anim.SetBool ("Walking", true); 
			anim.SetBool ("Attacking", false); 
			break;
		case "Running":
			anim.SetBool ("Idle", false); 
			anim.SetBool ("Running", true); 
			anim.SetBool ("Walking", false); 
			anim.SetBool ("Attacking", false); 
			break;
		case "Attacking":
			anim.SetBool ("Idle", false); 
			anim.SetBool ("Running", false); 
			anim.SetBool ("Walking", false); 
			anim.SetBool ("Attacking", true); 
			break;
		default:
			break;
		}
	}

	void AttackState()
	{
		AnimationCotrollers("Attacking"); 

	}



}
