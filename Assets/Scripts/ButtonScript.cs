using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


    public Transform bombPrefub;
    public Transform Bomber;
    public Transform bp1;
    Transform plane;
    public float shootingRate = 0.25f;
    public float shootCooldown;

    private bool click_;
    private bool is_start =false;
    Touch tf;
    //ArrayList buldings;


    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
    // Use this for initialization
    void Start () {
      //  buldings = new ArrayList();
        InitBuldings();
    }
	
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
	// Update is called once per frame

    void InitBuldings()
    {
       int h_ = Random.Range(1, 4);
        for(int i=0;i<17; i++)
        {

            for(int j=0;j<h_;j++)
            {
                var b = Instantiate(bp1) as Transform;
                b.position = new Vector3((float)(-8.5 + i * ((float)b.GetComponent<Renderer>().bounds.size.x+0.4)), (-3 + j * b.GetComponent<Renderer>().bounds.size.y));
               // buldings.Add(b);
            }
            h_ = Random.Range(1, 4);
        }


    }

	void FixedUpdate () {


        if (Input.touchCount > 0)
        {
            tf = Input.GetTouch(0);

        }


        if (Input.touchCount > 0 && tf.phase== TouchPhase.Began || Input.GetKey(KeyCode.Space) )
        {
            
           

            
            if (!is_start)
            {
                is_start = true;
                
                plane = Instantiate(Bomber) as Transform;
                shootCooldown = shootingRate;
            }
            else
            {

                if (CanAttack)
                {
                    shootCooldown = shootingRate;
                    var bomb = Instantiate(bombPrefub) as Transform;



                    bomb.position = new Vector2(plane.position.x, plane.position.y - 0.7f);
                }
                // bomb.position = Samolet.position;
               
            }
           


        }
       

    }
}
