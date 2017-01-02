using UnityEngine;
using System.Collections;

public class soundScript : MonoBehaviour
{
    public AudioSource audio;
    public bool canDamage;
    public GameObject bloodUI;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();

            if (canDamage && bloodUI != null)
            {
                bloodUI.SetActive(true);
                StartCoroutine(disableBloodUI());
            }
        }
    }

    IEnumerator disableBloodUI()
    {
        yield return new WaitForSeconds(1);
        bloodUI.SetActive(false);
    }
}
