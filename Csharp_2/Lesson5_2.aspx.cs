using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson5_2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：左圖為受測者要評分圖片，右圖為基準圖，基準圖分數為50分，如受測者覺得左圖比右圖好，請給予高於50分;反之，則給予低於50的分數</H2>");
        Response.Write("<H2>請輸入分數:(左圖:評分圖片;右圖:基準圖)1_1</H2>");
        Image2.ImageUrl = "https://photos-4.dropbox.com/t/2/AACySrhYZ4Rp8OibMKaO_bAIRBYNEJk_cgpBEaQQlunL3g/12/36943375/png/32x32/1/_/1/2/2.png/ENiPjRwYkTwgAigC/Od_stS3RmxeJkoFiYLD98m88lF_w7J0B0zbEJRvdA1E?size=1024x768&size_mode=2";
        Image3.ImageUrl = "https://photos-2.dropbox.com/t/2/AADx39Uj2_gKh8jHnZyUvbxhmH15xbKTvtGPz6QatGcVvA/12/36943375/png/32x32/1/_/1/2/3.png/ENiPjRwYkTwgAigC/82K31iLl9UhuU0-A_7hQbJJI-sTPBQhFIHrhSoIn0gs?size=1024x768&size_mode=2";
        Image2.Width = Unit.Pixel(350);
        Image3.Width = Unit.Pixel(350);
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=myDB;Integrated Security=SSPI;");

        conn.Open();


        SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Benchmark_pic,Score) Values(5,2,3,@paramScore)", conn);

        cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        conn.Close();
        conn.Dispose();
        Response.Redirect("Lesson5_3.aspx");
    }
}