using System;
using Constants;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : DamageObject
{
    public float speed = 200;
    public float reactionRadius = 2;
    
    public SphereCollider reactionZone;
    void Start()
    {
        _rb.AddForce(new Vector3(Random.Range(-1, 1) * speed,
            Random.Range(-1, 1) * speed,
            Random.Range(-1, 1) * speed));
        reactionZone.radius = reactionRadius;
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
            Vector3 dir = Vector3.zero;
            if (this.score > fighter.score + scoreRange)
                dir = fighter.transform.position - this.transform.position;
            else if (this.score < fighter.score - scoreRange)
                dir = this.transform.position - fighter.transform.position;
            
            AddFixedForce(dir.normalized * Time.deltaTime);
        }
    }

    private void AddFixedForce(Vector3 dir)
    {
        _rb.AddForce(dir * speed);
    }
}