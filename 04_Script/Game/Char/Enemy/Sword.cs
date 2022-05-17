using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	public float RemainTime;
	int Atkdamge;
	Rigidbody2D myRigi;

#region Unity Functions
	private void Start()
	{
		Atkdamge = gameObject.GetComponentInParent<EnemyAttack>().Atkdamge;
		myRigi = GetComponent<Rigidbody2D>();
		myRigi.mass = Atkdamge;
	}

    // Update is called once per frame
    void Update()
    {
        if (RemainTime >= 0)
			RemainTime -= Time.deltaTime;
		else
		{
			Destroy(gameObject);
		}
    }

#endregion

#region Public Functions
	public void Blocked()
	{
		Destroy(gameObject);
	}
#endregion
}
