using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Key : MonoBehaviour
{
    public AudioClip sound;
    public Animator animator;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        audioSource.clip = sound;
    }
    public void PlaySound()
    {
        audioSource.volume = 1;
        audioSource.Play();

        animator.SetBool("Pressed", true);
        StopAllCoroutines();
    }

    public void StopSound()
    {
        animator.SetBool("Pressed", false);
        StartCoroutine(DecreaseVolume());
    }

    IEnumerator DecreaseVolume()
    {
        while (audioSource.volume > 0.01)
        {
            audioSource.volume -= 0.02f;
            //Debug.Log("true");
            yield return null;
        } 
    } 
}
