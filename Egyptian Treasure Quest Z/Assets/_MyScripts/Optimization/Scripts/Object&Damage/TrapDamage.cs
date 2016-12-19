using UnityEngine;
using System.Collections;

public class TrapDamage : MonoBehaviour
{
    #region Variables

    public enum trapType
    {
        PoisonTrap,
        DamageTrap,
        StunTrap
    }

    public trapType TrapType;

    public bool CanDamageEnemy = false;

    public float Damage;
    public float PoisonDamage;

    bool Damage_done = false;
    #endregion

    void OnTriggerEnter(Collider col)
    {
        if(!CanDamageEnemy)
        {
            if(col.tag == "Player" && !Damage_done)
            {
                Damage_done = true;
                switch(TrapType)
                {
                    case trapType.DamageTrap: col.GetComponent<PlayerStats>().Take_Damage(Damage);
                        break;
                    case trapType.PoisonTrap: col.GetComponent<PlayerStats>().Take_Damage(Damage);
                                              col.GetComponent<PlayerStats>().Apply_Status(PlayerStats._player_status.Poison,PoisonDamage);
                        break;
                    case trapType.StunTrap:   col.GetComponent<PlayerStats>().Take_Damage(Damage);
                                              col.GetComponent<PlayerStats>().Apply_Status(PlayerStats._player_status.Stun);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            if (col.tag == "Player" && !Damage_done)
            {
                Damage_done = true;
                switch (TrapType)
                {
                    case trapType.DamageTrap:
                        col.GetComponent<PlayerStats>().Take_Damage(Damage);
                        break;
                    case trapType.PoisonTrap:
                        col.GetComponent<PlayerStats>().Take_Damage(Damage);
                        col.GetComponent<PlayerStats>().Apply_Status(PlayerStats._player_status.Poison, PoisonDamage);
                        break;
                    case trapType.StunTrap:
                        col.GetComponent<PlayerStats>().Take_Damage(Damage);
                        col.GetComponent<PlayerStats>().Apply_Status(PlayerStats._player_status.Stun);
                        break;
                    default:
                        break;
                }
            }
            if (col.tag == "Enemy" && !Damage_done)
            {
                Damage_done = true;
                //Dagdag lang tayo dito sa susunod
            }
        }
    }

}
