using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(("Player")))
        {
            player.GetComponentInChildren<PlayerCombat>().ammo+=5;
            Destroy(this.gameObject,0.5f);
        }
    }
}
