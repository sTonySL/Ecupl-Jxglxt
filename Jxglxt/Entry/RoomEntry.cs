using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxglxt
{
    class RoomEntry
    {
        /// <summary>
        /// 学年的编号
        /// </summary>
        public String CalendarId
        {
            get; set;
        }

        /// <summary>
        /// 未知
        /// </summary>
        public String StudentTypeId
        {
            get; set;
        }

        /// <summary>
        /// 学年
        /// </summary>
        public String CalendarYear
        {
            get; set;
        }

        /// <summary>
        /// 学期
        /// </summary>
        public String CalendarTerm
        {
            get; set;
        }

        /// <summary>
        /// 教室名称
        /// </summary>
        public String RoomName
        {
            get; set;
        }

        /// <summary>
        /// 教室设备配置
        /// </summary>
        public String RoomConfigType
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public String SchoolDistrict
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public String BuildingId
        {
            get; set;
        }

        public String DepartId
        {
            get; set;
        }

        public String PageNo
        {
            get; set;
        }

        public String PageSize
        {
            get; set;
        }

        public String OrderBy
        {
            get; set;
        }

}
}
