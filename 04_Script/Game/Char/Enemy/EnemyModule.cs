using UnityEngine;

public enum EnemyType
{
	None,
	HeavyArmor,
	LightArmor,
	Archer
}

[CreateAssetMenu]
public class EnemyModule : ScriptableObject
{
	public EnemyType e_type;
	public int MaxHp;
	public int Attackdamge;
	public float AttackRange;
	public float AttackDelay;
	public float Move_Speed;
	public string Weapon;
}