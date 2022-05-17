using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScoll : MonoBehaviour
{
	[SerializeField]
	Transform[] backgrounds = null;
	[SerializeField]
	float b_speed = 0f;

	private float b_leftPosX = 0f;
	private float b_rightPosX = 0f;
    
	// Start is called before the first frame update
    void Start()
    {
        float s_length = backgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		b_leftPosX = -s_length * backgrounds.Length / 2;
		b_rightPosX = (s_length) * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < backgrounds.Length; i++)
		{
			backgrounds[i].position += new Vector3(-b_speed, 0, 0) * Time.deltaTime;

			if (backgrounds[i].position.x < b_leftPosX)
			{
				Vector3 b_selfPos = backgrounds[i].position;
				b_selfPos.Set(b_rightPosX + b_selfPos.x, b_selfPos.y, b_selfPos.z);
				backgrounds[i].position = b_selfPos;
			}
		}
    }
}
