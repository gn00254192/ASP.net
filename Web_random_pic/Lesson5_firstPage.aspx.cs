﻿using System;
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
        Response.Write("<H2>說明：下圖為Lesson five範例圖，使用者必須學著畫出範例，越像越好，以下將會有七張圖與標準答案做為比較，標準答案分數為10分，如你所看到其他使用者繪畫的圖案比標準答案好，請給予高於5分以上的分數；反之，請給予低於5分的分數，滿分為10分</H2>");

        Image2.ImageUrl = "https://photos-6.dropbox.com/t/2/AAAa-T1iIlVcNZomG4bP45CK6SVmS2qhuT3mJMaH1AihSQ/12/36943375/png/32x32/1/_/1/2/origin.PNG/ENiPjRwY_DwgAigC/TWvixNLh6U_vYoSC6oGbL5wENc5M63wLfaSnei6Gqv4?size=1024x768&size_mode=2";

        Image2.Width = Unit.Pixel(350);

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("Lesson_5.aspx");
    }
}