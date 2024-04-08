using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Animator _animator;
    private SplineFollower _splineFollower;
    [SerializeField] private float _moveSpeed;
    private float _minChangePositionSpeed = -3;
    private float _maxChangePositionSpeed = 3;
    [SerializeField] float _newXPosition;
    void Start()
    {
        _splineFollower = GetComponent<SplineFollower>();
        _animator = GetComponent<Animator>();
    }
    public void StartMove()
    {
        StartCoroutine(BossMove());
    }
    private IEnumerator BossMove()
    {
         while (true)
        {
            _newXPosition = Mathf.PingPong(Time.time* _moveSpeed, _maxChangePositionSpeed - _minChangePositionSpeed) + _minChangePositionSpeed;
            _splineFollower.offsetModifier.keys[0].offset.x = _newXPosition;
            yield return null;
        }
    }
}
