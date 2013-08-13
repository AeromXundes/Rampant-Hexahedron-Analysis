using RHA.Analyzers.DataPoints.Blocks;

namespace RHA.Analyzers.BlockTypeCount
{
    public class BlockTypeCountDataPoint : Block_BasicInfo
    {
        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlockTypeCountDataPoint()
            : base()
        {
            this.Count = 0;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="Block"></param>
        public BlockTypeCountDataPoint(Block_BasicInfo Block)
            : base(Block)
        {
            this.Count = 0;
        }
        public BlockTypeCountDataPoint(Block_BasicInfo Block, long Count)
            : base(Block)
        {
            this.Count = Count;
        }
        public BlockTypeCountDataPoint(BlockTypeCountDataPoint Block)
            : base((Block_BasicInfo)Block)
        {
            this.Count = Block.Count;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        public BlockTypeCountDataPoint(int Id, int Data)
            : base(Id, Data)
        {
            this.Count = 0;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Count">Count of this block type.</param>
        public BlockTypeCountDataPoint(int Id, int Data, long Count)
            : base(Id, Data)
        {
            this.Count = Count;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Name">The name of this block.</param>
        public BlockTypeCountDataPoint(int Id, int Data, string Name)
            : base(Id, Data, Name)
        {
            this.Count = 0;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Name">The name of this block.</param>
        /// <param name="Count">Count of this block type.</param>
        public BlockTypeCountDataPoint(int Id, int Data, string Name, long Count)
            : base(Id, Data, Name)
        {
            this.Count = Count;
        }
        #endregion

        /// <summary>
        /// Count of this block type.
        /// </summary>
        public long Count { get; set; }
    }
}
