using UnityEngine;

[CreateAssetMenu]
public class R_EnemyState : ScriptableObject
{
    public EnemyType e_type;
	public int MaxHp;
	public int CurrentHp;
	public int Attackdamge;
	public float SightRange;
	public float AttackRange;
	public float AttackDelay;
	public float Move_Speed;
	public string Weapon;
}
