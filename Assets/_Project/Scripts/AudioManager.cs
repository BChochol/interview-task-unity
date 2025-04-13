using UnityEngine;

namespace AE
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource stepsSource;

        [SerializeField] private AudioClip backgroundMusic;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                PlayMusic(backgroundMusic);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySFX(AudioClip clip)
        {
            if (clip == null || sfxSource == null) return;
            sfxSource.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip musicClip)
        {
            if (musicClip == null || musicSource == null) return;
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();
        }

        public void PlayFootsteps(AudioClip clip, bool loop = true)
        {
            if (clip == null || stepsSource == null) return;

            stepsSource.clip = clip;
            stepsSource.loop = loop;
            if (!stepsSource.isPlaying)
                stepsSource.Play();
        }

        public void StopFootsteps()
        {
            if (stepsSource != null && stepsSource.isPlaying)
                stepsSource.Stop();
        }
    }
}