using UnityEngine;
using System.Collections;

public class EnemyEyes : MonoBehaviour
{
    #region Variables
    RaycastHit Hit;
    Vector3 frd_ray;
    public float eye_distance;
    public EnemyAI E_AIScript;
     
    #endregion
    // Use this for initialization
    void Start()
    {
        frd_ray = transform.TransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, frd_ray.normalized * eye_distance, Color.blue);
        Search_Target();
    }

    void Search_Target()
    {
        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 500), Color.red);
        frd_ray = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, frd_ray.normalized, out Hit, eye_distance))
        {
            //Debug.Log(Hit.transform.gameObject.name);
            if (Hit.transform.gameObject.tag == "Player")
            {
              //  Debug.Log("hit me");
                if (E_AIScript.Enemy_IdleTypes == EnemyAI._IdleType.Searching)
                {
                    E_AIScript.Enemy_States = EnemyAI._enemyStates.Chase;
                }
            }
        }
    }
}
