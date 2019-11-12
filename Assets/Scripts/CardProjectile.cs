//Authored by Thomas Landry
//represents the in game projectiles properties

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProjectile : MonoBehaviour {
    //public GameObject[] Enemies;
    public int Damage;
    public string[] Buffs;
    public float LifeTime;
    public GameObject parentObject;
    // Use this for initialization
	void Start () {
        Buffs = new string[4];
        Destroy(parentObject, LifeTime);
	}
	public void setDamage(int damage) //sets the projectiles final damage
    {
        Damage = damage;
    }
    public void setBuffs(string[] buffs) //adds any utility buffs
    {
        Buffs = buffs;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<EnemyLife>() != null)
        {
            foreach (string buff in Buffs)
            {
                if (buff == "Crit")
                {
                    if (UnityEngine.Random.Range(0,4) == 0)
                    {
                        Damage = Damage * 2;
                    }
                }
            }
            other.GetComponentInParent<EnemyLife>().takeDamge(Damage);
            foreach (string buff in Buffs)
            {
                if (buff != "")
                {
                    other.GetComponentInParent<EnemyLife>().receiveDebuffs(buff);
                }
            }

        }
    }
    public void destroyMe()
    {
        Destroy(parentObject);
    }
    
    // Update is called once per frame
	void Update () {
		
	}
    
}
