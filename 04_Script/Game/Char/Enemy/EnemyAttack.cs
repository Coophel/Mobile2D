using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField]
	public bool isthrow;
	[SerializeField]
	Transform AtackPoint;

	[SerializeField]
	Enemy enemy;

	[SerializeField]
	GameObject arrowPre;
	[SerializeField]
	GameObject SwordPre;

	public int Atkdamge;
	public float moveSpeed;

#region Unity Functions
	private void Start()
	{
		this.Atkdamge = enemy.Atkdamge;
	}
#endregion

#region Public Functions
	public void attacking(string rangetype)
	{
		switch (rangetype)
		{
			case "Sword" :
				Instantiate(SwordPre, AtackPoint.position, Quaternion.identity, AtackPoint);
				break ;
			case "Bow" :
				Instantiate(arrowPre, AtackPoint.position, Quaternion.identity, AtackPoint);
				break ;
			case "Spear" :
				break ;
			default :
				Debug.Log("Nothing in");
				break ;
		}
	}

	public void Blocked()
	{
		Destroy(gameObject);
	}
#endregion
}
