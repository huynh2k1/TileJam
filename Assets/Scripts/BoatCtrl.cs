using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BoatCtrl : MonoBehaviour
{
    public static BoatCtrl I;
    public float speed = 0.5f; // thời gian đi giữa 2 block
    public float rotateDuration = 0.2f;

    private void Awake()
    {
        I = this;
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void MoveAlongPath(List<Block> path, Action actionDone = default)
    {
        if (path == null || path.Count == 0) return;

        Vector3[] pathTemp = new Vector3[path.Count];
        for(var p = 0; p < path.Count; p++)
        {
            pathTemp[p] = path[p].CurPos;
        }
        float timeMove = pathTemp.Length / speed;
        transform.DOKill();
        transform.DOPath(pathTemp, timeMove, PathType.Linear, PathMode.Full3D).SetLookAt(0.02f).SetEase(Ease.Linear).OnComplete(() =>
        {
            actionDone?.Invoke();
        });
    }

    public void SetRotation(Block blockStart)
    {
        Vector2Int nextPos = blockStart.GridPos + DirectionUtils.ToOffset(blockStart.Dir1);
        Direction curDir = blockStart.Dir1;

        // Kiểm tra biên
        if (!Board.I.IsInsideBoard(nextPos))
        {
            curDir = blockStart.Dir2;
        }
        transform.rotation = Quaternion.Euler(DirectionUtils.ToEulerAngles(curDir));
    }

}
