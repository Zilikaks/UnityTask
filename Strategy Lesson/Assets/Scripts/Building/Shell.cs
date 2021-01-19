using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour 
{
	public Transform target;
	public int moveSpeed = 1;
    public int damage = 10;
	
	// Update is called once per frame
	void Update () {
		if(target != null)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position),5*Time.deltaTime);
            if (Vector3.Distance(target.position, transform.position) >= 1)
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            else
            {
                Attack();
                Destroy(gameObject);
            }

		}
		else
			Destroy(gameObject);
	}

    void Attack()
    {
        target.gameObject.GetComponent<Stats>().ReceivingDamage(damage);
    }
}
