using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]
public class PlayerStats : MonoBehaviour
{
    #region Variables
    #region Public Variables
    public enum _player_status
    {
        Normal,
        Poison,
        Stun,
        Dead
    }

    public _player_status Player_Status;


    #endregion

    #region Private Variables
    const float Life_value = 100;
    float _player_life_Gauge;
    float _DOT_damage;
    float _poisonrate;
    #endregion

    #endregion

    #region Contructors
    public PlayerStats()
    {
        Initialize_Life(); 
    } 

    public PlayerStats(float Life, _player_status Status)
    {
        _player_life_Gauge = Life;
        Player_Status = Status; 
    }

    #endregion


    void Awake()
    {
        Initialize_Life(); 
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!StephGameManager.instance.Debug_mode)
		{
			switch (Player_Status)
			{
			case _player_status.Normal:
				break;
			case _player_status.Poison:
				Apply_poisonDmage ();
				break;
			case _player_status.Stun:
				break;
			case _player_status.Dead:
				break; 
			default:
				break;  
			}
		}
	}


    #region Public Methods
    public void Take_Damage(float damage)
    {
		if(!StephGameManager.instance.Debug_mode)
        _player_life_Gauge -= damage; 
    }

    public void Apply_Status(_player_status Status)
    {
		if(!StephGameManager.instance.Debug_mode)
        Player_Status = Status;
    }

    public void Apply_Status(_player_status Status,float DOT_damage)
    {
		if (!StephGameManager.instance.Debug_mode) 
		{
			Player_Status = Status;
			_DOT_damage = DOT_damage; 
		}

    }

    public void Cure_Status()
    {
        if (Player_Status != _player_status.Normal)
        {
            Player_Status = _player_status.Normal;
        }
    }
    public float Get_life()
    {
        float Life;

        if(_player_life_Gauge <= 0)
        {
            Life = 0;
        }
        else if(_player_life_Gauge >= 100)
        {
            Life = Life_value;
        }
        else
        {
            Life = _player_life_Gauge;
        }

        return Life;
    }


    public void Heal_player(float Heal_Ammount)
    {
        if(_player_life_Gauge < 100)
        {
            _player_life_Gauge = 100;
        }
        else
        {
            _player_life_Gauge += Heal_Ammount;
        }
    }


    #endregion

    #region Private Methods

    void Initialize_Life()
    {
        _player_life_Gauge = 100;
        _DOT_damage = 0;
    }

    void Apply_poisonDmage()
    {
		if (!StephGameManager.instance.Debug_mode)
		{
			_poisonrate += Time.deltaTime;
			if (_poisonrate >= 2) 
			{
				_poisonrate = 0;
				_player_life_Gauge -= _DOT_damage;  
			}
		}
    }

    void Apply_death()
    {
        //Bahala kung may gusto kang ilagay hahaha
    }
    #endregion
}
