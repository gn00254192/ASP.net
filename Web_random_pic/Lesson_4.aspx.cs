using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson_4 : System.Web.UI.Page
{
    int k = 1;
    int temp = 0;
    string[] Pic_url = { "https://photos-4.dropbox.com/t/2/AACVt3RuZHqPcMDWvkyEsyZ2nSkeqGALyyFzZbF3HS1kZQ/12/36943375/jpeg/32x32/1/_/1/2/1416496275.JPEG/ENiPjRwYmjwgAigC/okHz4SIKeSBajcHCavUUX3MPghzoSRebvtd2cr-Mel0?size=1024x768&size_mode=2",
                         "https://photos-2.dropbox.com/t/2/AAAIkGYn90-MsG3DHYnT3vtcGKRp0SXYy1ulzRrexzMKkg/12/36943375/jpeg/32x32/1/_/1/2/1416495475.JPEG/ENiPjRwYmjwgAigC/VwtKEI3pyyrkKhe1aYb0EB9t_1G249p5ekHXM4lRSRI?size=1024x768&size_mode=2",
                         "https://photos-3.dropbox.com/t/2/AACpMtfwlgPHy2TUNiCTwsHtexxeLibnVPPDH8BhmjM2pg/12/36943375/jpeg/32x32/1/_/1/2/1416495446.JPEG/ENiPjRwYmjwgAigC/c0XKxwUXo9X7Gu4dwpwDeAlQtjyqhCSOlu7ggv4SIrk?size=1024x768&size_mode=2",
                         "https://photos-2.dropbox.com/t/2/AADgP8PFEn82fCgvCdQBdMZ0arv83fRWUh2MTRxRR9tvHg/12/36943375/jpeg/32x32/1/_/1/2/1416495744.JPEG/ENiPjRwYmjwgAigC/zb2geeOepi51RSL45X55WlYbaUWh2Y4WurRrILEcrZc?size=1024x768&size_mode=2",
                         "https://photos-6.dropbox.com/t/2/AADIbhxDuEHNdBJ1UWcmnmV-WYmtNiE2-MV7CsJhZC74TQ/12/36943375/jpeg/32x32/1/_/1/2/1416495833.JPEG/ENiPjRwYmjwgAigC/RvGj-1dcjqjeUG8Dwy6sCnVFdzMaXD6m4Q2j3x1L-10?size=1024x768&size_mode=2",
                         "https://photos-2.dropbox.com/t/2/AABE8TbNWrfXigbfC60Fh1wbdF4qfPfjgQK0ujGgMk0q7g/12/36943375/jpeg/32x32/1/_/1/2/1416495507.JPEG/ENiPjRwYmjwgAigC/03uUag-UxP_dId5co31WIS5itvKBO8G_EUVB_nCboWI?size=1024x768&size_mode=2",
                         "https://photos-3.dropbox.com/t/2/AAAkmhxtd26dw28lHdMDKbh6ZDAKs9Sycl6jL64pe75SkQ/12/36943375/jpeg/32x32/1/_/1/2/1416495604.JPEG/ENiPjRwYmjwgAigC/dD8qDOiO_brasuhb77vJu-5cdMK61HJntrAz1I30UJg?size=1024x768&size_mode=2",
                         "https://photos-2.dropbox.com/t/2/AAA6RWzfHUqcly3McZwluHe2uM5dFwTwbgqpgIiGlJ-09A/12/36943375/jpeg/32x32/1/_/1/2/1416495894.JPEG/ENiPjRwYmjwgAigC/7rlDGcc_pVcnhc2SorwxeqChZoXZs5_k9RoxRtWUTN8?size=1024x768&size_mode=2"};
    string[] Pic_ID = {  "1416496275",
                         "1416495475",
                         "1416495446",
                         "1416495744",
                         "1416495833",
                         "1416495507",
                         "1416495604",
                         "1416495894"};
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
            Image3.ImageUrl = "https://photos-5.dropbox.com/t/2/AACISUAmUSxy3ubLQpgKQ0C-vTs8AfDvTIUV_VULGS8TJQ/12/36943375/png/32x32/1/_/1/2/cube.png/ENiPjRwY_DwgAigC/skIS5JsVae7Hv1p0ZhTRbfcBXZ4YmiwzVSdqW0UOUz8?size=1024x768&size_mode=2";
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
            SqlCommand cmd3 = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(4," + int.Parse(Pic_ID[random_num[k - 1]]) + ",@paramScore)", conn3);
            cmd3.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();
            conn3.Close();
            conn3.Dispose();


            Image2.ImageUrl = Pic_url[random_num[k]];//random show picture
            Image3.ImageUrl = "https://photos-5.dropbox.com/t/2/AACISUAmUSxy3ubLQpgKQ0C-vTs8AfDvTIUV_VULGS8TJQ/12/36943375/png/32x32/1/_/1/2/cube.png/ENiPjRwY_DwgAigC/skIS5JsVae7Hv1p0ZhTRbfcBXZ4YmiwzVSdqW0UOUz8?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(450);
            Image3.Width = Unit.Pixel(450);



            k = k + 1;
        }
        else if (k == 8)
        {
            SqlConnection conn2 = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(4," + int.Parse(Pic_ID[random_num[7]]) + ",@paramScore)", conn2);
            cmd2.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            conn2.Close();
            conn2.Dispose();
            Response.Write(k);
            Response.Redirect("Lesson5_firstPage.aspx");

        }

        if (temp == 0)
        {
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(4," + int.Parse(Pic_ID[random_num[0]]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            Image2.ImageUrl = Pic_url[random_num[k]];//random show picture
            Image3.ImageUrl = "https://photos-5.dropbox.com/t/2/AACISUAmUSxy3ubLQpgKQ0C-vTs8AfDvTIUV_VULGS8TJQ/12/36943375/png/32x32/1/_/1/2/cube.png/ENiPjRwY_DwgAigC/skIS5JsVae7Hv1p0ZhTRbfcBXZ4YmiwzVSdqW0UOUz8?size=1024x768&size_mode=2";
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