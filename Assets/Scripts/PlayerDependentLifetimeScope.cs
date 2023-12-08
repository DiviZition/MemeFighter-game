using VContainer;
using VContainer.Unity;

public class PlayerDependentLifetimeScope : LifetimeScope
{
    private PlayerComponents _components;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_components);
    }

    public void RegisterAndInjectPlayer(PlayerComponents components)
    {
        _components = components;

        Build();
    }
}
