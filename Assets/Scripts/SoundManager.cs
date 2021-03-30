using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static void PlaySound()
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
    }
        public static AudioClip BumperSound;
        public static AudioClip GameLoop;
        public static AudioClip BashToySound;
        public static AudioClip PaddleSound;

    
}
