using UnityEngine;
using System.Collections;

public class placeItemOnHolder : MonoBehaviour
{
    public QuestDatabase Quest_Database;
    public bool place = false;
    public ItemReciever ir;

    void Start()
    {

    }
    
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Quest_Database.Quests[ir.Quest_id_Required -1].Quest_Status == QuestList._Quest_Status.Displayed && !place)
            {
                Instantiate(Quest_Database.Quests[ir.Quest_id_Required -1].Prefab_Object, ir.transform.position, ir.transform.rotation);
                place = true;
                Quest_Database.Quests[ir.Quest_id_Required - 1].Quest_Status = QuestList._Quest_Status.Completed;
            }

            
        }
    }
}
