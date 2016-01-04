using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxglxt
{
    
    class CourseEntry
    {
        /// <summary>
        /// 页数（第几页）
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

        /// <summary>
        /// 未知（值固定）
        /// </summary>
        public String OrderBy
        {
            get; set;
        }

        /// <summary>
        /// 学年的代号（2015-2016学期用341表示）
        /// </summary>
        public String TaskCalendarId
        {
            get; set;
        }

        /// <summary>
        /// 教学日历类别 “:teacher2 :day :units :weeks :room”
        /// 值固定
        /// </summary>
        public String ArrangeFormat
        {
            get; set;
        }

        /// <summary>
        /// 同TaskCalendarId
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
        /// 学期（1，2）
        /// </summary>
        public String CalendarTerm
        {
            get; set;
        }

        /// <summary>
        /// 课程编号
        /// </summary>
        public String TaskSeqNo
        {
            get; set;
        }
        
        /// <summary>
        /// 课程代码
        /// </summary>
        public String TaskCourseCode
        {
            get; set;
        }
        
        /// <summary>
        /// 课程名称
        /// </summary>
        public String TaskCourseName
        {
            get; set;
        }

        /// <summary>
        /// 课程类别
        /// </summary>
        public String TaskCourseTypeName
        {
            get; set;
        }

        /// <summary>
        /// 上课院系
        /// （全部，法律学院，国际法学院，国际航运法律学院，国际交流学院，国际金融法律学院，经济法学院，科学研究院，律师学院，马克思主义学院，其他（职能部门），人文学院，商学院，社会发展学院，社会管理综合治理研究院，体育部，团委，外语学院，心理健康与职业发展教研室，信息科学与技术系，刑事司法学院，政治学与公共管理学院，知识产权学院）
        /// </summary>
        public String TaskTeachClassId
        {
            get; set;
        }

        /// <summary>
        /// 开课院系
        /// </summary>
        public String TaskArrangeInfoId
        {
            get; set;
        }

        /// <summary>
        /// 教师
        /// </summary>
        public String TeacherName
        {
            get; set;
        }
        
        /// <summary>
        /// 教师院系
        /// </summary>
        public String TeacherDepartmentId
        {
            get; set;
        }
        
        /// <summary>
        /// 所在年级
        /// </summary>
        public String TaskEnrollTurn
        {
            get; set;
        }
        
        /// <summary>
        /// 学生类别（全部，本科生）
        /// </summary>
        public String TaskStdTypeId
        {
            get; set;
        }
        
        /// <summary>
        /// 星期（全部，星期一——星期日）
        /// </summary>
        public String TimeWeek
        {
            get; set;
        }
        
        /// <summary>
        /// 小节（全部，1——14）
        /// </summary>
        public String TimeStartUnit
        {
            get; set;
        }

        
    }

}
