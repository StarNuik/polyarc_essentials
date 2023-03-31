using UnityEngine;

#if ZENJECT_PRESENT
using Zenject;
#endif

namespace PolygonArcana.Essentials
{
	public abstract class AView : MonoBehaviour
	{
		//
	}

	#if ZENJECT_PRESENT
	public abstract class AView<TModel> : AView
		where TModel : AModel
	{
		[Inject]
		protected TModel model { get; private set; }
	}

	public abstract class AView<TModel, TSettings> : AView<TModel>
		where TModel : AModel
		where TSettings : ASettings
	{
		[Inject]
		protected TSettings settings { get; private set; }
	}
	#endif
}