using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {
    public int Life;
    public GameObject ParentObject;
	// Use this for initialization
	void Start () {
		
	}

    public void takeDamge(int damageIn)
    {
        Life -= damageIn;
    }

    public void receiveDebuffs(string debuff)
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {
        //print("collision");

        if (other.GetComponentInParent<CardProjectile>())
        {
            takeDamge(other.GetComponent<CardProjectile>().Damage);
            other.GetComponentInParent<CardProjectile>().destroyMe();
        }
    }*/
	// Update is called once per frame
	void Update () {
	    if (Life <= 0)
        {
            Destroy(ParentObject);
        }
	}
}
