using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy"))
        {
            Debug.Log("Игрок столкнулся!");
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Игрок столкнулся!");
            SceneManager.LoadScene("MainScene");
        }
    }
}