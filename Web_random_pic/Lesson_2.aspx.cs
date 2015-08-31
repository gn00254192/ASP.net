using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson_2 : System.Web.UI.Page
{
    int k = 1;
    int temp = 0;
    string[] Pic_url = { "https://photos-5.dropbox.com/t/2/AAC7wPhrQ1v2m2D7iBOuQ9ArAp_50USrZIB6GOr_UlH-mg/12/36943375/jpeg/32x32/1/_/1/2/1415792402.JPEG/ENiPjRwYmjwgAigC/Vo2AsKqAYPHDxKZj-z52b-BoQfLkhS2P51QijOcJkDc?size=1024x768&size_mode=2",
                             "https://photos-1.dropbox.com/t/2/AAA5f2Jz2174twnoX25XJJNc7zWYh48J_5lpNWBTfvw9hw/12/36943375/jpeg/32x32/1/_/1/2/1415792541.JPEG/ENiPjRwYmjwgAigC/pMv9DsSDn8jtCcUP0UuMMbuj4sEL4iVt6HYnFFxNBgw?size=1024x768&size_mode=2",
                             "https://photos-1.dropbox.com/t/2/AACKhuGZWxvGwSjd0ihDkjNcOA4rNRgDqK_NR21FHxt5bA/12/36943375/jpeg/32x32/1/_/1/2/1415792331.JPEG/ENiPjRwYmjwgAigC/rpKDHrDgZQoivpnSurKuhD5t7uWCl8_EOIveq2NynI0?size=1024x768&size_mode=2",
                             "https://photos-4.dropbox.com/t/2/AAC_mocdHBt8SYv7Kb-KsZ_XsZmL5iIeubNZS3BqMpjYzw/12/36943375/jpeg/32x32/1/_/1/2/1415792470.JPEG/ENiPjRwYmjwgAigC/4skjdL3TA61YlGUktJ5BL1cEmphdtwjh8aPlngmTFJI?size=1024x768&size_mode=2",
                             "https://photos-1.dropbox.com/t/2/AAD7ADrHcGAlvk_O5kSeHi4-7ugLZC30JeYVrDu2F2XEQA/12/36943375/jpeg/32x32/1/_/1/2/1415795272_1.JPEG/ENiPjRwYmjwgAigC/AsHHCtWLKKKiDdqxdRdn780zOs_hmtI-dEPFS-7SzBI?size=1024x768&size_mode=2",
                             "https://photos-5.dropbox.com/t/2/AADRhNo4QrsyShA0LT1NPlegmk7C3UiRwALgQw7t3Gp_Hw/12/36943375/jpeg/32x32/1/_/1/2/1415792556.JPEG/ENiPjRwYmjwgAigC/438XTG-T-ySKX8OO8FQBFAi8N24BTx_A0PmpuEZfmno?size=1024x768&size_mode=2",
                             "https://photos-1.dropbox.com/t/2/AAC9ijnH2rv4j1Ewpg0NjAreHzZxKcK8UeSj9YeYisgBdw/12/36943375/jpeg/32x32/1/_/1/2/1415792505.JPEG/ENiPjRwYmjwgAigC/kQK14o2yjDE9Q6YNcbolG8KlgQ__rInUsh13tonBqDA?size=1024x768&size_mode=2",
                             "https://photos-5.dropbox.com/t/2/AAD9v2Gs4hVy1ECTfsAkuQ_3p5pyfGU17Ov-cXj71tdzew/12/36943375/jpeg/32x32/1/_/1/2/1415792366.JPEG/ENiPjRwYmjwgAigC/cHoK6GhHD_TYc7FaegW6LN-XICO7Dk3nlrom1ClDzmE?size=1024x768&size_mode=2"};
    string[] Pic_ID = {  "1415792402",
                         "1415792541",
                         "1415792331",
                         "1415792470",
                         "1415795272",
                         "1415792556",
                         "1415792505",
                         "1415792366"};
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
            Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AADgptszT1RCq01MlsJogtIvg5unN5J82veMJjs0Ti3WKg/12/36943375/jpeg/32x32/1/_/1/2/orignal.jpg/ENiPjRwYmjwgAigC/EW6UFkgM1gtEmmgvkOTJvLzvr8MmdhGSQ93EX-AESeg?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(400);
            Image3.Width = Unit.Pixel(400);
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
            SqlCommand cmd3 = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(2," + int.Parse(Pic_ID[random_num[k - 1]]) + ",@paramScore)", conn3);
            cmd3.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();
            conn3.Close();
            conn3.Dispose();


            Image2.ImageUrl = Pic_url[random_num[k]];//random show picture
            Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AADgptszT1RCq01MlsJogtIvg5unN5J82veMJjs0Ti3WKg/12/36943375/jpeg/32x32/1/_/1/2/orignal.jpg/ENiPjRwYmjwgAigC/EW6UFkgM1gtEmmgvkOTJvLzvr8MmdhGSQ93EX-AESeg?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(400);
            Image3.Width = Unit.Pixel(400);



            k = k + 1;
        }
        else if (k == 8)
        {
            SqlConnection conn2 = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(2," + int.Parse(Pic_ID[random_num[7]]) + ",@paramScore)", conn2);
            cmd2.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            conn2.Close();
            conn2.Dispose();
            Response.Write(k);
            Response.Redirect("Lesson3_firstPage.aspx");

        }

        if (temp == 0)
        {
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(2," + int.Parse(Pic_ID[random_num[0]]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            Image2.ImageUrl = Pic_url[random_num[k]];//random show picture
            Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AADgptszT1RCq01MlsJogtIvg5unN5J82veMJjs0Ti3WKg/12/36943375/jpeg/32x32/1/_/1/2/orignal.jpg/ENiPjRwYmjwgAigC/EW6UFkgM1gtEmmgvkOTJvLzvr8MmdhGSQ93EX-AESeg?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(400);
            Image3.Width = Unit.Pixel(400);


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