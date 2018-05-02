using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class DroneController : BaseEnemyController, IShoot
{
	#region "||||| Basic Shooting Variables |||||"
	[Header("Drone Shooting")]

	[Tooltip("test")]
//	[SerializeField] protected BaseReload _reloadingMechanism;
	public BaseShoot _shootingMechanism;

	public BaseShoot ShootingMechanism { get; set; }
	public AudioSource MyAudioSource { get; set; }
	#endregion

	#region "||||| Audio Settings |||||"
	[Header("Drone Audio")]

	//TODO: Setup Audio.

	[Tooltip("A sound that will consitently play.")]
	[SerializeField] protected AudioClip _hoverSound;
	[SerializeField] protected AudioClip _spawnSound;

	protected AudioSource _audioSource;
	#endregion

	#region "||||| Movement Variables |||||"
	[Header("Movement")]

	[Tooltip("Target of which the drone will orbit around.")]
	public Transform _target;

	[Tooltip("Determines inital movement (Left or Right).")]
	[SerializeField] protected bool _moveRight;

	[SerializeField] protected float _speed;

	// Velocity that will be added after all changes to velocity have been calculated.
	protected Vector3 _velToAdd;
    #endregion

    #region "||||| Targeting Variables |||||"
    [Header("Targeting")]
    [SerializeField] private GameObject _targetedEffect;
    public bool Targeted
    {
        get { return _targeted; }
        set
        {
            _targeted = value;

            if (_targeted)
                _targetedEffect.SetActive(false);
            else
                _targetedEffect.SetActive(true);

        }
    }
    private bool _targeted;
    #endregion

    //_scoreWorth located in baseEnemyController
    //[SerializeField] private int _scoreWorth;

    void OnEnable()
	{
		if(_shootingMechanism == null)
			_shootingMechanism = ScriptableObject.CreateInstance<SimpleAutoShoot>();
	}

	void Awake()
	{
		_shootingMechanism = ScriptableObject.Instantiate(_shootingMechanism);
	}

	// Instantiates an Object at specified position.
	public virtual void CreateObj(GameObject obj, Vector3 pos)
	{
		Instantiate(obj, pos, transform.rotation);
	}


	// Initialsation.
	protected override void Start ()
	{
//		_shootingMechanism = ScriptableObject.Instantiate(_shootingMechanism);

		base.Start(); // Does parent actions.

		_shootingMechanism.Setup(this.gameObject);
        _shootingMechanism._targetTransform = _target;

		_audioSource = GetComponent<AudioSource> ();
		_audioSource.PlayOneShot (_spawnSound);
    }

	protected virtual void FixedUpdate()
	{
		_velToAdd = Vector3.zero; // Resets velocity ready to be manipulated.

		// Movement steps.
		CalculateMovement();
		Rotate();
		Move();
	}

	protected virtual void Update()
	{
		_shootingMechanism.Update();
	}

	// Rotate to look at target pos.
	protected virtual void Rotate()
	{
		_rb.MoveRotation(Quaternion.LookRotation((_target.position - transform.position).normalized, Vector3.up));
	}

	// Calculates movement before applying it.
	/* NOTE:
	 * This was created simiply due to complication when trying to edit velocity multiple times in one frame.
	 * It allows multiple edits. It also allows for easy inhertiance capabilities.
	 */
	protected virtual void CalculateMovement()
	{
		if (_moveRight)
			_velToAdd = transform.right * _speed;
		else
			_velToAdd = -transform.right * _speed;
	}

	// Applies movement.
	protected virtual void Move()
	{
		_rb.velocity = _velToAdd;
	}

    protected override void Die()
    {
        base.Die();
        _gg.AddScore(_scoreWorth);
    }
}