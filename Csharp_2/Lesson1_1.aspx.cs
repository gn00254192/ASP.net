using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson1_1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {      
        Response.Write("<H2>說明：左圖為受測者要評分圖片，右圖為基準圖，基準圖分數為50分，如受測者覺得左圖比右圖好，請給予高於50分;反之，則給予低於50的分數</H2>");
        Response.Write("<H2>請輸入分數:(左圖:評分圖片;右圖:基準圖)1_1</H2>");
        Image2.ImageUrl = "https://photos-2.dropbox.com/t/2/AADIMLmVIEGiLD28CNs2p802F-2AVsnruOhc6jMy5HznlA/12/36943375/jpeg/32x32/1/_/1/2/1416406068.JPEG/ENiPjRwY8zsgAigC/R50dVM-DomOvQ1sN7Sv2X27FY7I17FGIgA_upgnwsPM?size=1024x768&size_mode=2";
        Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AABL-PPT4XXqtJa_WKPbihflEaAI6L4_xSt8MRS2Ru4PSg/12/36943375/jpeg/32x32/1/_/1/2/1416405531.JPEG/ENiPjRwY8zsgAigC/HGRC_3qBuiboy1Ho-nIbYeOUnfSQc3qm7KJhm3TBnIg?size=1024x768&size_mode=2";
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


        SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Benchmark_pic,Score) Values(1,68,531,@paramScore)", conn);

        cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        conn.Close();
        conn.Dispose();
        Response.Redirect("Lesson1_2.aspx");
    }
}