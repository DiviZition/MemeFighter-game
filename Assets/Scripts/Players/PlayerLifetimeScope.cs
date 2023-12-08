using VContainer;
using VContainer.Unity;

public class PlayerLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(this.gameObject.GetComponent<PlayerComponents>());
    }
}
