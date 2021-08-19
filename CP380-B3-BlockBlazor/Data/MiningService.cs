using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;

namespace CP380_B3_BlockBlazor.Data
{
    public class MiningService
    {
        private readonly BlockService BS;
        private readonly PendingTransactionService PT;
        public IEnumerable<Block> tmpBlockList { get; set; }
        public IEnumerable<Payload> tmpPayloadList { get; set; }

        public MiningService(BlockService blockService, PendingTransactionService pendingTransactionService)
        {
            BS = blockService;
            PT = pendingTransactionService;
        }

        public async Task<Block> MineBlock()
        {

            tmpBlockList = await BS.GetBlocksAsync();
            tmpPayloadList = await PT.GetPayloadsAsync();

            var block = new Block(DateTime.Now, tmpBlockList.Select(b => b.PreviousHash).Last(), tmpPayloadList.ToList());

            block.Mine(2);

            return block;

        }
    }
}
