using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBlocks : MonoBehaviour
{
    public static SwapBlocks I;
    [SerializeField] Block block1;
    [SerializeField] Block block2;

    private void Awake()
    {
        I = this;
    }

    public void SelectBlock(Block b)
    {
        if(block1 == null)
        {
            block1 = b;
            block1.Select();
        }
        else if (block1 == b)
        {
            block1.UnSelect();
            block1 = null;
        }
        else if(block2 == null)
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
        var temp1 = b1.CurPos + Vector3.up / 2;
        var temp2 = b2.CurPos;
        b1.SetNewPos(temp2, () =>
        {
            b1.CurPos = temp2;
        });
        b2.SetNewPos(temp1, () =>
        {
            b2.UnSelect();
            this.block1 = null;
            this.block2 = null;
        });

    }
}
