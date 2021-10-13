using Constants;
using UnityEngine;
using Random = System.Random;

public abstract class DamageObject : MonoBehaviour
{
    public int score = 100;
    
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

    protected void CheckDeadZone(Collision other)
    {
        Debug.Log($"Collider stay {other.gameObject.tag}");
        if (other.gameObject.CompareTag(Tags.DeadZone))
        {
            Debug.Log("Collider stay with DeadZone");
            score -= (int) (0.9 * score * Time.deltaTime);
        }
    }

    protected void Resize()
    {
        this.transform.localScale = Vector3.one * score / 100;
    }
}
