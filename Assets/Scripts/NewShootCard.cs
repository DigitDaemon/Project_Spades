//Script authored by Thomas Landry 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShootCard : MonoBehaviour 
{
    public float projectileLife; //variable for the life span of the projectile
    public GameObject projectilePrefab;
    public Transform projectileSpawn; //CardProjectile spawn location
	public Transform fireTransform; //spawn direction of the card
	public Rigidbody card; 
	public float cardSpeed; //variable for te speed of the projectile
    public NewDeckOfCards Deck;
    public GameObject Player;

    void Fire()
    {
        //print(Deck.getCardAtN(0));
        var projectile = (GameObject)Instantiate(projectilePrefab, fireTransform.position, fireTransform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * cardSpeed;
        if (Deck.getNextDamage() != -1) //checks to make sure there are cards left in the deck
        {
            projectile.GetComponent<CardProjectile>().Damage = Deck.getNextDamage(); //gives the projectile damage based on the card and any damage buffs
            projectile.GetComponent<CardProjectile>().setBuffs(Deck.getNextBuffs()); //gives the projectile utility buffs, unimplemented in current build
            Deck.Discard();

        }
        else
        {
            DestroyImmediate(projectile); //aborts the creation of  aprojectile if the deck is empty
        }

        
    }

	private void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
            Fire();
        }
        if (Input.GetButtonDown ("Shuffle"))
        {
            Deck.Shuffle(); //aka reload
        }
        if (Input.GetButtonDown("Hold"))
        {
            print(Deck.holdCard()); //holds cards for buffs after shuffling
        }
	}
}
