#if ZENJECT_PRESENT
using Zenject;
#endif

namespace PolygonArcana.Essentials
{
	public abstract class AService
	{
		//
	}

	#if ZENJECT_PRESENT
	public abstract class AService<TModel> : AService
		where TModel : AModel
	{
		[Inject]
		protected TModel model { get; private set; }
	}

	public abstract class AService<TModel, TSettings> : AService<TModel>
		where TModel : AModel
		where TSettings : ASettings
	{
		[Inject]
		protected TSettings settings { get; private set; }
	}
	#endif
}