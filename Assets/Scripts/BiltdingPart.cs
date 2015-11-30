using UnityEngine;
using System.Collections;

public class BiltdingPart : MonoBehaviour {

   
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bomb"))
        {
            SpecialEffectHelper.Instance.Explosion(transform.position);
            Destroy(collision.gameObject,0.1f);
            Destroy(gameObject, 0.1f);
           
        }
       

    }
}
