﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson4_3 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：左圖為受測者要評分圖片，右圖為基準圖，基準圖分數為50分，如受測者覺得左圖比右圖好，請給予高於50分;反之，則給予低於50的分數</H2>");
        Response.Write("<H2>請輸入分數:(左圖:評分圖片;右圖:基準圖)</H2>");
        Image2.ImageUrl = "https://photos-2.dropbox.com/t/2/AACrUMbFyiVTjzwBRSJSHyyzqG9exKhTm9xd9kQUYxvQgw/12/36943375/jpeg/32x32/1/_/1/2/1416495446.JPEG/ENiPjRwYiTwgAigC/c0XKxwUXo9X7Gu4dwpwDeAlQtjyqhCSOlu7ggv4SIrk?size=1024x768&size_mode=2";
        Image3.ImageUrl = "https://photos-1.dropbox.com/t/2/AADiQuW_H2NEWm8M0uCdqkyCdGbka_RwaymVhFpPFbUpuA/12/36943375/jpeg/32x32/1/_/1/2/1416495507.JPEG/ENiPjRwYiTwgAigC/03uUag-UxP_dId5co31WIS5itvKBO8G_EUVB_nCboWI?size=1024x768&size_mode=2";
        Image2.Width = Unit.Pixel(450);
        Image3.Width = Unit.Pixel(450);
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");

        conn.Open();


        SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Benchmark_pic,Score) Values(4,446,507,@paramScore)", conn);

        cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        conn.Close();
        conn.Dispose();
        Response.Redirect("Lesson4_4.aspx");
    }
}