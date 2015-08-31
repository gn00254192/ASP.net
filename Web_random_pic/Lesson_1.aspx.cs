using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson_1 : System.Web.UI.Page
{
    int k = 1;
    int temp = 0;
    string[] Pic_url = { "https://photos-1.dropbox.com/t/2/AADcsIGkOlsIH1Olu0LyjJ-KgpqiApCPjdcqBy2FfEc-7A/12/36943375/jpeg/32x32/1/_/1/2/1416406068.JPEG/ENiPjRwYmjwgAigC/R50dVM-DomOvQ1sN7Sv2X27FY7I17FGIgA_upgnwsPM?size=1024x768&size_mode=2",
                             "https://photos-6.dropbox.com/t/2/AABDEPMgl5wx2-pi2RoeM2RxWcap7S-BDWI6cz0FdKm0pg/12/36943375/jpeg/32x32/1/_/1/2/1416406425.JPEG/ENiPjRwYmjwgAigC/7mcP9PyuhR-QBtBXl5xeuBbYE69nsMib7Wh1zdOWjmg?size=1024x768&size_mode=2",
                             "https://photos-4.dropbox.com/t/2/AABDIceorvq-3Hy9HpGWiSqQH9I9imcGVPKtqMV6gFwPBw/12/36943375/jpeg/32x32/1/_/1/2/1416406511.JPEG/ENiPjRwYmjwgAigC/0fXhXcthHng4a4Z5bH9DCH7Z9C7NIylxE2tRMue0Knc?size=1024x768&size_mode=2",
                             "https://photos-5.dropbox.com/t/2/AAB7iK_3Uxvxx0HQBQC5zwHJh3HV6uPykoQxp6Rv-atLRA/12/36943375/jpeg/32x32/1/_/1/2/1416406314.JPEG/ENiPjRwYmjwgAigC/2HnCFw8QjzkiVGBxjxX8HsDxqkKMkKQYbB6m88-la9E?size=1024x768&size_mode=2",
                             "https://photos-4.dropbox.com/t/2/AADuHsr8pux1toOM4fEy6XeBenas4mhSWWC6P2quxdZ6SA/12/36943375/jpeg/32x32/1/_/1/2/1416405907.JPEG/ENiPjRwYmjwgAigC/2Zi2Tsbg1vhFNgoPp645Q5drSOLqOXDMcdJBJxaNNKM?size=1024x768&size_mode=2",
                             "https://photos-6.dropbox.com/t/2/AABQGEloZk7u9W9R5hlDFcQZu8n1JqRkfbbEFTFxdTgaZw/12/36943375/jpeg/32x32/1/_/1/2/1416405821.JPEG/ENiPjRwYmjwgAigC/Oqg7J29-6KlL8XSsrjiFDEmgZeK7yMx34981IsMofnE?size=1024x768&size_mode=2",
                             "https://photos-3.dropbox.com/t/2/AACIrOAIFKjdZ92GP1YLorXOl-FsVWHVoboxiX56SXNeew/12/36943375/jpeg/32x32/1/_/1/2/1416405531.JPEG/ENiPjRwYmjwgAigC/HGRC_3qBuiboy1Ho-nIbYeOUnfSQc3qm7KJhm3TBnIg?size=1024x768&size_mode=2",
                             "https://photos-4.dropbox.com/t/2/AAA35rh8DWHMLsIPk2VzKlbAlbtGpqMbaTZL_M1UtyTHFA/12/36943375/jpeg/32x32/1/_/1/2/1416406750.JPEG/ENiPjRwYmjwgAigC/snZaBHWIWvrHR1D7e3MEZug6e78Tm1WArOCv4B8NzmM?size=1024x768&size_mode=2"};
    string[] Pic_ID = {  "1416406068",
                         "1416406425",
                         "1416406511",
                         "1416406314",
                         "1416405907",
                         "1416405821",
                         "1416405531",
                         "1416406750"};
    int[] rand2 = new int[8];
    int[] result2 = new int[8];
    //用于存放1到9这9个数     
    int[] random_num = new int[8];
    //用于保存返回结果     
    int[] result = new int[8];
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：左圖為受測者要評分圖片，右圖為標準圖，標準圖分數為10分，如左圖畫的接近標準圖，請給予高分；反之，請給予低分，滿分為10分</H2>");
        Response.Write("<H2>請輸入分數:(左圖:評分圖片;右圖:標準圖)</H2>");

        if (!IsPostBack)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("rand_num");
            HttpCookie cookie_k = new HttpCookie("k");
            HttpCookie cookie_temp = new HttpCookie("temp");
            //設定單值
            cookie_k.Value = Server.UrlEncode(k.ToString());
            //設定過期日
            cookie_k.Expires = DateTime.Now.AddHours(1);
            //寫到用戶端
            Response.Cookies.Add(cookie_k);


            cookie_temp.Value = Server.UrlEncode(k.ToString());
            //設定過期日
            cookie_temp.Expires = DateTime.Now.AddHours(1);
            //寫到用戶端
            Response.Cookies.Add(cookie_temp);


            string r = "";
            Random random = new Random();
            for (int i = 0; i <= 7; i++)
            {
                random_num[i] = i;
            }



            int index = 0;
            int value = 0;
            for (int i = 0; i < 6; i++)
            {
                //从[1,container.Count + 1)中取一个随机值，保证这个值不会超过container的元素个数     
                index = random.Next(0, random_num.Length - 1 - i);
                //以随机生成的值作为索引取container中的值     
                value = random_num[index];
                //将随机取得值的放到结果集合中     
                result[i] = value;
                //将刚刚使用到的从容器集合中移到末尾去     
                random_num[index] = random_num[random_num.Length - i - 1];
                //将队列对应的值移到队列中     
                random_num[random_num.Length - i - 1] = value;
            }
            for (int i = 0; i < random_num.Length; i++)
            {
                if (i < 7)
                    r += random_num[i] + ",";
                else
                    r += random_num[i];
            }
            for (int i = 0; i < 8; i++)
            {
                Response.Write("a:" + random_num[i]);  //random數字放入陣列
            }
            //Response.Cookies.Add("randnum", r);
            //設定單值
            cookie.Value = Server.UrlEncode(r);
            //設定過期日
            cookie.Expires = DateTime.Now.AddHours(1);
            //寫到用戶端
            Response.Cookies.Add(cookie);

            Image2.ImageUrl = Pic_url[random_num[0]];//random show picture
            Response.Write("Pic_url:" + random_num[0]);
            Image3.ImageUrl = "https://photos-5.dropbox.com/t/2/AACQhi4UHdQgERxiA6ybVrI6ZGhLtYyzTUfZ4yPd2_ED6w/12/36943375/png/32x32/1/_/1/2/face.png/ENiPjRwY_DwgAigC/1IcSgbn94OVp2ONmyfY8LRBTFawGI61HO1lQRQe_GhY?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(450);
            Image3.Width = Unit.Pixel(450);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["rand_num"];
        HttpCookie cookie_k = Request.Cookies["k"];
        HttpCookie cookie_temp = Request.Cookies["temp"];
        string r = Server.UrlDecode(cookie.Value);
        string[] rand_r = r.Split(',');
        int k = int.Parse(Server.UrlDecode(cookie_k.Value));
        int temp = int.Parse(Server.UrlDecode(cookie_temp.Value));
        for (int i = 0; i < 8; i++)
        {
            random_num[i] = int.Parse(rand_r[i]);
            Response.Write("b:" + random_num[i]);  //random數字放入陣列
        }

        if (k != 8 && temp != 0)
        {
            SqlConnection conn3 = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn3.Open();
            SqlCommand cmd3 = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(1," + int.Parse(Pic_ID[random_num[k - 1]]) + ",@paramScore)", conn3);
            cmd3.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();
            conn3.Close();
            conn3.Dispose();


            Image2.ImageUrl = Pic_url[random_num[k]];//random show picture
            Image3.ImageUrl = "https://photos-5.dropbox.com/t/2/AACQhi4UHdQgERxiA6ybVrI6ZGhLtYyzTUfZ4yPd2_ED6w/12/36943375/png/32x32/1/_/1/2/face.png/ENiPjRwY_DwgAigC/1IcSgbn94OVp2ONmyfY8LRBTFawGI61HO1lQRQe_GhY?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(450);
            Image3.Width = Unit.Pixel(450);



            k = k + 1;
        }
        else if (k == 8)
        {
            SqlConnection conn2 = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(1," + int.Parse(Pic_ID[random_num[7]]) + ",@paramScore)", conn2);
            cmd2.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            conn2.Close();
            conn2.Dispose();
            Response.Write(k);
            Response.Redirect("Lesson2_firstPage.aspx");

        }

        if (temp == 0)
        {
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(1," + int.Parse(Pic_ID[random_num[0]]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            Image2.ImageUrl = Pic_url[random_num[k]];//random show picture
            Image3.ImageUrl = "https://photos-5.dropbox.com/t/2/AACQhi4UHdQgERxiA6ybVrI6ZGhLtYyzTUfZ4yPd2_ED6w/12/36943375/png/32x32/1/_/1/2/face.png/ENiPjRwY_DwgAigC/1IcSgbn94OVp2ONmyfY8LRBTFawGI61HO1lQRQe_GhY?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(450);
            Image3.Width = Unit.Pixel(450);


            temp = temp + 1;
            k = k + 1;
        }
        cookie_k = new HttpCookie("k");
        //設定單值
        cookie_k.Value = Server.UrlEncode(k.ToString());
        //設定過期日
        cookie_k.Expires = DateTime.Now.AddHours(1);
        //寫到用戶端
        Response.Cookies.Add(cookie_k);



        cookie_temp = new HttpCookie("temp");
        //設定單值
        cookie_temp.Value = Server.UrlEncode(temp.ToString());
        //設定過期日
        cookie_temp.Expires = DateTime.Now.AddHours(1);
        //寫到用戶端
        Response.Cookies.Add(cookie_temp);

        txtInput.Text = "";
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}