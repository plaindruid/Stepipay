#pragma strict

var health : int = 100;

function Update()
{
	if(health <= 0){
		Dead();
	}

}
//damages the enemy
function ApplyDamage (theDamage : int)
{
	health -= theDamage;
}
//destroys the enemy if the health is zero or below
function Dead()
{
	Destroy (gameObject);
}