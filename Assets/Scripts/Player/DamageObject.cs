using System;
using Constants;
using UnityEngine;
using Random = System.Random;

public abstract class DamageObject : MonoBehaviour
{
    public float initialScore = 100;
    public float score;
    public float scoreRange = 20;
    protected Rigidbody _rb;

    private void Awake()
    {
        score = initialScore;
        _rb = GetComponent<Rigidbody>();
        Recalculate();
    }

    protected void CheckDamage(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.Player) || other.gameObject.CompareTag(Tags.Enemy))
        {
            DamageObject otherDO = other.gameObject.GetComponent<DamageObject>();
            if (this.score > otherDO.score + scoreRange)
            {
                this.score += otherDO.score / 10;
                Recalculate();
            }
            else if (this.score < otherDO.score - scoreRange)
                Destroy(this.gameObject);
        }
    }


    protected void CheckDeadZone(Collider other)
    {
        if (other.CompareTag(Tags.DeadZone) && score >= 20)
        {
            this.score -= 0.1f * score * Time.deltaTime;
            Recalculate();
        }
    }

    protected void Recalculate()
    {
        this.transform.localScale = Vector3.one * score / 100;
        _rb.mass = score / 100;
    }
}