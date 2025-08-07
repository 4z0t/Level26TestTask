using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _scoreScreen;

    private int _totalEnemies;
    private int _leftEnemies;
    private List<Enemy> _enemies;

    private void Start()
    {
        _enemies = new List<Enemy>();
        _leftEnemies = 0;
        _totalEnemies = 0;
        foreach(Enemy enemy in FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
        {
            _totalEnemies++;
            _leftEnemies++;
            _enemies.Add(enemy);
            enemy.GetComponent<Health>().OnDeath += OnEnemyDead;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisplayScoreScreen()
    {
        _scoreScreen.SetActive(true);
    }

    private void OnAllEnemiesDead()
    {
        Invoke(nameof(DisplayScoreScreen), 3);
    }

    private void OnEnemyDead(object sender, Health health)
    {
        var enemy = health.GetComponent<Enemy>();
        int index = _enemies.IndexOf(enemy);
        if (index == -1)
            return;

        Debug.Log("Enemy died");
        health.OnDeath -= OnEnemyDead;
        _enemies.RemoveAt(index);
        _leftEnemies--;

        if(_leftEnemies == 0)
        {
            OnAllEnemiesDead();
        }
    }
}
