using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading;

public class UI_LoadingAsync : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _backgroundImg;
    [SerializeField] private Image _fillImg;

    [Header("Sliders Colors")]
    [SerializeField] private Color _fillColor;
    [SerializeField] private Color _backgroundColor;

    [Header("Param")]
    [SerializeField] private float _timeToFill = 5f;
    [SerializeField] private bool _autoFillOnStart;

    CancellationTokenSource _cts;

    private void Start()
    {
        InitSlider();

        if (_autoFillOnStart)
        {
            StartLoading();
        }
    }

    private void InitSlider()
    {
        _fillImg.color = _fillColor;
        _backgroundImg.color = _backgroundColor;

        _slider.value = 0f;
    }

    [Button]
    private void StartLoading()
    {
        if (_cts != null)
        {
            _cts.Cancel();
        }

        _cts = new CancellationTokenSource();

        CancellationToken ct = _cts.Token;
        CancellationToken ct2 = this.destroyCancellationToken;

        CancellationToken combinedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(ct, ct2).Token;

        _ = LoadingTask(combinedCancellationToken);
    }

    [Button]
    private void CancelLoading()
    {
        if (_cts != null)
        {
            _cts.Cancel();
        }
    }

    private async UniTask LoadingTask(CancellationToken ct)
    {
        float progress = 0f;
        bool cancelled = false;

        while (progress < 1f && !cancelled)
        {
            progress += Time.deltaTime / _timeToFill;
            _slider.value = progress;
            cancelled = await UniTask.Yield(PlayerLoopTiming.Update, ct).SuppressCancellationThrow();
        }

        if (cancelled)
        {
            if (_slider != null)
            {
                _slider.value = 0f;
            }
        }
        else
        {
            _slider.value = 1f;
        }



    }
}
