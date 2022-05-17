using UnityEngine.UI;
using UnityEngine;

public class Hpbar : MonoBehaviour
{
	public static Hpbar Instance;

	[SerializeField]
	PlayerCombat player;
	[SerializeField]
	private Slider slider;
	[SerializeField]
	private Slider mpslider;

#region Unity Functions
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
#endregion

#region Public Functions
	public void signHpbar()
	{
		slider.value = ((float)player.CurrentHp / player.MaxHp);
	}

	public void signMpbar()
	{
		mpslider.value = ((float)player.CurrentMp / player.MaxMp);
	}
#endregion
}
