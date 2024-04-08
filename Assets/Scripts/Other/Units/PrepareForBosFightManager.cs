using Dreamteck.Splines;
using UnityEngine;

public class PrepareForBosFightManager : MonoBehaviour
{
    [SerializeField] private SplineFollower _player;

    public void StopPlayer()
    {
        _player.followSpeed = 0;
    }

}
