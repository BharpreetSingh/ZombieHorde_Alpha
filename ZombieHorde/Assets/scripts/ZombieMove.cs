using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieMove : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent Nav;

    private void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Nav.SetDestination(player.transform.position); // tells unity's nav mesh agent to move the zombie to the players position 
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.CompareTag(("Player")))
        {
            player.GetComponentInChildren<PlayerCombat>().HP--;
            Debug.Log("hit player");
        }
    }
}
