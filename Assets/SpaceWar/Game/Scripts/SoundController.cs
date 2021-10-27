using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource ClickSound;
    [SerializeField] private AudioSource ShootSoundPlayer;
    [SerializeField] private AudioSource ShootSoundEnemy;
    [SerializeField] private AudioSource LoseSound;
    [SerializeField] private AudioSource Explosion;
    [SerializeField] private AudioSource BgMusic;
    [SerializeField] private AudioSource DamageSound;


    public void ClickPlay()
    {
        ClickSound.Play();
    }
    public void bgMusicPlay()
    {
        BgMusic.Play();
    }
    public void explosionPlay()
    {
        if (Explosion.isPlaying)
        {
            Explosion.Stop();
        }
        Explosion.Play();
    }
    public void LoseSoundPlay()
    {
        LoseSound.Play();
    }
    public void PlayerShootPlay()
    {
        if (ShootSoundPlayer.isPlaying)
        {
            ShootSoundPlayer.Stop();
        }
        ShootSoundPlayer.Play();
    }
    public void EnemyShootPlay()
    {
        if (ShootSoundEnemy.isPlaying)
        {
            ShootSoundEnemy.Stop();
        }
        ShootSoundEnemy.Play();
    }

    public void DamageSoundPlay()
    {
        if (DamageSound.isPlaying)
        {
            DamageSound.Stop();
        }
        DamageSound.Play();
    }
}
