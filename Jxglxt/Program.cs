﻿using System;
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
            JxglxtInfo js = new JxglxtInfo();
            CourseEntry Ce = new CourseEntry();


            //发送Post请求，传递用户认证信息
            var aa = Http.LoginJxglxt(LoginPostUrl, LoginPostData);

            var bb = js.GetMyEvaluation(Http);



            Http.Close();
        }
}