using System;
using System.Collections;
using System.Collections.Generic;
using Client;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EnemyLineCollisionView : MonoBehaviour
{
    private EntityObject _entityObject;

    private void Start()
    {
        _entityObject = GetComponent<EntityObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            _entityObject.GetEntity().Get<EnemyMoveComponent>().MoveSpeed *= -1;
        }
    }
}
