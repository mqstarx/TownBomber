using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public GUIText ScoreTect;

    public Transform bombPrefub;
    public Transform Bomber;
    public Transform Bilding;
    Transform plane;
    public float shootingRate = 0.25f;
    public float shootCooldown;

    
    private bool is_start = false;
    Touch tf;
    int score = 0;

    private ArrayList LastCoords; // позиции верхушек домов

    
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
    // Use this for initialization
    void Start()
    {
        //  buldings = new ArrayList();
        InitBuldings();
        LastCoords = new ArrayList();
        
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
      
        for (int i = 0; i < 10; i++)
        {

            
                var b = Instantiate(Bilding) as Transform;
                BiltdingPart p_ = b.GetComponent<BiltdingPart>();
              //  p_.CollisionWirhBomb += P__CollisionWirhBomb;
                b.position = new Vector3((float)(-8 + (i *( b.GetComponent<Renderer>().bounds.size.x+1.5) )),  b.GetComponent<Renderer>().bounds.size.y);
                // buldings.Add(b);
         
           
        }


    }
    void InitBuldingsOver()
    {
        Object[] _jjj = Resources.FindObjectsOfTypeAll(typeof(BiltdingPart));
        

        
        // int h_ = 1
        for (int i = 0; i < 10; i++)
        {

            // for (int j = 0; j < h_; j++)
            //  {
            var b = Instantiate(Bilding) as Transform;
            BiltdingPart p_ = b.GetComponent<BiltdingPart>();
            p_.CollisionWirhBomb += P__CollisionWirhBomb;
            b.position = new Vector3((float)(-8 + i * ((float)b.GetComponent<Renderer>().bounds.size.x + 1)), 0);

            // }

        }


    }

    private void P__CollisionWirhBomb(object sender, System.EventArgs e)
    {
        score += 100;
        ScoreTect.text = "Очки: " + score.ToString();
    }

    void FixedUpdate()
    {


        if (Input.touchCount > 0)
        {
            tf = Input.GetTouch(0);

        }


        if (Input.touchCount > 0 && tf.phase == TouchPhase.Began || Input.GetKey(KeyCode.Space))
        {




            if (!is_start)
            {
                is_start = true;

                plane = Instantiate(Bomber) as Transform;
                PlaneScript ps_ = plane.GetComponent<PlaneScript>();
                ps_.PlaneOverScreen += Ps__PlaneOverScreen;
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

    private void Ps__PlaneOverScreen(object sender, System.EventArgs e)
    {
       // InitBuldingsOver();
    }
}
