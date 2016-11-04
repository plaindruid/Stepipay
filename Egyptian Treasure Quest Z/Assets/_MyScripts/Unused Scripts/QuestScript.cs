using UnityEngine;
using System.Collections;

public class QuestScript : MonoBehaviour
{
    public GameObject[] show;
    public GameObject[] hide;

    public enum quest_state
    {
        not_started, on_going, completed
    };

    public quest_state qs;
    
    void Start()
    {

    }

    
    void Update()
    {
        switch (qs)
        {
            case quest_state.not_started:
                NotStarted();
                break;

            case quest_state.on_going:
                OnGoing();
                break;

            case quest_state.completed:
                Completed();
                break;
        }
    }

    void NotStarted()
    {

    }

    void OnGoing()
    {

    }

    void Completed()
    {
        foreach (GameObject trivia in show)
        {
            trivia.SetActive(true);
        }
        foreach (GameObject trivia in hide)
        {
            trivia.SetActive(false);
        }

        StartCoroutine(hideTrivia());
    }

    IEnumerator hideTrivia()
    {
        yield return new WaitForSeconds(5);
        foreach (GameObject trivia in show)
        {
            trivia.SetActive(false);
        }
    }
}
