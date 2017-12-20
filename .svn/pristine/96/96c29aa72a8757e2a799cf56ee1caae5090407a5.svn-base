using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunScripts : MonoBehaviour {

	//cycleing from the ShootOnClick Script
	public ShootOnClick.modes mode;
	public Text madeText;

	public float shootRate = 0.25f;
	public float lastShootTime = 0f;

	public GameObject projectile;
	public float force;
	public Transform projectileDirection;



	public void ChangeMode()
	{
		if (mode == ShootOnClick.modes.ray)
		{
			mode = ShootOnClick.modes.projectile;
			madeText.text = "Mode: Projectile";
		}
		else 
		{
			mode = ShootOnClick.modes.ray;
			madeText.text = "Mode: Ray";
		}
	}

	//set correct text on Awake
	void Awake()
	{
		if (mode == ShootOnClick.modes.ray)
		{
			madeText.text = "Mode: Ray";
		}
		else 
		{
			madeText.text = "Mode: Projectile";
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (Time.time - lastShootTime  >= shootRate)
		{

			//if ray mode
			if (mode == ShootOnClick.modes.ray)
			{
				Ray ray = new Ray(transform.position,transform.forward);
				RaycastHit RCH;

				if (Physics.Raycast (ray,out RCH, 100)) 
				{
					EnergyShieldManager ESM = RCH.collider.gameObject.GetComponent<EnergyShieldManager>();

					//if the collider has an EnergyShieldManager.cs on it.
					if (ESM != null)
					{
						ESM.Hit(RCH.point); //hit the shield
					}
				}
			}
			else //if projectile mode
			{
					

				GameObject p =  Instantiate(projectile,transform.position,transform.rotation) as GameObject;
				p.GetComponent<Rigidbody>().AddForce(projectileDirection.forward * force );
			}

			lastShootTime = Time.time;
		}
	}
}
