using Constants;
using UnityEngine;

public class DependedSpawner : Spawner
{
    private DamageObject target;

    void Update()
    {
        FindPlayer();
        CalculateObjectCreation();
    }

    void FindPlayer()
    {
        if (!target)
        {
            GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
            if (player)
            {
                target = player.GetComponent<DamageObject>();
            }
        }
    }

    public override void CreateMob()
    {
        createdObject = Instantiate(mob, this.transform.position, Quaternion.identity);
        
        if (target)
        {
            createdObject.score = target.score + Random.Range(-30, 10);
            if (createdObject.score <= 50)
                createdObject.score = 50;
        } else if (checkRandomInit)
        {
            createdObject.score += Random.Range(-50, 100);
        }
        createdObject.Recalculate();

        status = StatusEnum.Waiting;
        spendTime = delay;
    }
}