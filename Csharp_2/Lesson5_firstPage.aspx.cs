using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lesson5_firstPage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>說明：下圖為Lesson five範例圖，使用者必須學著畫出範例，越像越好，以下將會有七張圖與基準圖(Benchmark)做為比較，基準圖分數為50分，如你所看到其他使用者繪畫的圖案比基準圖好，請給予高於50分以上的分數；反之，請給予低於50分的分數，滿分為100分</H2>");

        Image2.ImageUrl = "https://photos-3.dropbox.com/t/2/AADZJIIqOfLI7YUnrR40XHfAJKmsvbzFDwNODf0FRIG3Hw/12/36943375/png/32x32/1/_/1/2/origin.PNG/ENiPjRwYkTwgAigC/TWvixNLh6U_vYoSC6oGbL5wENc5M63wLfaSnei6Gqv4?size=1024x768&size_mode=2";

        Image2.Width = Unit.Pixel(350);

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("Lesson5_1.aspx");
    }
}