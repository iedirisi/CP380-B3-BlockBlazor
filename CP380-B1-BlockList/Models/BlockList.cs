﻿using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            block.PreviousHash = Chain[Chain.Count - 1].Hash;
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public bool IsValid()
        {
            // TODO
         bool valid = true;
           
            for (var x=1; x < Chain.Count; x++)
            {
                if (Chain[x].PreviousHash != Chain[x - 1].Hash || !Chain[x].Hash.StartsWith("C"))
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }
    }
}
