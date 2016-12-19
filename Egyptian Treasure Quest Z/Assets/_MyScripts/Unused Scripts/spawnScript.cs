using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour
{

    public Transform spawnPoint;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localPosition = spawnPoint.localPosition;
    }
}
