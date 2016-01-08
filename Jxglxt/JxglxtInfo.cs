using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Jxglxt
{
    class JxglxtInfo
    {
        #region 我的公共变量
        private String StudengTypeId = "";
        private String IgnoreHead = "";
        private String CalendarId = "";
        private String GetCourseUrl = "";
        private String PostFrameUrl = "";
        private HtmlDocument Doc = new HtmlDocument();
        private StreamReader MyStream = null;
        #endregion

        public JxglxtInfo(JxglxtRequest Http) 
        {
            ///先发送一个Get请求获得相关参数
            String GetFrameUrl = "http://222.72.92.106/eams/courseTableForStd.do?method=stdHome";
            //发送Get请求，并用HtmlAgilityPack解析htm
            Doc.LoadHtml(Http.GetRequest(GetFrameUrl));
            StudengTypeId = Doc.DocumentNode.SelectSingleNode("//*[@name='calendar.studentType.id']/option").Attributes["value"].Value;
            IgnoreHead = Doc.DocumentNode.SelectSingleNode("//*[@name='ignoreHead']").Attributes["value"].Value;
            CalendarId = Doc.DocumentNode.SelectSingleNode("//*[@name='calendar.id']").Attributes["value"].Value;
        }



        /// <summary>
        /// 得到课表数据的方法，如果请求当前学期课表，则不需要传递PostData
        /// 如果请求其他学期，则需要传递PostData参数
        /// </summary>
        /// <param name="Http">JxglRequest类</param>
        /// <param name="PostData">请求其他学期的课程表时传递的参数
        /// 参数格式为calendar.year=2014-2015&calendar.term=1&startWeek=1</param>
        /// <returns>返回响应的字符串</returns>
        public String GetMyCourse(JxglxtRequest Http, String PostData = null)
        {
            ///先发送一个Get请求获得相关参数
            String GetFrameUrl = "http://222.72.92.106/eams/courseTableForStd.do?method=stdHome";
            //发送Get请求，并用HtmlAgilityPack解析htm
            Doc.LoadHtml(Http.GetRequest(GetFrameUrl));
            StudengTypeId = Doc.DocumentNode.SelectSingleNode("//*[@name='calendar.studentType.id']/option").Attributes["value"].Value;
            IgnoreHead = Doc.DocumentNode.SelectSingleNode("//*[@name='ignoreHead']").Attributes["value"].Value;
            CalendarId = Doc.DocumentNode.SelectSingleNode("//*[@name='calendar.id']").Attributes["value"].Value;
            //获得得到课表内容的Get请求的Url
            GetCourseUrl = Doc.DocumentNode.SelectSingleNode("//*[@id='contentListFrame']").Attributes["src"].Value.Trim();


            ///如果不传递PostData参数，则认为是第一次请求课程表，即获得最新的课程表
            if (PostData == null)
            {
                //获得得到课表内容的Get请求的Url
                GetCourseUrl = Doc.DocumentNode.SelectSingleNode("//*[@id='contentListFrame']").Attributes["src"].Value.Trim();

                //发送Get请求，获得我的课程的数据。
                return Http.GetRequest("http://222.72.92.106/eams/" + GetCourseUrl);

            }
            //如果PostData不为null，则先发送Post请求再发送Get请求
            else
            {
                //获得得到课表框架的Post请求的Url
                int a = GetCourseUrl.LastIndexOf("&");
                int b = GetCourseUrl.LastIndexOf("ids=") + 4;
                PostFrameUrl = "http://222.72.92.106/eams/courseTableForStd.do?method=stdHome&setting.forCalendar=0&setting.kind=std&ids=" + GetCourseUrl.Substring(b, a - b);

                //构造PostData
                StringBuilder _PostData = new StringBuilder();
                _PostData.Append("calendar.studentType.id=");
                _PostData.Append(StudengTypeId);
                _PostData.Append("&ignoreHead=");
                _PostData.Append(IgnoreHead);
                _PostData.Append("&calendar.id=");
                _PostData.Append(CalendarId);
                _PostData.Append("&");
                _PostData.Append(PostData);

                //发送Post请求
                Doc.LoadHtml(Http.PostRequest(PostFrameUrl, _PostData.ToString()));
                //获得得到课表内容的Get请求的Url
                GetCourseUrl = Doc.DocumentNode.SelectSingleNode("//*[@id='contentListFrame']").Attributes["src"].Value;
                //发送Get请求，获得我的课程的数据。
                MyStream = new StreamReader(Http.GetRequest("http://222.72.92.106/eams/" + GetCourseUrl));
                //return DeleteHref(MyStream.ReadToEnd(),"");
                return MyStream.ReadToEnd();
            }//PostData is not null
        }

        /// <summary>
        /// 发送Get请求，获取我的成绩数据
        /// </summary>
        /// <param name="Http">JxglRequest类</param>
        /// <returns>返回我的成绩的html字符串</returns>
        public String GetMyGrade(JxglxtRequest Http)
        {
            String GetGradeUrl = "http://222.72.92.106/eams/personGrade.do";
            //MyStream = new StreamReader(Http.GetRequest(GetGradeUrl));
            //return MyStream.ReadToEnd();
            return Http.GetRequest(GetGradeUrl);
        }

        /// <summary>
        /// 发送两个Get请求获得我的评教信息
        /// </summary>
        /// <param name="Http"></param>
        /// <returns></returns>
        public String GetMyEvaluation(JxglxtRequest Http)
        {
            String GetFrameUrl = "http://222.72.92.106/eams/evaluateStd.do";
            String GetEvaluationUrl = "";

            ///发送请求，获得评教页面的框架，从框架中获得关键Url
            Doc.LoadHtml(Http.GetRequest(GetFrameUrl));
            GetEvaluationUrl = "http://222.72.92.106/eams/" + Doc.DocumentNode.SelectSingleNode("//*[@id='examTableFrame']").Attributes["src"].Value;

            //发送Get请求，获得评教相关的数据
            //MyStream=new StreamReader(Http.GetRequest(GetEvaluationUrl));

            //return DeleteHref(MyStream.ReadToEnd(),"");
            return Http.GetRequest(GetEvaluationUrl);

        }

        /// <summary>
        /// 发送Post请求，查询全校课程
        /// </summary>
        /// <param name="CourseInfo">全校课程的实体，主要是查询的参数</param>
        /// <returns></returns>
        public String QueryCourse(JxglxtRequest Http,CourseEntry CourseInfo)
        {
            String QueryCourseUrl = "http://222.72.92.106/eams/teachTaskSearch.do?method=arrangeInfoList";

            StringBuilder PostData = new StringBuilder();
            PostData.Append(CourseInfo.PageNo);
            PostData.Append(CourseInfo.CalendarId);
            //PostData.Append(CourseInfo.ArrangeFormat);
            PostData.Append(CourseInfo.CalendarTerm);
            PostData.Append(CourseInfo.PageSize);
            //PostData.Append(CourseInfo.StudentTypeId);
            PostData.Append(CourseInfo.TaskArrangeInfoId);
            //PostData.Append(CourseInfo.TaskCalendarId);
            PostData.Append(CourseInfo.TaskCourseCode);
            PostData.Append(CourseInfo.TaskCourseName);
            PostData.Append(CourseInfo.TaskCourseTypeName);
            PostData.Append(CourseInfo.TaskEnrollTurn);
            PostData.Append(CourseInfo.TaskSeqNo);
            PostData.Append(CourseInfo.TaskStdTypeId);
            PostData.Append(CourseInfo.TaskTeachClassId);
            PostData.Append(CourseInfo.TeacherDepartmentId);
            PostData.Append(CourseInfo.TeacherName);
            PostData.Append(CourseInfo.TimeStartUnit);
            PostData.Append(CourseInfo.TimeWeek);

            MyStream = new StreamReader(Http.PostRequest(QueryCourseUrl, PostData.ToString()));
            return MyStream.ReadToEnd();
        }

        /// <summary>
        /// 发送Post请求，查询教室占用信息
        /// </summary>
        /// <param name="RoomInfo"></param>
        /// <returns></returns>
        public String QueryRoom(JxglxtRequest Http,RoomEntry RoomInfo)
        {
            String QueryRoomUrl = "http://222.72.92.106/eams/roomResource.do?method=search";
            StringBuilder PostData = new StringBuilder();
            PostData.Append(RoomInfo.BuildingId);
            PostData.Append(RoomInfo.CalendarId);
            PostData.Append(RoomInfo.CalendarTerm);
            PostData.Append(RoomInfo.CalendarYear);
            PostData.Append(RoomInfo.DepartId);
            //PostData.Append(RoomInfo.OrderBy);
            PostData.Append(RoomInfo.PageNo);
            PostData.Append(RoomInfo.PageSize);
            PostData.Append(RoomInfo.RoomConfigType);
            PostData.Append(RoomInfo.RoomName);
            PostData.Append(RoomInfo.SchoolDistrict);
            //PostData.Append(RoomInfo.StudentTypeId);

            MyStream = new StreamReader(Http.PostRequest(QueryRoomUrl, PostData.ToString()));
            return MyStream.ReadToEnd();


        }

        /// <summary>
        /// 得到学业预警信息
        /// </summary>
        /// <param name="Http"></param>
        /// <param name="UserNumber"></param>
        /// <returns></returns>
        public String GetAlertInfo(JxglxtRequest Http, String UserNumber)
        {
            Regex rex = new Regex("^[0-9]{11}$");
            if (rex.IsMatch(UserNumber))
            {
                String Url = "http://eval.ecupl.edu.cn/studentIndexWarning/" + UserNumber;
                Doc.LoadHtml(Http.GetRequest(Url));
                return Doc.DocumentNode.SelectSingleNode("//*[@id='sw']").InnerHtml;
            }
            else
            {
                return "";
            }

        }

        ///// <summary>
        ///// 删除html中所有超链接，但保留内容
        ///// </summary>
        ///// <param name="Html"></param>
        ///// <returns></returns>
        //private String DeleteHref(String Html,String Xpath)
        //{

        //    Doc.LoadHtml(Html);
        //    var aa = Doc.DocumentNode.SelectNodes(Xpath);

        //    return Html;
        //}
    }
}
