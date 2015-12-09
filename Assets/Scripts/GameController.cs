using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public UnityEngine.UI.Text ScoreTect;
    public UnityEngine.UI.Text ZvanieText;

    public Transform bombPrefub;
    public Transform Bomber;
   // public Transform Bilding;
    public Transform BildingPart;
    Transform plane;
    public float shootingRate = 0.25f;
    public float shootCooldown;
    public int floors_max = 4;
    public bool RandoomFloors = false;

    public int BildingCount = 10;


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
        int h_ = UnityEngine.Random.Range(1, floors_max);
        for (int i = 0; i < BildingCount; i++)
        {

            for (int j = 0; j < ((!RandoomFloors) ? floors_max : h_); j++)
            {
                /* var b = Instantiate(BildingPart) as Transform;
                 BildingScript p_ = b.GetComponent<BildingScript>();
                 p_.BildingPartDestroyed += P__BildingPartDestroyed;
                 p_.BildingPartDamaged += P__BildingPartDamaged;
                 b.position = new Vector3((float)(-6 + (i * (b.GetComponent<Renderer>().bounds.size.x + 1))), b.GetComponent<Renderer>().bounds.size.y);
                 // buldings.Add(b);*/
                var b = Instantiate(BildingPart) as Transform;
                BiltdingPart p_ = b.GetComponent<BiltdingPart>();
                p_.Destroyed +=  P__BildingPartDestroyed;
                ;
                p_.Damaged += P__BildingPartDamaged;
                b.position = new Vector3((float)(-6 + (i * (b.GetComponent<Renderer>().bounds.size.x + 1))), (-3 + j * b.GetComponent<Renderer>().bounds.size.y));


            }
            h_ = UnityEngine.Random.Range(1, floors_max);

        }


    }

    private void P__BildingPartDamaged(object sender, System.EventArgs e)
    {
        score += Random.Range(1, 3);
        ScoreTect.text = "Опыт: " + score.ToString();
    }

    void InitBuldingsOver()
    {
       
        


        int timer_kill = 0;
        // int h_ = 1
        for (int i = 0; i < BildingCount; i++)
        {

            // for (int j = 0; j < h_; j++)
            //  {
           
            Vector3 temp_position = new Vector3((float)(-6 + (i * (BildingPart.GetComponent<Renderer>().bounds.size.x + 1))), -3);
            // while (IsIntersect(_jjj, new Vector3(b.position.x + b.GetComponent<Renderer>().bounds.size.x / 2, b.position.y + b.GetComponent<Renderer>().bounds.size.y / 2)))
            while (IsIntersect( new Vector3(temp_position.x, temp_position.y)))
                {
               temp_position = new Vector3((float)(-6 + (i * (BildingPart.GetComponent<Renderer>().bounds.size.x + 1))), temp_position.y + BildingPart.GetComponent<Renderer>().bounds.size.y);
                timer_kill++;

                if (timer_kill > 500)
                    break;
            }

            var b = Instantiate(BildingPart) as Transform;
           
           // b.GetComponent<Renderer>().material.color = Color.clear;
            BiltdingPart p_ = b.GetComponent<BiltdingPart>();
            p_.Destroyed += P__BildingPartDestroyed;
            p_.Damaged += P__BildingPartDamaged;
            // b.position = new Vector3((float)(-6 + (i * (b.GetComponent<Renderer>().bounds.size.x + 1))), -3);
            b.position = temp_position;
        }
    }

    
    
    

        // b.position = new Vector3((float)(-6 + (i * (b.GetComponent<Renderer>().bounds.size.x + 1))),0);

        // }

    


    
    private bool IsIntersect( Vector3 target)
    {

        Object[] _jjj = Resources.FindObjectsOfTypeAll(typeof(Transform));

        for (int i =0;i< _jjj.Length-1;i++)
        {
            if (_jjj[i].name.Contains("bp1(Clone)"))
            {
                Transform tt = (Transform)_jjj[i];
                   if(tt.position.x==target.x && System.Math.Abs(tt.position.y - target.y)<BildingPart.GetComponent<Renderer>().bounds.size.y)
                 {
                  return true;
                  }
            }
        }
        return false;

    }
   

    private void P__BildingPartDestroyed(object sender, System.EventArgs e)
    {
        score += 10;
        ScoreTect.text = "Опыт: " + score.ToString();
    }

    void FixedUpdate()
    {


        if (Input.touchCount > 0)
        {
            tf = Input.GetTouch(0);

        }


        if (Input.touchCount > 0 && tf.phase == TouchPhase.Began || Input.GetKey(KeyCode.Space))
        {
            InitBuldingsOver();
            /*
            InitBuldingsOver();

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

                        }*/



        }


    }

    public void FireButtonClick()
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


    private void Ps__PlaneOverScreen(object sender, System.EventArgs e)
    {
        InitBuldingsOver();
    }
}
