using UnityEngine;
using VContainer;
using VContainer.Unity;

public partial class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private SpawnPoints _spawnPoints;

    private IContainerBuilder _builder;

    protected override void Configure(IContainerBuilder builder)
    {
        _builder = builder;
        builder.RegisterComponent(_spawnPoints);
    }

    private void Start()
    {
        _builder.RegisterComponent(_spawnPoints);
    }
}