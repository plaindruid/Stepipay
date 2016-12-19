#pragma strict

var theDamage : int = 50;
var Distance : float;
var MaxDistance : float = 1.5;
var theMace : Transform;

function Update () {
	if(Input.GetButtonDown("Fire1"))
	{
		theMace.GetComponent.<Animation>().Play("Attack");
		var hit : RaycastHit;
		if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), hit))
		{
			Distance = hit.distance;
			if(Distance < MaxDistance)
			{
				hit.transform.SendMessage("ApplyDamage", theDamage, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}