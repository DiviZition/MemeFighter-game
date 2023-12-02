using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class StartGame : MonoInstaller
{
    [SerializeField] private PlayerComponents _playerPrefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        Container.Bind<PlayerComponents>()
            .FromComponentInNewPrefab(_playerPrefab)
            .AsSingle()
            .NonLazy();
    }

    public override void Start()
    {
        PlayerComponents player = Container.Resolve<PlayerComponents>();
        player.Transform.position = _spawnPoint.position;
        player.Transform.parent = _spawnPoint;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}