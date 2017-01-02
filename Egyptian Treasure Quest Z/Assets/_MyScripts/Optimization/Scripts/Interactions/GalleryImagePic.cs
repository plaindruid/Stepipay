/// <summary>
/// Gallery image pic.
/// Ilalagay mo to sa mga image na object sa Gallery UI mo
/// 
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GalleryImagePic : MonoBehaviour 
{

	public QuestDatabase Quest_Database;
	public int Quest_ID;
	public Sprite Lock_image; 
	// Use this for initialization
	void Start () 
	{
		GetComponent<Image> ().sprite = Lock_image;   
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CheckQuest (Quest_ID, QuestList._Quest_Status.Completed)) 
		{
			DisplayImage (); 
		}

	}

	bool CheckQuest(int Quest_Id, QuestList._Quest_Status Quest_Status)
	{
		bool res1 = false;
		//Debug.Log("dsfwefasfer");
		foreach (QuestList ql in Quest_Database.Quests)
		{
			if(ql.Quest_ID == Quest_Id && ql.Quest_Status == Quest_Status)
			{
				if (ql.Gallery_opened)
				{	 
					res1 = true;
				}
			}
		}

		if(res1)
		{
			return true; //Return True kung sakto yung quest id and Quest status
		}
		else
		{
			return false;  //Return False kung hindi sakto yung quest id and Quest status
		}

	}

	void DisplayImage()
	{
		if (GetComponent<Image> () != null) 
		{
			GetComponent<Image> ().sprite = get_picture (); 
		} 
		else
		{
			Debug.LogWarning ("Iha walang Image script component akong nakikita");
		}
	}

	Sprite get_picture()
	{
		Sprite imageReturn = null;

		foreach (QuestList ql in Quest_Database.Quests)
		{
			if (ql.Quest_ID == Quest_ID)
			{
				imageReturn = ql.Image; 
			}
		}
		return imageReturn; 

	}

}
