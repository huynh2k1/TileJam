using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board I;

    [SerializeField] List<Block> listPath;
    [SerializeField] DataSO data;
    public Level CurLevel { get; set; }

    [SerializeField] Block block1;
    [SerializeField] Block block2;

    private void Awake()
    {
        I = this;
    }

    //Kiểm tra có đường đi đến đích hay không
    public bool IsPathValid()
    {
        Block[,] grid = CurLevel.grid;
        Block current = CurLevel.blockStart;

        // Tính vị trí ô tiếp theo theo hướng hiện tại
        Vector2Int nextPos = current.GridPos + DirectionUtils.ToOffset(current.Dir1);
        Direction curDir = current.Dir1;

        // Kiểm tra biên
        if (!IsInsideBoard(nextPos))
        {
            curDir = current.Dir2;
        }
        listPath.Clear();
        listPath.Add(CurLevel.blockStart);

        while (true)
        {
            // Tính vị trí ô tiếp theo theo hướng hiện tại
            nextPos = current.GridPos + DirectionUtils.ToOffset(curDir);
            Debug.Log($"Board Log: nextPos: {nextPos}");

            // Kiểm tra biên
            if (!IsInsideBoard(nextPos))
            {
                Debug.Log($"Board Log: Ngoài grid");

                listPath.Clear();
                return false;
            }

            Block nextBlock = grid[nextPos.x, nextPos.y];
            Debug.Log($"Board Log: nextBlock: {nextBlock.name}");

            // Nếu là vật cản hoặc không có hướng kết nối
            if (!IsNextBlockValid(nextBlock, curDir))
            {
                listPath.Clear();
                return false;
            }

            listPath.Add(nextBlock);

            // Nếu là ô đích → xong
            if (nextBlock.TypeBlock == BlockType.End)
            {
                return true;
            }

            // Lấy hướng ra tiếp theo (bỏ hướng vừa đi vào)
            curDir = GetOutputDirBlock(nextBlock, curDir);
            Debug.Log($"Board Log: Hướng: {curDir.ToString()}");

            current = nextBlock;
        }
    }

    //Kiểm tra ô tiếp theo có đường đi hay không
    bool IsNextBlockValid(Block nextBlock, Direction dirCurBlock)
    {
        if (nextBlock.TypeBlock == BlockType.Obstacle)
        {
            Debug.Log($"Board Log: Vật cản {nextBlock.name}");

            return false;
        }

        Direction dirOpposite = DirectionUtils.Opposite(dirCurBlock);

        if (!nextBlock.HasConnection(dirOpposite))
        {
            Debug.Log($"Board Log: Không có lối vào");

            return false;
        }

        return true;
    }

    //Lấy hướng ra của đoạn đường
    Direction GetOutputDirBlock(Block b, Direction dirCurBlock)
    {
        Direction dirOpposite = DirectionUtils.Opposite(dirCurBlock);
        return b.GetOtherDir(dirOpposite);
    }

    public bool IsInsideBoard(Vector2Int pos)
    {
        Block[,] grid = CurLevel.grid;
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        return pos.x >= 0 && pos.x < rows && pos.y >= 0 && pos.y < cols;
    }

    public void SelectBlock(Block b)
    {
        if (block1 == null)
        {
            block1 = b;
            block1.Select();
        }
        else if (block1 == b)
        {
            block1.UnSelect();
            block1 = null;
        }
        else if (block2 == null)
        {
            block2 = b;
            block2.Select();
            block1.UnSelect(() =>
            {
                SwapBlock(block1, block2);
            });

        }


    }

    void SwapBlock(Block b1, Block b2)
    {
        var temp = b1.CurPos;
        var temp1 = b1.CurPos + Vector3.up / 2;
        var temp2 = b2.CurPos;

        CurLevel.grid[b1.GridPos.x, b1.GridPos.y] = b2;
        CurLevel.grid[b2.GridPos.x, b2.GridPos.y] = b1;

        Vector2Int gridPos = b1.GridPos;
        b1.GridPos = b2.GridPos;
        b2.GridPos = gridPos;

        SoundManager.I.PlaySoundByType(TypeSound.SWAP);

        b1.SetNewPos(temp2, () =>
        {
            b1.CurPos = temp2;
        });
        b2.SetNewPos(temp1, () =>
        {
            b2.UnSelect();
            b2.CurPos = temp;
            this.block1 = null;
            this.block2 = null;
            if (IsPathValid())
            {
                GameCtrl.I.ChangeState(GameState.NONE);
                SoundManager.I.PlaySoundByType(TypeSound.BOAT);
                BoatCtrl.I.MoveAlongPath(listPath, () =>
                {
                    GameCtrl.I.GameWin();
                });
            }
            else
            {
                Debug.Log("Board Log: Bị chặn");
                GameCtrl.I.CountMove();
            }
        });

    }
}
