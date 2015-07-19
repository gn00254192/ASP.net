using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson_5 : System.Web.UI.Page
{
    int k = 1;
    string[] Pic_url = { "https://photos-4.dropbox.com/t/2/AADCOCrxvefvW-FXSCdo0Icfb3r84dJia0qScgvGot1K9A/12/36943375/png/32x32/1/_/1/2/1.png/ENiPjRwYmjwgAigC/rjGHh0xbA_rU-bfp0jsb4IocUOdSqCYAQ-FFRyx27TY?size=1024x768&size_mode=2",
                         "https://photos-6.dropbox.com/t/2/AADulJXJYaFhqYVQ74AKFXmm_x5e7XwWgmZ9kAX44tvliw/12/36943375/png/32x32/1/_/1/2/2.png/ENiPjRwYmjwgAigC/Od_stS3RmxeJkoFiYLD98m88lF_w7J0B0zbEJRvdA1E?size=1024x768&size_mode=2",
                         "https://photos-5.dropbox.com/t/2/AABoKOSaAEURaTO9c8H-UhqYaelCftXPYD4tU-J9OASV6A/12/36943375/png/32x32/1/_/1/2/3.png/ENiPjRwYmjwgAigC/82K31iLl9UhuU0-A_7hQbJJI-sTPBQhFIHrhSoIn0gs?size=1024x768&size_mode=2",
                         "https://photos-2.dropbox.com/t/2/AAAAr0gjKS8-pM2VKiyYUqVjbmeaA8vUCX9hcpheHGvW1A/12/36943375/png/32x32/1/_/1/2/4.png/ENiPjRwYmjwgAigC/ZiMMw5PauWWX3-v3iMLRHGMkkj1AjAiwXszG1YLIVIA?size=1024x768&size_mode=2",
                         "https://photos-1.dropbox.com/t/2/AADIM-9MoSQ10MJmc_c6SgjJpgVJf_KG1YBsUc1wb-2sPQ/12/36943375/png/32x32/1/_/1/2/5.png/ENiPjRwYmjwgAigC/9UGdD6rwdIHrpar7rYjSl0VhF7tFuin8YgQfkg91d2Q?size=1024x768&size_mode=2",
                         "https://photos-2.dropbox.com/t/2/AAByVWjqTafw6pzHXiFKCHp0b8KDoThRvJH4q7XHHwvxEg/12/36943375/png/32x32/1/_/1/2/6.png/ENiPjRwYmjwgAigC/BFpIADvpvMiEiJuBtzBQOKYbVDT7ppKt8bZTCLiCOEY?size=1024x768&size_mode=2"};
    string[] Pic_ID = {  "1",
                         "2",
                         "3",
                         "4",
                         "5",
                         "6"};
    int[] rand2 = new int[6];
    int[] result2 = new int[6];
    //用于存放1到9这9个数     
    int[] random_num = new int[6];
    //用于保存返回结果     
    int[] result = new int[6];

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
            for (int i = 1; i <= 6; i++)
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
                if (i < 6)
                    r += random_num[i] + ",";
                else
                    r += random_num[i];
            }
            for (int i = 0; i < 6; i++)
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
            Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AAD3lKm8ryo85_RkUSxfB9TNjxkeok5hnlrqNmO_2CrD4A/12/36943375/png/32x32/1/_/1/2/origin.PNG/ENiPjRwYmjwgAigC/TWvixNLh6U_vYoSC6oGbL5wENc5M63wLfaSnei6Gqv4?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(350);
            Image3.Width = Unit.Pixel(350);
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

        if (k != 6)
        {
            for (int i = 0; i < 6; i++)
            {
                random_num[i] = int.Parse(rand_r[i]);
                Response.Write("b:" + random_num[i]);  //random數字放入陣列
            }
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(5," + int.Parse(Pic_ID[k-1]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


            Image2.ImageUrl = Pic_url[random_num[k] - 1];//random show picture
            Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AAD3lKm8ryo85_RkUSxfB9TNjxkeok5hnlrqNmO_2CrD4A/12/36943375/png/32x32/1/_/1/2/origin.PNG/ENiPjRwYmjwgAigC/TWvixNLh6U_vYoSC6oGbL5wENc5M63wLfaSnei6Gqv4?size=1024x768&size_mode=2";
            Image2.Width = Unit.Pixel(350);
            Image3.Width = Unit.Pixel(350);
            Response.Write(k);
            k++;
        }
        else
        {
            SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Score) Values(5," + int.Parse(Pic_ID[k - 1]) + ",@paramScore)", conn);
            cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            Response.Redirect("Lesson_end.aspx");
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