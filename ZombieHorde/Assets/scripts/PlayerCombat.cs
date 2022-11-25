using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCombat : MonoBehaviour
{
    public int ammo;
    public int HP;

    RaycastHit hit;
    public Transform CurrentObject;
    public Transform Gun;
    public GameObject Bullet, GameOver, YouWin;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI hpText;

    public AudioSource gunAudio;

    public int kills;
    void Update()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 30f))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);

            CurrentObject = hit.transform;
          //  Debug.Log(hit.transform);
        }

        if (Input.GetMouseButtonDown(0) && ammo >0)
        {
            if (hit.transform.tag == "enemy")
            {
                ShotEnemy();
            }
                Shot();
        }

        ammoText.text = ammo.ToString();
        hpText.text = HP.ToString();

        if (HP <= 0)
        {
            GameOver.SetActive(true);
        }
        if (kills >= 15)
        {
            YouWin.SetActive(true);
        }
    }

    public void Shot()
    {
        ammo--;
        gunAudio.Play();
        Instantiate(Bullet);
    }   
    public void ShotEnemy()
    {
        Destroy(CurrentObject.gameObject, 0.2f);
        kills++;
    }
}
