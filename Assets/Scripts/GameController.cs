using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public UnityEngine.UI.Text ScoreTect;
    public UnityEngine.UI.Text ZvanieText;
    public UnityEngine.UI.Text ExpiriensToNextLevelText;

    public Transform bombPrefub;
    public Transform Bomber;
   // public Transform Bilding;
    public Transform BildingPart;
    Transform plane;
    public float BeginshootingRate = 0.25f;
    private float shootingRate ;

    public float shootCooldown;
    public int floors_max = 4;
    public bool RandoomFloors = false;
    public Transform MenuGame;
    public Transform GameOver;
    public int BildingCount = 10;
    private int InitBildingsOverPlaneKoef = 1;
    private int InitBildingsOverPlaneCount = 0;

    public int BeginInitBildingsOverPlaneCount = 3;
    private bool is_start = false;
    Touch tf;
    int score = 0;

   


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
        shootingRate = BeginshootingRate;
        //  buldings = new ArrayList();
        InitBuldings();
        InitBildingsOverPlaneCount = BeginInitBildingsOverPlaneCount;

    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        if (is_start)
        {
            BiltdingPart[] bp_ = Resources.FindObjectsOfTypeAll<BiltdingPart>();
            Transform[] sp = Resources.FindObjectsOfTypeAll<Transform>();
            

            if (bp_.Length<=1)
            {
                for(int i =0;i<sp.Length;i++)
                {
                    if (sp[i].name.Contains("FireEffect(Clone)") || sp[i].name.Contains("SmokeEffect(Clone)") || sp[i].name.Contains("bp1_oskolok(Clone)"))
                        return;
                }
              //  if(sp.Length==0)
                InitBuldings();
                plane.position = new Vector3(plane.position.x, 5);
                shootingRate -= 0.05f;
                // InitBildingsOverPlaneCount += 1;
                score += score/3;
                ScoreUpdate();
                InitBildingsOverPlaneCount = BeginInitBildingsOverPlaneCount;
                if (score > 5000 )
                    InitBildingsOverPlaneKoef++;
            }
            ZavanieCount();
        }


    }
    // Update is called once per frame



   private void ZavanieCount()
    {
        if(score>=1000 && score<3000)
        {
            ZvanieText.text = "Ефрейтор";
            ExpiriensToNextLevelText.text = "Повышение:\n 3000";
        }
        if (score >= 3000 && score < 4000)
        {
            ZvanieText.text = "Мл. сержант";
            ExpiriensToNextLevelText.text = "Повышение:\n 4000";
        }
        if (score >= 4000 && score < 6000)
        {
            ZvanieText.text = "Cержант";
            ExpiriensToNextLevelText.text = "Повышение:\n 6000";
        }
        if (score >= 6000 && score < 8000)
        {
            ZvanieText.text = "Ст. сержант";
            ExpiriensToNextLevelText.text = "Повышение:\n 8000";
            
        }

        if (score >= 8000 && score < 12000)
        {
            ZvanieText.text = "Старшина";
            ExpiriensToNextLevelText.text = "Повышение:\n 12000";
        }

        if (score >= 12000 && score < 15000)
        {
            ZvanieText.text = "Прапорщик";
            ExpiriensToNextLevelText.text = "Повышение:\n 15000";
        }
        if (score >= 15000 && score < 18000)
        {
            ZvanieText.text = "Ст. прапорщик";
            ExpiriensToNextLevelText.text = "Повышение:\n 18000";
        }
        if (score >= 18000 && score < 21000)
        {
            ZvanieText.text = "Лейтенант";
            ExpiriensToNextLevelText.text = "Повышение:\n 21000";
        }
    }

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
                b.position = new Vector3((float)(-6 + (i * (b.GetComponent<Renderer>().bounds.size.x + 1))), (-4 + j * b.GetComponent<Renderer>().bounds.size.y));


            }
            h_ = UnityEngine.Random.Range(1, floors_max);

        }


    }

    private void P__BildingPartDamaged(object sender, System.EventArgs e)
    {
        score += Random.Range(1, 15);
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
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
           
            Vector3 temp_position = new Vector3((float)(-6 + (i * (BildingPart.GetComponent<Renderer>().bounds.size.x + 1))), -4);
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
        score += Random.Range(1,30);
        ScoreTect.text = "Опыт: " + score.ToString();
    }

    void FixedUpdate()
    {


       if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Space))
        {
            MenuGame.localScale = new Vector3(0.5f, 0.5f);
            PauseGame();
        }


    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        MenuGame.localScale = new Vector3(0f, 0f);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }


    public void Restart()
    {
        GameOver.localScale = new Vector3(0f, 0f);
        Transform[] sp = Resources.FindObjectsOfTypeAll<Transform>();
        for (int i = 0; i < sp.Length; i++)
        {
            if (sp[i].name.Contains("bp1(Clone)") || sp[i].name.Contains("FireEffect(Clone)") || sp[i].name.Contains("SmokeEffect(Clone)") || sp[i].name.Contains("bp1_oskolok(Clone)"))
                Destroy(sp[i].gameObject);
        }
        is_start = false;
        shootingRate = BeginshootingRate;
        score = 0;
        ScoreUpdate(); 
        InitBuldings();
        ZavanieCount();
    }
    public void FireButtonClick()
    {
        if (!is_start)
        {
            is_start = true;

            plane = Instantiate(Bomber) as Transform;
           
            PlaneScript ps_ = plane.GetComponent<PlaneScript>();
            ps_.PlaneOverScreen += Ps__PlaneOverScreen;
            ps_.OnPlaneDestroed += Ps__OnPlaneDestroed;
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

    private void Ps__OnPlaneDestroed(object sender, System.EventArgs e)
    {
        GameOver.localScale = new Vector3(0.5f, 0.5f);
    }

    private void Ps__PlaneOverScreen(object sender, System.EventArgs e)
    {
        InitBildingsOverPlaneCount-=InitBildingsOverPlaneKoef;
        if (InitBildingsOverPlaneCount <= 0)
        {
            InitBuldingsOver();
            InitBildingsOverPlaneCount = BeginInitBildingsOverPlaneCount;
        }
    }
}
