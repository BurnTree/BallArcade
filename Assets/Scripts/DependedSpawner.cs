using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;
using Random = System.Random;

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
            Random random = new Random();
            mob.score = target.score - 20;
        }
        createdObject = Instantiate(mob, this.transform.position, Quaternion.identity);
        status = StatusEnum.Waiting;
        spendTime = delay;
    }
}
