using UnityEngine;
using System;

public class BildingScript : MonoBehaviour {

	// Use this for initialization

        public int floors_max =4;
        public Transform bp1;
       public bool RandoomFloors = false;
        public event EventHandler BildingPartDestroyed;
    public event EventHandler BildingPartDamaged;

    void Start () {

        int h_ = UnityEngine.Random.Range(1, floors_max);



        for (int j = 0; j < ((!RandoomFloors)?floors_max:h_); j++)
        {
            var b = Instantiate(bp1) as Transform;
            BiltdingPart p_ = b.GetComponent<BiltdingPart>();
            p_.Destroyed += P__PartDestroyed;
            p_.Damaged += P__Damaged;
            b.position = new Vector3(transform.position.x, (-3 + j * b.GetComponent<Renderer>().bounds.size.y));
            // buldings.Add(b);
        }
        h_ = UnityEngine.Random.Range(1, floors_max);
    }

    private void P__Damaged(object sender, EventArgs e)
    {
       if(BildingPartDamaged!=null)
        {
            BildingPartDamaged(null, null);
        }
    }

    private void P__PartDestroyed(object sender, EventArgs e)
    {
        if (BildingPartDestroyed != null)
            BildingPartDestroyed(null, null);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
