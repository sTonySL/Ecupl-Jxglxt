using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxglxt
{
    class RoomEntry
    {

        #region 非必要参数
      
        //public String OrderBy
        //{
        //    get; set;
        //}
        #endregion

        /// <summary>
        /// 学生类别（本科生=5，研究生未知）
        /// </summary>
        public String StudentTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// 学年的编号
        /// </summary>
        public String CalendarId
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
        /// 校区
        /// </summary>
        public String SchoolDistrict
        {
            get; set;
        }

        /// <summary>
        /// 教学楼
        /// </summary>
        public String BuildingId
        {
            get; set;
        }

        /// <summary>
        /// 院系所
        /// </summary>
        public String DepartId
        {
            get; set;
        }

        /// <summary>
        /// 页数
        /// </summary>
        public String PageNo
        {
            get; set;
        }

        /// <summary>
        /// 每页大小
        /// </summary>
        public String PageSize
        {
            get; set;
        }



}
}
