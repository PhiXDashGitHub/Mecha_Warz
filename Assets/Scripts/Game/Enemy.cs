using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform objectToRotate;
    public GameObject laserObject;
    public GameObject deathParticles;
    public NavMeshAgent agent;

    public enum EnemyType { Walking, Stationary, Boss }
    public EnemyType type;

    public int Maxhealth;
    int health;

    public float range;
    public float shootTime;
    public float angularSpeed;
    public int magicForPlayer;

    Transform player;

    bool shooting;

    public void Start()
    {
        shooting = false;
        health = Maxhealth;

        StartCoroutine(ActivateAI());
    }

    IEnumerator ActivateAI()
    {
        new WaitForSeconds(0.1f);
        if (agent != null)
        {
            agent.enabled = true;
        }
        yield return null;
    }

    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>().transform;
            return;
        }

        //Check Enemy Type
        if (type == EnemyType.Stationary)
        {
            //If Player is in Range
            if (Vector3.Distance(transform.position, player.position) < range)
            {
                //Rotate towards Player
                Quaternion rot = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
                rot.x = 0;
                rot.z = 0;
                objectToRotate.transform.localRotation = Quaternion.Slerp(objectToRotate.transform.localRotation, rot, angularSpeed * Time.deltaTime);

                //Shoot
                if (!shooting)
                {
                    shooting = true;
                    StartCoroutine(Shoot());
                }
            }
            else
            {
                //Idle Animation
                shooting = false;
            }
        }
        else if (type == EnemyType.Walking)
        {
            //If Player is in Range
            if (Vector3.Distance(transform.position, player.position) < range)
            {
                //Walk towards Player
                agent.SetDestination(player.position);

                //Shoot
                if (!shooting)
                {
                    shooting = true;
                    StartCoroutine(Shoot());
                }
            }
            else
            {
                //Idle Animation
                agent.SetDestination(transform.position);
                shooting = false;
            }
        }
        else if (type == EnemyType.Boss)
        {
            //If Player is in Range
            if (Vector3.Distance(transform.position, player.position) < range)
            {
                //Walk towards Player
                agent.SetDestination(player.position);

                //Shoot
                if (!shooting)
                {
                    shooting = true;
                    StartCoroutine(Shoot());
                }
            }
            else
            {
                //Idle Animation
                agent.SetDestination(transform.position);
                shooting = false;
            }
        }
    }

    IEnumerator Shoot()
    {
        GameObject laser = Instantiate(laserObject, null);
        laser.transform.position = transform.position;
        laser.transform.localEulerAngles = objectToRotate.localEulerAngles;
        Destroy(laser, 5);
        yield return new WaitForSeconds(shootTime);
        StartCoroutine(Shoot());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Weapon") && other.GetComponent<Weapon>())
        {
            Takedamage(other.GetComponent<Weapon>().Damage);
            Destroy(other.gameObject);
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<Weapon>())
        {
            Takedamage(other.GetComponent<Weapon>().Damage);
        }
    }

    public void Takedamage(int pdamage)
    {
        health -= pdamage;
        health = Mathf.Clamp(health,0,Maxhealth);

        if (health == 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        player.GetComponent<PlayerStats>().AddMagic(magicForPlayer);
        GameObject newParticles = Instantiate(deathParticles, null);
        newParticles.transform.position = transform.position;
        Destroy(newParticles, 3);
        Destroy(gameObject);
    }
}
