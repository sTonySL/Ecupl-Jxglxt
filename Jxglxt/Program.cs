using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jxglxt
{
    class Program
    {
        //内网：http://192.168.100.54/eams/index.do?isShowLogin=true
        //外网：http://222.72.92.106/eams/index.do?isShowLogin=true
        static void Main(string[] args)
        {
            String CookieGetUrl = "http://222.72.92.106/eams/index.do?isShowLogin=true";
            String LoginPostUrl = "http://222.72.92.106/eams/login.do";
            String LoginPostData = "name=12042201028&isShowLogin=true&password=sw123456&lang=chinese";
            String HomePageGetUrl = "http://222.72.92.106/eams/defaultHome.do?method=welcome";
            String PersonGradeGetUrl = "http://222.72.92.106/eams/personGrade.do";
            String PersonCourseGetUrl = "http://222.72.92.106/eams/courseTableForStd.do?method=stdHome";
            String CourseSearchPostUrl = "http://222.72.92.106/eams/teachTaskSearch.do?method=arrangeInfoList";
            String RoomSearchPostUrl = "http://222.72.92.106/eams/roomResource.do?method=search";
            String ContentType = "application/x-www-form-urlencoded";
            JxglxtRequest Http = new JxglxtRequest(); 
            CourseEntry Ce = new CourseEntry();
            RoomEntry Re = new RoomEntry();
            //发送Post请求，传递用户认证信息
            var aa = Http.LoginJxglxt(LoginPostUrl, LoginPostData);
            String str = "pageNo=1&pageSize=1&calendar.id=341&calendar.studentType.id=5&calendar.term=1&task.seqNo=&task.course.code=&task.course.name=&task.courseType.name=&task.teachClass.depart.id=&task.arrangeInfo.teachDepart.id=&teacher.name=&teacher.department.id=&task.teachClass.enrollTurn=&task.teachClass.stdType.id=&courseActivity.time.week=&courseActivity.time.startUnit=";
            var bb = Http.PostRequest("http://222.72.92.106/eams/teachTaskSearch.do?method=arrangeInfoList", str);
            var cc = Http.GetRequest("http://222.72.92.106/eams/courseTableForStd.do?method=stdHome");
            JxglxtInfo Info = new JxglxtInfo();
            var dd= Info.GetMyCourse(Http);

            Http.Close();
        }
    }
}
