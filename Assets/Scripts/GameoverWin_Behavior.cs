using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverWin_Behavior : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Gameover;
    [SerializeField] AudioClip Escaping;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        //Write if conditions to decide which clip should play in lost or won scenarios
    }
}
