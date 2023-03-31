using UnityEngine;

#if ZENJECT_PRESENT
using Zenject;
#endif

namespace PolygonArcana.Essentials
{
	public abstract class AWidget : MonoBehaviour
	{
		//
	}

	#if ZENJECT_PRESENT
	public abstract class AWidget<TModel> : AWidget
		where TModel : AModel
	{
		[Inject]
		protected TModel model { get; private set; }
	}

	public abstract class AWidget<TModel, TSettings> : AWidget<TModel>
		where TModel : AModel
		where TSettings : ASettings
	{
		[Inject]
		protected TSettings settings { get; private set; }
	}
	#endif
}