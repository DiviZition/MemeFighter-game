using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Player[] _players;

    void Start()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            Instantiate(_players[i].PlayerPrefab, _players[i].SpawnPoint);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

[Serializable]
public struct Player
{
    public GameObject PlayerPrefab;
    public Transform SpawnPoint;
}