using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	
	public float counter = 0f;
	public float x = 0f;
	public float y = 0f;
	public float z = 1f;
	public float leretour = 5f;


	void Start()
	{
		//Debug.Log("Counter has started."); //Uncomment for logs
	}
	private void OnCollisionEnter(Collision collision)
    {
		collision.collider.transform.SetParent(transform);
		//Debug.Log(collision.collider.name) is great to get more infos
		Debug.Log(collision.collider.name);
	}

	void Update()
	{
		counter += Time.deltaTime;
		float limit = leretour * 2f;
		if (counter > 0)
		{
			//Debug.Log("Counter has passed 0"); //Uncomment for logs and erase logs at void Start
			transform.position += new Vector3(x, y, z) * Time.deltaTime;
		}

		if (counter > leretour)
		{
			//Debug.Log("Counter has passed 5"); //Uncomment for logs
			transform.position -= new Vector3(2*x, 2*y, 2*z) * Time.deltaTime;

			if (counter > limit)
			{
				counter = 0;
			}
		}
	}
}