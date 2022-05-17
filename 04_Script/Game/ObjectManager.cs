using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectManager : MonoBehaviour
{
	public static ObjectManager Instance;

	[SerializeField]
	private List<Enemy> enemies;
	[SerializeField]
	bool usingPool;
	[SerializeField]
	Transform[] spwanPoints;
	private List<ObjectPool<Enemy>> mutipool;
	private int spawnAmount = 3;

	public float spawntimer = 10f;
	private float timer = 0f;

#region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
		mutipool = new List<ObjectPool<Enemy>>();
		for (int i = 0; i < enemies.Count; i++)
		{
			int localindex = i;
			ObjectPool<Enemy> singlepool = new ObjectPool<Enemy>(
				() => { return Instantiate(enemies[localindex]);},
				MyObject => { MyObject.gameObject.SetActive(true);},
				MyObject => { MyObject.gameObject.SetActive(false);},
				MyObject => { Destroy(MyObject.gameObject);},
				true, 5, 20);

			mutipool.Add(singlepool);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (spawntimer < timer)
		{
			SpawnObject(Random.Range(0, enemies.Count));
			timer = 0f;
		}
		else
		{
			timer += Time.deltaTime;
		}
    }
#endregion

#region Public Functions
	public void SpawnObject(int index)
	{
		for (int i = 0; i < spawnAmount; i++)
		{
			var MyObject = usingPool ? mutipool[index].Get() : Instantiate(enemies[index]);

			// 생성 위치 정해주는 곳.
			// 어떤 오브젝트에 다았을때 KillObject 사용 By Action - 보류;
			MyObject.gameObject.transform.position = spwanPoints[i % 2].position;
		}
	}

	public void KillObject(Enemy MyObject)
	{
		if (usingPool)
		{
			for (int i = 0; i < enemies.Count; i++)
			{
				if (MyObject == enemies[i])
					mutipool[i].Release(MyObject);
			}
		}
		else
		{
			Destroy(MyObject.gameObject);
		}
	}
#endregion
}
