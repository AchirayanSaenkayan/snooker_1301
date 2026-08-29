using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] bgm;

    [SerializeField]
    private AudioSource[] sfx;

    [SerializeField]
    private AudioMixer mixer;

    public static AudioManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void StopAllBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    public void PlayBGM(int i)
    {
        StopAllBGM();

        if (i < bgm.Length)
        {
            bgm[i].Play();
        }
    }

    public void PlaySFX(int i)
    {
        if (i < sfx.Length)
        {
            sfx[i].PlayOneShot(sfx[i].clip);
        }
    }

    public void AdjustBGMVolume(float value)
    {
        mixer.SetFloat("BGMVolume", value);
    }

    public void AdjustMasterVolume(float volume)
    {
        mixer.SetFloat("master", volume);
        PlayerPrefs.SetFloat("master", volume);
        PlayerPrefs.Save();
    }

    public float LoadCurrentMasterVol()
    {
        return PlayerPrefs.GetFloat("master", 0f);
    }
}