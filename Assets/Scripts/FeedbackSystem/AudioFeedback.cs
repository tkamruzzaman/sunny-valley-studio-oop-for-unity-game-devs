using System.Collections;
using UnityEngine;

namespace FeedbackSystem
{
    public class AudioFeedback : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip audioClip;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            audioSource.PlayOneShot(audioClip);

            StartCoroutine(DestroyAfterFinishedPlaying());
        }

        private IEnumerator DestroyAfterFinishedPlaying()
        {
            yield return new WaitForSeconds(audioClip.length);
            
            Destroy(gameObject);
        }
    }
}