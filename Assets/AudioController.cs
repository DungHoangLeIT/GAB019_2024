using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
[RequireComponent(typeof(Initialization))]
public class AudioController : Singleton<AudioController>
{
    private bool isSfxMute, isMusicMute;
    [SerializeField] private AudioSource sfxSource, musicSource, gameplayMusic;
    [SerializeField] private AudioSource winPopUp;
    [SerializeField] private AudioSource mouthDisappear;
    private float originVol;
    private void OnEnable()
    {
        originVol = musicSource.volume;
    }
    public bool Music
    {
        set
        {
            PlayerPrefs.SetInt("music_audio", value ? 1 : 0);
            isMusicMute = !value;
            if (isMusicMute)
            {
                Tween.Volume(musicSource, 0f, 1f, 0, Tween.EaseOut, Tween.LoopType.None, null, () => { musicSource.Stop(); }, false);
            }
            else
            {
                musicSource.Play();
                Tween.Volume(musicSource, originVol, 1f, 0, Tween.EaseIn, Tween.LoopType.None, null, null, false);
            }
        }
        get { return PlayerPrefs.GetInt("music_audio", 1) == 1; }
    }
    public bool SFX
    {
        set
        {
            PlayerPrefs.SetInt("sfx_audio", value ? 1 : 0);
            isSfxMute = !value;
        }
        get { return PlayerPrefs.GetInt("sfx_audio", 1) == 1; }
    }
    protected override void OnRegistration()
    {
        isMusicMute = !Music;
        isSfxMute = !SFX;
        if (!isMusicMute)
            musicSource.Play();
    }
    public void PlaySfx(AudioClip clip)
    {
        if (!isSfxMute)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    public void PlayLongSFX(AudioClip clip, bool isLoop = false)
    {
        if (!isSfxMute)
        {
            sfxSource.clip = clip;
            sfxSource.loop = isLoop;
            sfxSource.Play();
        }
    }
    public void StopLongSFX()
    {
        sfxSource.Stop();
    }

    public void StopLongAudio()
    {
        gameplayMusic.Stop();
    }
    public void PlayMusic(AudioClip clip, bool isLoop)
    {
        gameplayMusic.Stop();
        if (musicSource.clip != null)
            if (musicSource.clip.name == clip.name)
                return;
        musicSource.clip = clip;
        musicSource.loop = isLoop;
        if (!isMusicMute)
            musicSource.Play();
    }

    public void PlayBGMenu(bool isLoop)
    {
        musicSource.loop = isLoop;
        gameplayMusic.Stop();
        if (!isMusicMute)
            musicSource.Play();
    }
    public void PlayGameplayMusic(AudioClip clip, bool isLoop)
    {
        musicSource.Stop();
        if (gameplayMusic.clip != null)
            if (gameplayMusic.clip.name == clip.name)
                return;
        gameplayMusic.clip = clip;
        gameplayMusic.loop = isLoop;
        if (!isMusicMute)
            gameplayMusic.Play();
    }

    public void PlayWinPopUp()
    {
        gameplayMusic.Stop();
        winPopUp.PlayOneShot(winPopUp.clip);
    }

    public void PlayDisappearMouth()
    {
        mouthDisappear.PlayOneShot(mouthDisappear.clip);
    }

}
