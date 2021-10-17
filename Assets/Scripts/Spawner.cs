using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public DamageObject mob;
    public float delay = 5;
    public bool checkRandomInit = true;
    protected Object createdObject { get; set; }
    protected StatusEnum status { get; set; }
    protected float spendTime { get; set; }

    void Start()
    {
        CreateMob();
    }

    void Update()
    {
        CalculateObjectCreation();
    }

    protected void CalculateObjectCreation()
    {
        if (createdObject == null && status == StatusEnum.Waiting)
            status = StatusEnum.CreatingObject;

        if (status == StatusEnum.CreatingObject)
            spendTime -= Time.deltaTime;

        if (spendTime <= 0)
            CreateMob();
    }

    public virtual void CreateMob()
    {
        if (checkRandomInit)
            mob.score += Random.Range(-20, 20);
        createdObject = Instantiate(mob, this.transform.position, Quaternion.identity);
        status = StatusEnum.Waiting;
        spendTime = delay;
    }

    protected enum StatusEnum
    {
        CreatingObject,
        Waiting
    }
}