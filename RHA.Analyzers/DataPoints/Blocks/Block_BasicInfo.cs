using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHA.Analyzers.DataPoints.Blocks
{
    public class Block_BasicInfo
    {
        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Block_BasicInfo()
        {
            this.Id = null;
            this.Data = null;
            this.Name = string.Empty;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="block">The BlockBasicInfo object to copy from.</param>
        public Block_BasicInfo(Block_BasicInfo Block)
        {
            this.Id = Block.Id;
            this.Data = Block.Data;
            this.Name = Block.Name;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        public Block_BasicInfo(int Id)
        {
            this.Id     = Id;
            this.Data   = null;
            this.Name   = string.Empty;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Name">The name of this block.</param>
        public Block_BasicInfo(int Id, string Name)
        {
            this.Id     = Id;
            this.Data   = null;
            this.Name   = Name;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        public Block_BasicInfo(int Id, int Data)
        {
            this.Id     = Id;
            this.Data   = Data;
            this.Name   = string.Empty;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id">The block Id.</param>
        /// <param name="Data">The block's data value.</param>
        /// <param name="Name">The name of this block.</param>
        public Block_BasicInfo(int Id, int Data, string Name)
        {
            this.Id     = Id;
            this.Data   = Data;
            this.Name   = Name;
        }
        #endregion

        /// <summary>
        /// This block's ID.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// The block's data value.
        /// </summary>
        public int? Data { get; set; }
        /// <summary>
        /// The name of this block.
        /// </summary>
        public string Name;

    }
}
