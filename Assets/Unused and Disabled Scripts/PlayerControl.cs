//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class PlayerControl : MonoBehaviour
//{

//    public Slider hullBar;
//    public Slider shieldBar;
//    public Slider energyBar;
//    public Engine engine;
//    public Image engineStatus; //engine healthbar
//    public Shield Shields;
//    public Image shieldsStatus; //shields healthbar
//    public GameObject repairBots;
//    public Image repairBotsStatus; //repairbots healthbar
//    public Weapon weapon;
//    public Image weaponStatus; //weapons healthbar
//    public Reactor reactor;
//    public Image reactorStatus; //reactor healthbar
//    public Hull hull;
//    public Radar radar;
//    public Image radarStatus; //radar healthbar
//    public GenerateDebrisOnDestroy modelToDestroy;

//    public Transform projectileSpawner;

//    private float availablePower;

//    private GameObject projectileSpawn;
//    private ObjectPoolerWeapon pooler;
//    private Rigidbody rb;
//    private Transform tr;
//    private float nextFire = 0;
//    private float refireRate;
//    private Vector3 projectileSpeed;
//    private Vector3 shipSpeed;
//    private float nextBoost;

//    private GameObject bolt;
//    private GameObject obj;
//    private Rigidbody rbb;

//    void Start()
//    {
//        UpdateSubSystemBars();
//    }

//    void Update()
//    {

//        if (hull.CurrentHullPoints() <= 0)
//        {
//            DestroyShip();
//        }


//        float y = Input.GetAxis("RightH");

//        rb = GetComponent<Rigidbody>();
//        tr = GetComponent<Transform>();

//        transform.Rotate(0, (y * rotSpeed), 0);

//        shipSpeed = rb.velocity;

//        if (Input.GetAxis("HorizontalJ") > 0)
//        {
//            rb.AddForce(transform.right * speed);
//        }
//        if (Input.GetAxis("HorizontalJ") < 0)
//        {
//            rb.AddForce((transform.right * -1) * speed);
//        }
//        if ((Input.GetAxis("VerticalJ") > 0))
//        {
//            rb.AddForce((transform.forward * speed) * (Input.GetAxis("VerticalJ")));
//            projectileSpeed = (transform.forward * speed);
//        }
//        if ((Input.GetAxis("VerticalJ") < 0))
//        {
//            float reverseSpeed;
//            reverseSpeed = ((speed) * -1);
//            rb.AddForce(transform.forward * reverseSpeed);
//        }


//        /* tr.Translate(
//             new Vector3(
//             ((Input.GetAxis("HorizontalJ") / (speed / 2) )),
//             0f,
//             ((Input.GetAxis("VerticalJ") / (speed * 3)))
//             ));

//         rb.transform.Rotate(0, (y * rotSpeed), 0); */



//        nextFire += Time.deltaTime;
//        nextBoost += Time.deltaTime;

//        while ((Input.GetButton("LeftBumper")) && nextBoost >= engine.AbCoolDown())
//        {
//          //  Debug.Log("bumpered");
//            if (reactor.GetAvailablePower() > engine.AfterBurnerPowerDrain())
//            {
//                engine.EngageAfterburner(rb);
//                nextBoost = 0.0f;
//                Debug.Log("boost called");
//                reactor.ConsumePower(engine.AfterBurnerPowerDrain());
//                break;
//            }
//         //   Debug.Log("Out of Power");
//            break;
//        }

        
        
   
//       while ((Input.GetAxisRaw("PrimaryAttack") != 0))
//        {
//         //   Debug.Log("triggered");
//            weapon.RefireRate();
//       //     Debug.Log(reactor.GetAvailablePower());
//            if (nextFire >= weapon.RefireRate() && (reactor.GetAvailablePower() > weapon.EnergyCost()))
//            {
//        //    Debug.Log("should fire");
//                nextFire = 0.0f;
//                Fire();
                
//                reactor.ConsumePower(weapon.EnergyCost());
//                break;
//            }
//           break;
           
//        }

//        UpdateSubSystemBars();
//    }

//    void DamageSubsystem(float dmg)
//    {
//        float hullPercentage = hull.HullPercentage();

//        if (hullPercentage >= .75)
//        {
//            float randomSystem = Random.Range(0, 1);
//            if (randomSystem > .5)
//            {
//                weapon.ReduceHealth(dmg);
//            }
//            else
//            {
//                radar.ReduceHealth(dmg);
//            }
            
//        }
//        if (hullPercentage >= .50 && hullPercentage <= .75)
//        {
//            float randomSystem = Random.Range(0, 1);

//            if (randomSystem > .5)
//            {
//                engine.ReduceHealth(dmg);
//            }
//            else
//            {
//                Shields.ReduceHealth(dmg);
//            }
//        }
//        if (hullPercentage >= .25 && hullPercentage <= .50)
//        {
//            reactor.ReduceHealth(dmg);
//        }
//        if (hullPercentage >= .24)
//        {
//            //repair bots
//        }

//    } // called by projectiles striking the hull. Different subsystems can take damage at different hull levels. Will eventually expand to select a random system from all available at all levels. 
//    void DestroyShip()
//    {

//        modelToDestroy.DestroyStarship();
//        Destroy(gameObject);
//    } // called to destroy ship and generate explosion graphic

//    void Fire()
//    {
//       // Debug.Log("fired");
//       //  obj = weapon.GetPooledObject();
//        rbb = obj.GetComponent<Rigidbody>();
//        obj.transform.position = projectileSpawner.transform.position;
//        obj.transform.rotation = projectileSpawner.transform.rotation;
//        obj.SetActive(true);
//        rbb.AddForce((transform.forward * weapon.ProjectileForce()) + shipSpeed);
//    } // fires the primary weapoon

//    //void Fire()
//    //  {


//    //      Debug.Log("fire called");
//    //      // You Should make a variable for the ObjectPoolerWeapon.  GetComponent is decently slow and since you are calling this alot, you should in your Start() do the BS.GetComponent<ObjectPoolerWeapon>() call.
//    //      GameObject obj = weapon.GetPooledObject();
//    //      Rigidbody rb;
//    //      rb = obj.GetComponent<Rigidbody>();


//    //      obj.transform.position = projectileSpawn.position;
//    //      obj.transform.rotation = projectileSpawn.rotation;
//    //      obj.SetActive(true);
//    //      rb.AddForce((transform.forward * weapon.ProjectileForce()));
//    //  } // depreciated fire

//    void UpdateSubSystemBars()
//    {
//        hullBar.value = hull.HullPercentage();
//        shieldBar.value = Shields.ShieldPercent();
//        energyBar.value = reactor.EnergyPercent();
//        engineStatus.fillAmount = engine.HealthPercent();
//        shieldsStatus.fillAmount = Shields.HealthPercent();
//        weaponStatus.fillAmount = weapon.HealthPercent();
//        reactorStatus.fillAmount = reactor.HealthPercent();
//        radarStatus.fillAmount = radar.HealthPercent();
//        //repairBotsStatus.fillAmount = repairBots.HealthPercent(); not implimented yet

//    }

//    void FixedUpdate()
//    {
//        rb = GetComponent<Rigidbody>();
//        if (rb.velocity.magnitude > maxSpeed)
//        {
//            rb.velocity = rb.velocity.normalized * maxSpeed;
//        }
//    }
//    public class Debug
//    {
//        public static void Log(object obj)
//        {
//            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

//        }
//    } // time stamps debug
//}

