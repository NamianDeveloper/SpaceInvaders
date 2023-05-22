using System.Collections;
using System.Collections.Generic;
using Client;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;
using Voody.UniLeo;

public class EnemyCollisionView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            EcsEntity entity = GetComponent<EntityObject>().GetEntity();
            Destroy(entity.Get<EnemyHealthComponent>().GameObject);
            
            EcsEntity bulletnEtity = other.GetComponent<EntityObject>().GetEntity();
            Destroy(bulletnEtity.Get<BulletComponent>().Transform.gameObject);

            ref UIComponent scoreComponent = ref WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<UIComponent>)).GetEntity(0).Get<UIComponent>();

            scoreComponent.CurrentScore += 10;
            scoreComponent.ScoreText.text = scoreComponent.CurrentScore.ToString();
            
            entity.Destroy();
        }

        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}