using UnityEngine;
public class BulletController : MonoBehaviour
{
    [SerializeField] private int DMG;
    [SerializeField] private float speed;
    [SerializeField] private string rotation = null;
    private TagsHolder tagsHolder = new TagsHolder();
    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (rotation)
        {
            case "UP":
                rigidbody.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                break;
            case "DOWN":
                rigidbody.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        Destroy(this.gameObject);
        if (otherTag == tagsHolder.tags[6] || otherTag == tagsHolder.tags[5] || otherTag == tagsHolder.tags[3] || otherTag == tagsHolder.tags[7])
        {
            Destroy(this.gameObject);
        }
    }

    public void  SetRotation(string rot)
    {
        rotation = rot;
    }

    public int GetBulletDMG()
    {
        return DMG;
    }
}
