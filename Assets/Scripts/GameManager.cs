using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public GameObject timeline1Object;  // Assign Timeline 1's GameObject in the Inspector
    public GameObject timeline2Object;  // Assign Timeline 2's GameObject in the Inspector
    public GameObject cameraAbdo;

    private PlayableDirector timeline1;
    private PlayableDirector timeline2;

    void Start()
    {
        // Activate timeline1's GameObject and get the PlayableDirector component
        timeline1Object.SetActive(true);
        timeline1 = timeline1Object.GetComponent<PlayableDirector>();
        timeline2 = timeline2Object.GetComponent<PlayableDirector>();

        // Start playing timeline1 and subscribe to the stopped event
        timeline1.Play();
        timeline1.stopped += OnTimeline1Stopped;
    }

    // This method is called automatically when timeline1 finishes
    void OnTimeline1Stopped(PlayableDirector director)
    {
        // Unsubscribe from the event and deactivate timeline1
        timeline1.stopped -= OnTimeline1Stopped;
        timeline1Object.SetActive(false);

        // Activate and play timeline2
        timeline2Object.SetActive(true);
        cameraAbdo.SetActive(true);
        timeline2.Play();
    }
}