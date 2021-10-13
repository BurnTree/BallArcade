using System;
using Constants;
using UnityEngine;
using Random = System.Random;

public class Enemy : DamageObject
{
    public float speed = 200;
    public float reactionRadius = 2;
    
    public Rigidbody rb;
    public SphereCollider reactionZone;
    
    private const float MaxSpeed = 0.1f;
    void Start()
    {
        Random random = new Random();
        rb.AddForce(new Vector3(GetRandomDouble(random) * speed,
            GetRandomDouble(random) * speed,
            GetRandomDouble(random) * speed));
        score += random.Next(-20, 20);
        Debug.Log(score);
        reactionZone.radius = reactionRadius;
    }

    float GetRandomDouble(Random random)
    {
        return (float) random.NextDouble() * 2 - 1;
    }

    private void OnCollisionEnter(Collision other)
    {
        CheckDamage(other);
        WallBounce(other);
    }

    private void WallBounce(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.Wall))
        {
            Vector3 dir = this.transform.position - other.contacts[0].point;
            AddFixedForce(dir.normalized);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        EnemyReaction(other);
    }

    private void EnemyReaction(Collider other)
    {
        if (other.CompareTag(Tags.Enemy) || other.CompareTag(Tags.Player))
        {
            DamageObject fighter = other.GetComponent<DamageObject>();
            Vector3 dir;
            if (this.score > fighter.score)
            {
                dir = fighter.transform.position - this.transform.position;
            }
            else
            {
                dir = this.transform.position - fighter.transform.position;
            }
            AddFixedForce(dir.normalized * Time.deltaTime);
        }
    }

    private void AddFixedForce(Vector3 dir)
    {
        rb.AddForce(dir * speed);
    }
}