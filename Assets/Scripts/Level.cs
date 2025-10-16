using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour
{
    public bool IsAutoGrid;
    public int Move;
    public int Rows;
    public int Columns;
    
    [SerializeField] BoatCtrl boat;
    private List<Block> blocks;
    public Block[,] grid;
    public Block blockStart;
    const float spacing = 1.45f;

    private void Awake()
    {
        blocks = GetComponentsInChildren<Block>().ToList();
        Initialization();
    }

    private void Start()
    {
        GetStartBlock();
        SetUpBoat();
        
    }
    private void OnValidate()
    {
        if (!IsAutoGrid)
            return;
        blocks = GetComponentsInChildren<Block>().ToList();

        Initialization();
        GetStartBlock();
        SetUpBoat();
    }
    void GetStartBlock()
    {
        foreach (var block in blocks)
        {
            if (block.TypeBlock == BlockType.Start)
            {
                blockStart = block;
                return;
            }
        }
    }

    void SetUpBoat()
    {
        boat.SetPos(blockStart.transform.position);
        boat.SetRotation(blockStart);
    }

    void Initialization()
    {
        float gridWidth = (Columns - 1) * spacing * 0.5f;
        int index = 0;
        grid = new Block[Rows, Columns];
        for(var r = 0; r < Rows; ++r)
        {
            for(var c = 0; c < Columns; ++c)
            {
                Block b = blocks[index];
                if (b != null)
                {
                    Vector3 pos = new Vector3(c * spacing - gridWidth, 0, r * spacing);
                    b.SetPos(pos);
                    b.GridPos = new Vector2Int(r, c);
                    grid[r, c] = b;
                }
                index++;
                b.name = $"{index}";
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
