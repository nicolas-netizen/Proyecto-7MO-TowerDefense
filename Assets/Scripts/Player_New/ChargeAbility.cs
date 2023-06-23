using System.Collections;
using UnityEngine;

public class ChargeAbility : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _dashDistance = 5f;
    [SerializeField] private float _dashTime = 0.2f;
    [SerializeField] private float _dashCooldown = 1f;
    [SerializeField] private GameObject _shieldBackObject;
    [SerializeField] private GameObject _shieldHandObject;
    [SerializeField] private Player _player;
    [SerializeField] private float _damage;

    public float cameraShiftAmount = 0.5f;
    public float cameraShiftSpeed = 5f;
    private bool _canDash = true;
    private bool _onDash;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            Dash(movement.normalized);
        }
    }

    private void Dash(Vector3 direction)
    {
        StartCoroutine(PerformDash(direction));
    }

    public IEnumerator PerformDash(Vector3 direction)
    {
        _canDash = false;
        float elapsedTime = 0f;
        _player.PlayerVFX.Dashs();
        _shieldBackObject.SetActive(false);
        _shieldHandObject.SetActive(true);

        _player.AnimationController.Animator.SetBool("BlockAbility", true);

        _onDash = true;

        while (elapsedTime < _dashTime)
        {

            _player.MovementController.Controller.Move(GetRelativeVector(direction) * _speed * Time.deltaTime);
            //transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / _dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _onDash = false;

        _player.AnimationController.Animator.SetBool("BlockAbility", false);
        _shieldBackObject.SetActive(true);
        _shieldHandObject.SetActive(false);
        _player.PlayerVFX.StopDash();
        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }

    public Vector3 GetRelativeVector(Vector3 vector)
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelative = vector.z * forward;
        Vector3 rightRelative = vector.x * right;

        Vector3 camRel = Vector3.zero;

        camRel = forwardRelative + rightRelative;
        return camRel;
    }

    private void OnTriggerStay(Collider other)
    {
        if(_onDash)
        {
            var col = other.gameObject?.GetComponent<IDamageable>();

            if (col != null)
            {
                col.TakeDamage(_damage, transform.right);
            }
        }
    }

}
