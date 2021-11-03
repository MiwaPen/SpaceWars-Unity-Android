using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private AudioSource _shootSoundPlayer;
    [SerializeField] private AudioSource _shootSoundEnemy;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private AudioSource _explosion;
    [SerializeField] private AudioSource _bgMusic;
    [SerializeField] private AudioSource _damageSound;
    private PlayerStats _player;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<PlayerStats>();
        _gameManager.OnGameStart += bgMusicPlay;
        _player.OnGetDamage += DamageSoundPlay;
        _player.OnLose += LoseSoundPlay;
    }

    public void ClickPlay()
    {
        _clickSound.Play();
    }
    private void bgMusicPlay()
    {
        _bgMusic.Play();
    }
    public void explosionPlay()
    {
        if (_explosion.isPlaying)
        {
            _explosion.Stop();
        }
        _explosion.Play();
    }
    private void LoseSoundPlay()
    {
        _loseSound.Play();
    }
    public void PlayerShootPlay()
    {
        if (_shootSoundPlayer.isPlaying)
        {
            _shootSoundPlayer.Stop();
        }
        _shootSoundPlayer.Play();
    }
    public void EnemyShootPlay()
    {
        if (_shootSoundEnemy.isPlaying)
        {
            _shootSoundEnemy.Stop();
        }
        _shootSoundEnemy.Play();
    }

    public void DamageSoundPlay()
    {
        if (_damageSound.isPlaying)
        {
            _damageSound.Stop();
        }
        _damageSound.Play();
    }
}
