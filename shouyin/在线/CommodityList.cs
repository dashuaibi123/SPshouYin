using System;
using System.Collections.Generic;
using System.Text;

namespace shouyin.在线
{
    class CommodityList
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int commodity_id { get; set; }
        /// <summary>
        /// 粑粑
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int stock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }

        public string stockp { get; set; }//库存单位
        public string Purchase_price { get; set; }//进价
    }
}
