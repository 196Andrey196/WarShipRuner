using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    [SerializeField] Slider _progresBar;
    [SerializeField] SplineComputer _spline;
    [SerializeField] private SplineFollower _player;

    private void Start()
    {
        if (_spline != null && _player != null)
        {
            _progresBar.minValue = (float)_player.spline.GetPointPercent(0);
            _progresBar.maxValue = (float)_player.spline.GetPointPercent(1);
        }
    }
    private void Update()
    {
        if (_spline != null && _player != null)
        {
            _progresBar.value = (float)_player.result.percent;
        }
    }


}

