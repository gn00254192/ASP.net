using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson_3 : System.Web.UI.Page
{
    int k = 1;
    string[] Pic_url = { "https://photos-4.dropbox.com/t/2/AAA3-uWJR1KwpJS7XDkicoVFG72Ila4RtA7qNZehUnt4Ug/12/36943375/jpeg/32x32/1/_/1/2/1416485011.JPEG/ENiPjRwYmjwgAigC/SnY8SphbSAcNUoP5SeZWdDId1kmQ108mfOVTJRwmDNg?size=1024x768&size_mode=2",
                         "https://photos-1.dropbox.com/t/2/AABdFWZzEiYWvRFwXeMGrTNQWV6vnjjEhJfI1Sl4rZ6KVA/12/36943375/jpeg/32x32/1/_/1/2/1416485058.JPEG/ENiPjRwYmjwgAigC/WSE-nH16LM1rd2tghFbUY9PqumQybNga44NEClZ6wyo?size=1024x768&size_mode=2",
                         "https://photos-1.dropbox.com/t/2/AAA4aWatReOBYhIrkvW_D8kHWYu97iMQiJuyb1XQVUd2EA/12/36943375/jpeg/32x32/1/_/1/2/1416485044.JPEG/ENiPjRwYmjwgAigC/rvRyy-cesfyVNg9mMv56EUrgprAkrvjErLlD1Y4gBgw?size=1024x768&size_mode=2",
                         "https://photos-1.dropbox.com/t/2/AAAstiSZnJpgg-p2lxu20bLJLxK569aNyaGiGaKB7C3enw/12/36943375/jpeg/32x32/1/_/1/2/1416485193.JPEG/ENiPjRwYmjwgAigC/sJPsq9Arsre5Nz9d7EYL41iLfH_JKLeeTJKUZju8YEw?size=1024x768&size_mode=2",
                         "https://photos-5.dropbox.com/t/2/AAADa4BIp78n7ax4S_7J41O7K6GJ1Ts2RkIApHtk5vTQ4Q/12/36943375/jpeg/32x32/1/_/1/2/1416485029.JPEG/ENiPjRwYmjwgAigC/6meHZsNA5rQPoWdaFPs1aNjcNUAfJp8ZWfcbIrD18T8?size=1024x768&size_mode=2",
                         "https://photos-4.dropbox.com/t/2/AAB-lfSEOU54qrzr-dYEzhqASftumJdjTmFL47B_bUeI6g/12/36943375/jpeg/32x32/1/_/1/2/1416485254.JPEG/ENiPjRwYmjwgAigC/GVOJmypHap29k1cZlc4Lc7k_nl3V9cah5UE_jJu_4Hk?size=1024x768&size_mode=2",
                         "https://photos-5.dropbox.com/t/2/AADjeDBmeBpLPHXHlqfJqOI2FHvckUW1mWEmLYUmeu4TIw/12/36943375/jpeg/32x32/1/_/1/2/1416485108.JPEG/ENiPjRwYmjwgAigC/i2XHKQEQ0mXG8CTF3FesWjbVOuMC-97dMMZ6-q7ESJc?size=1024x768&size_mode=2",
                         "https://photos-3.dropbox.com/t/2/AADpRoqy6nbmOV21Ath5Ta6-C1Nj7GXU8TxTQwrf3AdClQ/12/36943375/jpeg/32x32/1/_/1/2/1416485283.JPEG/ENiPjRwYmjwgAigC/61wAVqAYrsqHUmjhH_RxS3o-6yYp43hhIvTe2nsSpLQ?size=1024x768&size_mode=2"};
    string[] Pic_ID = { "1416485011",
                        "1416485058",
                        "1416485044",
                        "1416485193",
                        "1416485029",
                        "1416485254",
                        "1416485108",
                        "1416485283"};
    int[] rand2 = new int[8];
    int[] result2 = new int[8];
    //用于存放1到9这9个数     
    int[] random_num = new int[8];
    //用于保存返回结果     
    int[] result = new int[8];

    public void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：左圖為受測者要評分圖片，右圖為標準圖，標準圖分數為10分，如左圖畫的接近標準圖，請給予高分；反之，請給予低分，滿分為10分</H2>");
        Response.Write("<H2>請輸入分數:(左圖:評分圖片;右圖:標準圖)</H2>");

        if (!IsPostBack)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("rand_num");
            HttpCookie cookie_k = new HttpCookie("k");
            //設定單值
            cookie_k.Value = Server.UrlEncode(k.ToString());
            //設定過期日
            cookie_k.Expires = DateTime.Now.AddHours(1);
            //寫到用戶端
            Response.Cookies.Add(cookie_k);



            string r = "";
            Random random = new Random();
            for (int i = 1; i <= 8; i++)
            {
                random_num[i - 1] = i;
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
            Image2.ImageUrl = Pic_url[random_num[0] - 1];//random show picture
            Image3.ImageUrl = "https://photos-6.dropbox.com/t/2/AACuHLEA10wwRZQDm_ndlOSnWy4Tw00X_9JgFCwKT6GNkA/12/36943375/png/32x32/1/_/1/2/circle.png/ENiPjRwYmjwgAigC/wA-l08G8I12hESe8N3LQ1DAMN7I7tOsedKv4gbkM0tE?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(450);
            Image3.Width = Unit.Pixel(450);
        }
        else
        {
            //rand2 = random_num;
            //result2=
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies["rand_num"];
        HttpCookie cookie_k = Request.Cookies["k"];

        string r = Server.UrlDecode(cookie.Value);
        string[] rand_r = r.Split(',');
        int k = int.Parse(Server.UrlDecode(cookie_k.Value));

        if (k != 8)
        {
            for (int i = 0; i < 8; i++)
            {
                random_num[i] = int.Parse(rand_r[i]);
                Response.Write("b:" + random_num[i]);  //random數字放入陣列
            }
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(3," + int.Parse(Pic_ID[k-1]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


            Image2.ImageUrl = Pic_url[random_num[k] - 1];//random show picture
            Image3.ImageUrl = "https://photos-6.dropbox.com/t/2/AACuHLEA10wwRZQDm_ndlOSnWy4Tw00X_9JgFCwKT6GNkA/12/36943375/png/32x32/1/_/1/2/circle.png/ENiPjRwYmjwgAigC/wA-l08G8I12hESe8N3LQ1DAMN7I7tOsedKv4gbkM0tE?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(450);
            Image3.Width = Unit.Pixel(450);
            Response.Write(k);
            k++;
        }
        else
        {
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(3," + int.Parse(Pic_ID[k - 1]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            Response.Redirect("Lesson_4.aspx");
        }

        cookie_k = new HttpCookie("k");
        //設定單值
        cookie_k.Value = Server.UrlEncode(k.ToString());
        //設定過期日
        cookie_k.Expires = DateTime.Now.AddHours(1);
        //寫到用戶端
        Response.Cookies.Add(cookie_k);
        txtInput.Text = "";
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}