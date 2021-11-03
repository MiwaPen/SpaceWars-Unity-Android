using UnityEngine;
public class BulletController : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    private  Rigidbody _rigidbody;
    private BulletRotation _bulletRotation;

    private void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (_bulletRotation)
        {
            case BulletRotation.Up:
                _rigidbody.transform.Translate(new Vector3(0, _speed * Time.deltaTime, 0));
                break;
            case BulletRotation.Down:
                _rigidbody.transform.Translate(new Vector3(0, -_speed * Time.deltaTime, 0));
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    public void  SetRotation(BulletRotation bulletRotation)
    {
        this._bulletRotation = bulletRotation;
    }

    public int GetBulletDMG()
    {
        return _damage;
    }
}
