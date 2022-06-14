using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource yell;
    public AudioSource happy;
    public AudioSource collect;
    public AudioSource gameSound;
 
    void Awake()
    {
        Instance = this;
    }

    
    
}
