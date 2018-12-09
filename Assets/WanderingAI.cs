using UnityEngine;
using System.Collections;
public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f; public float obstacleRange = 5.0f;
    private bool _alive;
    private Animator _animator;
    private float _speed = 0.01f;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    void Start() { _alive = true;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", _speed);
        _animator.SetBool("Jumping", false);
    }

    void Update()
    {
        if (_alive) {
            transform.Translate(0, 0, speed * Time.deltaTime);
            _animator.SetBool("Jumping", false);
            _speed = 0.5f;
            _animator.SetFloat("Speed", _speed);
        }
     
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) {
                if (_fireball == null) {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange) {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    public void SetAlive(bool alive) { _alive = alive; }
}