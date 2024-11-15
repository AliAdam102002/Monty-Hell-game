using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject[] timelineObjects;
    public GameObject timelineObject0;
    public GameObject timelineObject1;
    public GameObject timelineObject2;
    public GameObject timelineObject3;
    public GameObject timelineObject4;
    public GameObject timelineObject5;

    public GameObject cameraAbdo;
    public GameObject switchCanvas;

    //private PlayableDirector[] timelines;
    private PlayableDirector timeline0;
    private PlayableDirector timeline1;
    private PlayableDirector timeline2;
    private PlayableDirector timeline3;
    private PlayableDirector timeline4;
    private PlayableDirector timeline5;

    //private int currentTimelineIndex = 0;
    private int currentDoor = 0;

    void Start()
    {

        //foreach (GameObject go in timelineObjects)
        //{
        //    go.SetActive(false);
        //}
        timelineObject0.SetActive(false);
        timelineObject1.SetActive(false);
        timelineObject2.SetActive(false);
        timelineObject3.SetActive(false);
        timelineObject4.SetActive(false);
        timelineObject5.SetActive(false);
        cameraAbdo.SetActive(false);
        switchCanvas.SetActive(false);

        //timelines = new PlayableDirector[timelineObjects.Length];
        //Debug.Log(timelineObjects.Length);
        //Debug.Log(timelines.Length);
        //Debug.Log(timelineObjects);
        timelineObject0.SetActive(true);
        timeline0 = timelineObject0.GetComponent<PlayableDirector>();
        timeline0.Play();
    }

    public void Door1()
    {
        //Debug.Log(timelineObjects[0]);
        //Debug.Log(timelineObjects[1]);
        timeline0.Stop();
        timelineObject0.SetActive(false);
        timelineObject1.SetActive(true);
        timeline1 = timelineObject1.GetComponent<PlayableDirector>();
        timeline1.Play();
        //currentTimelineIndex = 1;
        currentDoor = 1;
    }

    public void Door2()
    {
        timeline0.Stop();
        timelineObject0.SetActive(false);
        timelineObject1.SetActive(true);
        timeline1 = timelineObject1.GetComponent<PlayableDirector>();
        timeline1.Play();
        //currentTimelineIndex = 1;
        currentDoor = 2;
    }

    public void Door3()
    {
        timeline0.Stop();
        timelineObject0.SetActive(false);
        timelineObject2.SetActive(true);
        timeline2 = timelineObject2.GetComponent<PlayableDirector>();
        timeline2.Play();
        //currentTimelineIndex = 2;
        currentDoor = 3;
    }

    public void switchDoors()
    {
        switchCanvas.SetActive(false);
        cameraAbdo.SetActive(true);
        if (currentDoor == 1)
        {
            timeline1.Stop();
            timelineObject1.SetActive(false);
            timelineObject3.SetActive(true);
            timeline3 = timelineObject3.GetComponent<PlayableDirector>();
            timeline3.Play();
            timeline3.stopped += OnTimeline3Stopped;
            //currentTimelineIndex = 3;
            currentDoor = 2;
        }
        else if (currentDoor == 2)
        {
            timeline1.Stop();
            timelineObject1.SetActive(false);
            timelineObject5.SetActive(true);
            timeline5 = timelineObject5.GetComponent<PlayableDirector>();
            timeline5.Play();
            timeline5.stopped += OnTimeline5Stopped;
            //currentTimelineIndex = 5;
            currentDoor = 1;
            
        }
        else if (currentDoor == 3)
        {
            timeline2.Stop();
            timelineObject2.SetActive(false);
            timelineObject3.SetActive(true);
            timeline3 = timelineObject3.GetComponent<PlayableDirector>();
            timeline3.Play();
            timeline3.stopped += OnTimeline3Stopped;
            //currentTimelineIndex = 3;
            currentDoor = 2;
        }
    }

    public void keepDoors()
    {
        switchCanvas.SetActive(false);
        cameraAbdo.SetActive(true);
        if (currentDoor == 1)
        {
            timeline1.Stop();
            timelineObject1.SetActive(false);
            timelineObject5.SetActive(true);
            timeline5 = timelineObject5.GetComponent<PlayableDirector>();
            timeline5.Play();
            timeline5.stopped += OnTimeline5Stopped;
            //currentTimelineIndex = 5;
        }
        else if (currentDoor == 2)
        {
            timeline1.Stop();
            timelineObject1.SetActive(false);
            timelineObject3.SetActive(true);
            timeline3 = timelineObject3.GetComponent<PlayableDirector>();
            timeline3.Play();
            timeline3.stopped += OnTimeline3Stopped;
            //currentTimelineIndex = 3;

        }
        else if (currentDoor == 3)
        {
            timeline2.Stop();
            timelineObject2.SetActive(false);
            timelineObject4.SetActive(true);
            timeline4 = timelineObject4.GetComponent<PlayableDirector>();
            timeline4.Play();
            timeline4.stopped += OnTimeline4Stopped;
            //currentTimelineIndex = 4;
        }
    }

    void OnTimeline3Stopped(PlayableDirector director)
    {
        // Unsubscribe from the event and deactivate timeline1
        timeline3.stopped -= OnTimeline3Stopped;
        timelineObject3.SetActive(false);

        // Activate and play timeline2
        SceneManager.LoadScene("Win Scene");
    }

    void OnTimeline4Stopped(PlayableDirector director)
    {
        // Unsubscribe from the event and deactivate timeline1
        timeline4.stopped -= OnTimeline4Stopped;
        timelineObject4.SetActive(false);

        // Activate and play timeline2
        SceneManager.LoadScene("Gameover Scene");
    }

    void OnTimeline5Stopped(PlayableDirector director)
    {
        // Unsubscribe from the event and deactivate timeline1
        timeline5.stopped -= OnTimeline3Stopped;
        timelineObject5.SetActive(false);

        // Activate and play timeline2
        SceneManager.LoadScene("Gameover Scene");
    }
}