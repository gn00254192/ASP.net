using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson2_3 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：左圖為受測者要評分圖片，右圖為基準圖，基準圖分數為50分，如受測者覺得左圖比右圖好，請給予高於50分;反之，則給予低於50的分數</H2>");
        Response.Write("<H2>請輸入分數:(左圖:評分圖片;右圖:基準圖)</H2>");
        Image2.ImageUrl = "https://photos-2.dropbox.com/t/2/AADwao_H8ACTUu4HcmdNN-MkYr1tHgio1R_lZ3zhJ4awoA/12/36943375/jpeg/32x32/1/_/1/2/1415792331.JPEG/ENiPjRwY_TsgAigC/rpKDHrDgZQoivpnSurKuhD5t7uWCl8_EOIveq2NynI0?size=1024x768&size_mode=2";
        Image3.ImageUrl = "https://photos-3.dropbox.com/t/2/AAB7jkjmXNVITUrjizwMQJ9s-Ji1Ng2CtXbFB3NoVNgVqg/12/36943375/jpeg/32x32/1/_/1/2/1415792505.JPEG/ENiPjRwY_TsgAigC/kQK14o2yjDE9Q6YNcbolG8KlgQ__rInUsh13tonBqDA?size=1024x768&size_mode=2";
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


        SqlCommand cmd = new SqlCommand("Insert Into Pic_score (Lesson,Test_pic,Benchmark_pic,Score) Values(2,331,505,@paramScore)", conn);

        cmd.Parameters.Add("@paramScore", SqlDbType.Int, 4).Value = txtInput.Text;
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        conn.Close();
        conn.Dispose();
        Response.Redirect("Lesson2_4.aspx");
    }
}