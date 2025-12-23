using System;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer
{
    private class EntityRegistration
    {
        public Entity Entity;
        public Func<bool> Condition;
    }

    private List<EntityRegistration> _entity = new List<EntityRegistration>();

    public int CurrentCount => _entity.Count;

    public void Update()
    {
        if (_entity.Count >= 0)
            Debug.Log($"Врагов в системе: {_entity.Count}");

        for (int i = _entity.Count - 1; i >= 0; i--)
        {
            if (_entity[i].Condition.Invoke())
            {
                _entity[i].Entity.DestroySelf();
                _entity.RemoveAt(i);
            }
        }
    }

    public void RegisterEnemy(Entity enemy, Func<bool> deathCondition)
    {
        _entity.Add(new EntityRegistration
        {
            Entity = enemy,
            Condition = deathCondition
        });
    }
}
