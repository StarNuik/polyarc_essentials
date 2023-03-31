#if ZENJECT_PRESENT
using Zenject;

namespace PolygonArcana.Essentials
{
	public abstract class AMonoInstaller : MonoInstaller
	{
		public override abstract void InstallBindings();

		protected void SingleNew<T>() => Container
			.Bind<T>()
			.ToSelf()
			.FromNew()
			.AsSingle();
		
		protected void SingleHierarchy<T>() => Container
			.Bind<T>()
			.ToSelf()
			.FromComponentInHierarchy()
			.AsSingle();
	}
}
#endif