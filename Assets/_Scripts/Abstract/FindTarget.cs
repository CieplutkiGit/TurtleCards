using UnityEngine;
using System.Collections.Generic;

public abstract class FindTarget : MonoBehaviour
{
    public static (Transform target,bool hasTarget)  GetTarget (Transform transform,bool isPlayer,float attackRange)
    {
        Collider[] objectsInRange =
            Physics.OverlapSphere(transform.position, attackRange);

        if(objectsInRange==null)
            return (null, false);

        List<Transform> targets = new();
        foreach (var item in objectsInRange)
        {
            if(item.GetComponent<UnitBase>())
            {
                if (isPlayer&&!item.GetComponent<UnitBase>().isPlayer)
                  targets.Add(item.transform);
                else if(!isPlayer&&item.GetComponent<UnitBase>().isPlayer)
                    targets.Add(item.transform);
            }

            if (item.GetComponent<BuildingBase>())
            { 
                if (isPlayer&&!item.GetComponent<BuildingBase>().isPlayer)
                  targets.Add(item.transform);
                else if(!isPlayer&&item.GetComponent<BuildingBase>().isPlayer)
                    targets.Add(item.transform);
            }
        }

        if (targets.Count ==0)
            return (null, false);

        var target = FindClosestEnemy(targets,transform).target;
        return (target, true);
    }

    public static (Transform target, bool found)
    FindClosestEnemy(List<Transform> targets, Transform transform)
    {
        Transform closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (Transform target in targets)
        {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = target;
                distance = curDistance;
            }
        }
        return (closest, true);
    }
}
