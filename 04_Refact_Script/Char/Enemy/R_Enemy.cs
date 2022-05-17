using UnityEngine;

public class R_Enemy : MonoBehaviour
{
	[SerializeField]
	GameObject Coin;

	// GameObject Player;

	[SerializeField]
	R_EnemyState e_style;
	R_enemystates e_States;

	CharControll e_Controll;
	Animator animator;

	float e_Distance;
	float e_Horzion;
	float e_CurrentDelay;

#region Unity Functions
	private void Awake()
	{
		e_States = new R_enemystates(e_style);
	}

	private void Start()
	{
		// Player = GameObject.FindGameObjectWithTag("Player");
		e_CurrentDelay = e_States.AttackDelay;
	}
#endregion
}

public class R_enemystates
{
	public R_EnemyState e_state;
	public EnemyType e_type;
	public int MaxHp;
	public int CurrentHp;
	public int Attackdamge;
	public float SightRange;
	public float AttackRange;
	public float AttackDelay;
	public float Move_Speed;
	public string Weapon;

	public R_enemystates(R_EnemyState state)
	{
		this.e_type = state.e_type;
		this.MaxHp = state.MaxHp;
		this.CurrentHp = state.CurrentHp;
		this.Attackdamge = state.Attackdamge;
		this.SightRange = state.SightRange;
		this.AttackRange = state.AttackRange;
		this.AttackDelay = state.AttackDelay;
		this.Move_Speed = state.Move_Speed;
		this.Weapon = state.Weapon;
	}
}