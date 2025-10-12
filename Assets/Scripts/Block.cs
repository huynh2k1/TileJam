using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Collider _collider;

    //Property
    public BlockType TypeBlock;
    public Vector3 CurPos { get; set; }
    public bool IsSelected { get; set; }

    public Vector2Int GridPos;
    public Direction Dir1;
    public Direction Dir2;


    //Tween Setup
    [Header("Cài đặt Shake")]
    private Tween shakeTween;
    [SerializeField] private float duration = 0.5f;      // Thời gian rung
    [SerializeField] private float strength = 0.2f;      // Độ mạnh của rung
    [SerializeField] private int vibrato = 10;           // Số lần rung trong 1 khoảng thời gian
    [SerializeField] private float randomness = 90f;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public Direction GetOtherDir(Direction dir)
    {
        return dir == Dir1 ? Dir2 : Dir1;
    }

    public bool HasConnection(Direction dir)
    {
        return Dir1 == dir || Dir2 == dir;
    }

    private void OnMouseDown()
    {
        if (GameCtrl.I.CurState != GameState.PLAYING)
            return;
        if (TypeBlock == BlockType.Start || TypeBlock == BlockType.End)
        {
            Handheld.Vibrate();
            Shake();
            return;
        }
        SoundManager.I.PlaySoundByType(TypeSound.BLOCKSELECT);
        Board.I.SelectBlock(this);
    }

    public void Select(Action action = default)
    {
        var target = transform.position + Vector3.up / 2;
        transform.DOKill();
        _collider.enabled = false;
        transform.DOMove(target, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _collider.enabled = true;
            action?.Invoke();
        });
    }

    public void UnSelect(Action action = default)
    {
        transform.DOKill();
        var target = transform.position - Vector3.up / 2;
        //CurPos = target;
        _collider.enabled = false;
        transform.DOMove(target, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _collider.enabled = true;
            action?.Invoke();
        });
    }

    public void SetNewPos(Vector3 newPos, Action action = default)
    {
        _collider.enabled = false;
        transform.DOMove(newPos, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _collider.enabled = true;
            action?.Invoke();
        });
    }

    public void Shake()
    {
        // Nếu đang shake rồi thì kill để không chồng hiệu ứng
        if (shakeTween != null && shakeTween.IsActive())
            shakeTween.Kill();

        // Tạo hiệu ứng shake vị trí
        shakeTween = transform.DOShakePosition(
            duration,
            strength,
            vibrato,
            randomness,
            false,        // không snap lại vị trí sau mỗi rung
            true          // rung theo không gian local
        ).SetEase(Ease.OutQuad);
    }

    private void OnDestroy()
    {
        // Giải phóng Tween khi object bị hủy
        if (shakeTween != null) shakeTween.Kill();
    }

    public void SetPos(Vector3 newPos)
    {
        transform.position = newPos;
        CurPos = transform.position;
    }
}
