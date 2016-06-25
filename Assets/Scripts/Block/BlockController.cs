using UnityEngine;
using System.Collections.Generic;

public class BlockController : MonoBehaviour {

    List<Block> availableBlocks;

    void Start()
    {
        if (availableBlocks.Count > 0)
        {
            for(int i=0; i < availableBlocks.Count; i++)
            {
                Block availableBlock = availableBlocks[i];
                availableBlock.OnBlockDestroyed += BlockWasDestroyed;
            }
        }
    }

    private void BlockWasDestroyed(Block block)
    {
        Toolbox.GameControl.AddScore(block.AddedScore);
    }
}
