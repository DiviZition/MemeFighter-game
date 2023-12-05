using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class StartGame : MonoInstaller
{
    [SerializeField] private PlayerComponents _playerPrefab;
    [SerializeField] private SpawnPoints _spawnPoints;

    private Transform _playersParent;

    public override void InstallBindings()
    {
        Container.Bind<DiContainer>()
            .FromInstance(Container)
            .AsSingle()
            .NonLazy();

        //Создаем класс плэйер спавнер. В нем спавним игроков приклеиваем их к контейнеру.
        //Контейнер в контейнере
        Container.Bind<PlayerComponents>() 
            .FromComponentInNewPrefab(_playerPrefab)
            .AsSingle()
            .NonLazy();
    }

    public override void Start()
    {
        _playersParent = new GameObject("Players").transform;

        PlayerComponents player = Container.Resolve<PlayerComponents>();
        player.Transform.position = _spawnPoints.GetNextSpawnPoint(0);
        player.Transform.parent = _playersParent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}