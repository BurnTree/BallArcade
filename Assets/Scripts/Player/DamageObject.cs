using Constants;
using UnityEngine;
using Random = System.Random;

public abstract class DamageObject : MonoBehaviour
{
    public float score = 100;
    
    private void Awake()
    {
        Resize();
    }
    protected void CheckDamage(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.Player) || other.gameObject.CompareTag(Tags.Enemy))
        {
            DamageObject otherDO = other.gameObject.GetComponent<DamageObject>();
            if (this.score > otherDO.score)
            {
                this.score += otherDO.score / 10;
                Resize();
            }
            else if(this.score < otherDO.score)
                Destroy(this.gameObject);
        }
    }


    protected void CheckDeadZone(Collider other)
    {
        Debug.Log($"Collider stay {other.gameObject.tag}");
        if (other.CompareTag(Tags.DeadZone))
        {
            Debug.Log("Collider stay with DeadZone");
            this.score -= 0.9f * score * Time.deltaTime;
            Resize();
        }
    }

    protected void Resize()
    {
        this.transform.localScale = Vector3.one * score / 100;
    }
}
