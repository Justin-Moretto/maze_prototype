using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	
	public float counter = 0f;
	public float x = 0f;
	public float y = 0f;
	public float z = 1f;
	public float leRetour = 5f;

	//public GameObject Player;

    void Start()
	{
		//Debug.Log("Counter has started."); //Uncomment for logs
	}

    void FixedUpdate()
    {
        counter += Time.deltaTime;
        float limit = leRetour * 2f;
        if (counter > 0)
        {
            //Debug.Log("Counter has passed 0"); //Uncomment for logs and erase logs at void Start
            //transform.position += new Vector3(x, y, z) * Time.deltaTime;
            transform.Translate(new Vector3(x, y, z) * Time.deltaTime);
        }

        if (counter > leRetour)
        {
            //Debug.Log("Counter has passed 5"); //Uncomment for logs
            //transform.position -= new Vector3(2 * x, 2 * y, 2 * z) * Time.deltaTime;
            transform.Translate(new Vector3(2 * x, 2 * y, 2 * z) * Time.deltaTime * -1);


            if (counter > limit)
            {
                counter = 0;
            }
        }
    }
}