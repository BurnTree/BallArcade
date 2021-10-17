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
        if (target)
        {
            mob.score = target.score + Random.Range(-40, 40);
            if (mob.score <= 10)
                mob.score = 10;
        }

        createdObject = Instantiate(mob, this.transform.position, Quaternion.identity);
        status = StatusEnum.Waiting;
        spendTime = delay;
    }
}