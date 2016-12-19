using UnityEngine;
using System.Collections;

public class ApplyDamage : MonoBehaviour
{
    public enum _damageWho
    {
        Player,
        Enemy
    }

    public enum _DamageType
    {
        Weapon,
        Projectile,
		Enemy
    }

    public _damageWho DamageWho;
    public _DamageType DamageType;

    public bool Damage_Activated = false;

    public float Damage_ammount;

    void OnTriggerEnter(Collider col)
    {
        if (!Damage_Activated)
        {
			if (DamageType != _DamageType.Enemy) {
				if (col.tag == "Player") {
					Damage_Activated = true;
					Apply_Damage (DamageWho, col.gameObject);   
				}

				if (col.tag == "Enemy") {
					Damage_Activated = true;
					Apply_Damage (DamageWho, col.gameObject);
				}
			}
            else 
			{
				Damage_Activated = true;
				Apply_Damage (DamageWho, col.gameObject); 
				Invoke ("ResetDamage", 1);
			}

				
        }

			
    }
    
	void ResetDamage()
	{
		Damage_Activated = false;
	}

    void Apply_Damage(_damageWho Character,GameObject go )
    {
        if (Character == _damageWho.Player)
        {
            go.GetComponent<PlayerStats>().Take_Damage(Damage_ammount);  
        }
        else if (Character == _damageWho.Enemy)
        {
            //hindi ko pa alam ang ilalagay ko dito
        }
        else
        {
            // same here haha
        }

    }    


}
