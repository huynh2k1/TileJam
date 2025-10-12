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

   
}
