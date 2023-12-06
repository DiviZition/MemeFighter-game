using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public partial class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private PlayerComponents _playerPrefab;
    [SerializeField] private SpawnPoints _spawnPoints;

    private Transform _playersParent;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(builder);

        //������� ����� ������ �������. � ��� ������� ������� ����������� �� � ����������.
        //��������� � ����������

        builder.RegisterComponentInNewPrefab<PlayerComponents>(_playerPrefab, Lifetime.Scoped);
    }

    public void Start()
    {
        _playersParent = new GameObject("Players").transform;

        var player = Container.Resolve<PlayerComponents>();

        player.Transform.position = _spawnPoints.GetNextSpawnPoint(0);
        player.Transform.parent = _playersParent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}