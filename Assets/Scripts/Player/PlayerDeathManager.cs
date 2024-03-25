using Dreamteck.Splines;
using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    private MainHealthManager _mainHealthManager;
    private void Awake()
    {
        _mainHealthManager = GetComponent<MainHealthManager>();
    }
    private void OnEnable()
    {
        _mainHealthManager.objDie += Die;
    }

    private void OnDisable()
    {
        _mainHealthManager.objDie -= Die;
    }

    private void Die()
    {
        SplineFollower splineFollower = GetComponent<SplineFollower>();
        GameObject shooterEntityPos = transform.GetChild(1).gameObject;
        splineFollower.enabled = false;
        shooterEntityPos.SetActive(false);
        Debug.Log(gameObject.name + "  DIE");
    }
}
