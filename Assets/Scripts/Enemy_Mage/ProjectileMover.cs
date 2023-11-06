    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering.PostProcessing;
public enum ProjectileEffect
    {
        Stun,
        Slow,
        Post
    }

    public class ProjectileMover : MonoBehaviour
    {
        public float _speed = 15f;
        public float _hitOffset = 0f;
        public bool _UseFirePointRotation;
        public Vector3 _rotationOffset = new Vector3(0, 0, 0);
        public GameObject _hit;
        public GameObject _flash;
        public GameObject _stunEffect;
        public GameObject _slowEffect;
        public GameObject _postEfect;
        public ProjectileEffect _effectType;

    private Rigidbody rb;
        public GameObject[] Detached;
        [SerializeField] private float _stunDuration = 2.0f;
        [SerializeField] private float _slowDuration = 2.0f;
        [SerializeField] private float _postDuration = 2.0f;
        
        private Transform _playerTransform;
        private bool _hasHitPlayer = false;
        private PostProcessVolume postProcessVolume;
        private DepthOfField depthOfFieldEffect;

         [SerializeField] Player _player;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (_flash != null)
            {
                var flashInstance = Instantiate(_flash, transform.position, Quaternion.identity);
                flashInstance.transform.forward = gameObject.transform.forward;
                var flashPs = flashInstance.GetComponent<ParticleSystem>();
                if (flashPs != null)
                {
                    Destroy(flashInstance, flashPs.main.duration);
                }
                else
                {
                    var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(flashInstance, flashPsParts.main.duration);
                }
            }
            Destroy(gameObject, 5);
        }

        void FixedUpdate()
        {
            if (_speed != 0 && !_hasHitPlayer)
            {
                Vector3 directionToPlayer = (_playerTransform.position - transform.position).normalized;

                rb.velocity = directionToPlayer * _speed;
                transform.position += directionToPlayer * (_speed * Time.deltaTime);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                _speed = 0;
                ContactPoint contact = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 pos = contact.point + contact.normal * _hitOffset;
                Debug.Log("Proyectil ha colisionado con: " + collision.gameObject.tag);

                if (_effectType == ProjectileEffect.Stun && _stunEffect != null)
                {
                    var stunInstance = Instantiate(_stunEffect, collision.transform.position, Quaternion.identity);
                    Destroy(stunInstance, _stunDuration);

                    StunManager.ApplyStunToPlayer(collision.gameObject.GetComponent<Player>(), _stunDuration);
                }
                else if (_effectType == ProjectileEffect.Slow && _slowEffect != null)
                {
                    Debug.Log("slow"); 
                    var slowInstance = Instantiate(_slowEffect, collision.transform.position, Quaternion.identity);
                    Destroy(slowInstance, _slowDuration);
                    var playerMovement = collision.gameObject.GetComponent<Player>();
                    if (playerMovement != null)
                    {
                        playerMovement.MovementController.ReduceMoveSpeed(_slowDuration);
                    }
                }
            else if (_effectType == ProjectileEffect.Post && _postEfect != null)
            {
                var Post = Instantiate(_postEfect, collision.transform.position, Quaternion.identity);
                Destroy(Post, _postDuration);
                postProcessVolume = _postEfect.GetComponent<PostProcessVolume>();
                if (postProcessVolume != null && postProcessVolume.profile.TryGetSettings(out depthOfFieldEffect))
                {
                    depthOfFieldEffect.enabled.value = true;
                    depthOfFieldEffect.focusDistance.value = 1.0f;
                    depthOfFieldEffect.aperture.value = 1.0f;
                    StartCoroutine(DisablePostEffect());
                }
            }



            foreach (var detachedPrefab in Detached)
                {
                    if (detachedPrefab != null)
                    {
                        detachedPrefab.transform.parent = null;
                    }
                }

                Destroy(gameObject);
            }
        }
    private IEnumerator DisablePostEffect()
    {
        yield return new WaitForSeconds(_postDuration);

        if (depthOfFieldEffect != null)
        {
            depthOfFieldEffect.enabled.value = false;
        }
    }
}


