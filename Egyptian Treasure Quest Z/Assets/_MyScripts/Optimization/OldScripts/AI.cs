using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    public float playerDistance;
    public float enemyMovementSpeed;
    public float rotationDamping;
    Transform player;
    public float damage;
    public GameObject tempGM;

    void Start()
    {
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance < 15f)
        {
            lookAtPlayer();
        }
        if (playerDistance < 12f)
        {
            if (playerDistance > 1f)
            {
                chase();
            }
            else if (playerDistance < 1f)
            {
                attack();
            }
        }
    }
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        rotation.y = 0;
    }
    void chase()
    {
        this.transform.Translate(Vector3.forward * enemyMovementSpeed * Time.deltaTime);
    }
    void attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                tempGM.GetComponent<GameManager>().playerLife -= 1;
            }
        }
    }



}
