using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson2_firstPage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：下圖為Lesson two範例圖，使用者必須學著畫出範例，越像越好，以下將會有七張圖與基準圖(Benchmark)做為比較，基準圖分數為50分，如你所看到其他使用者繪畫的圖案比基準圖好，請給予高於50分以上的分數；反之，請給予低於50分的分數，滿分為100分</H2>");

        Image2.ImageUrl = "https://photos-5.dropbox.com/t/2/AACWE3mcOtUX-winCQqTrBy95_t77ptZBnWkoiRPxiTjaA/12/36943375/jpeg/32x32/1/_/1/2/orignal.jpg/ENiPjRwY_TsgAigC/EW6UFkgM1gtEmmgvkOTJvLzvr8MmdhGSQ93EX-AESeg?size=1024x768&size_mode=2";

        Image2.Width = Unit.Pixel(480);

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("Lesson2_1.aspx");
    }
}