using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_result : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void message(string mes) //вывод сообщений
    {
        TextBox1.Text +=" "+ mes;
    }
    private void Clear()
    {
        CheckBoxList1.Items.Clear();
        TextBox1.Text = null;
       // TextBox2.Text = null;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


    }

    int SelectIdVopros (string vopros, int specialnost)
    {

        
          string SelectVopros = "SELECT     id_voprosy FROM         voprosy WHERE     (specialnost = @specialnost) AND (vopros = @vopros)"; // получаем вопросы из категории
              SqlCommand SVopros = new SqlCommand(SelectVopros, con);
              SVopros.Parameters.AddWithValue("@specialnost",specialnost);
            SVopros.Parameters.AddWithValue("@vopros", vopros);
            Label2.Text=SVopros.ExecuteScalar().ToString(); 
       // Label4.Text = SVopros.ExecuteScalar().ToString();
        return Convert.ToInt32(SVopros.ExecuteScalar());

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["pv"] = "0";
        Session["poz"] = "0";
        Session["otv"] = null;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["poz"] = null;
        Session["otv"] = null;


    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button_Click(object sender, EventArgs e)
    {
        Session["poz"] = null;
        Session["otv"] = null;
        Session["pv"] = "0";
        Session["poz"] = "0";
        Session["otv"] = null;

       // _ProgressTest.Value++;
        //int StatusProverka = 0;

        StreamReader reader = new StreamReader(@TextBox2.Text+DropDownList1.SelectedItem.ToString() + ".qst", Encoding.Default);
        string strAllFile = reader.ReadToEnd().Replace("\r\n", "\n").Replace("\n\r", "\n");
        string[] arrLines = strAllFile.Split(new char[] { '\n' });
        for (int j = 0; j <= arrLines.Length; j++)
        {
           // System.Threading.Thread.Sleep(100);
            if (TextBox1.Text != "")
            {
                con.Open();
                string InsertVopros = " INSERT INTO voprosy (specialnost, vopros, kategoria) VALUES     (@specialnost,@vopros,1)"; // получаем вопросы из категории
                SqlCommand IVopros = new SqlCommand(InsertVopros, con);
                IVopros.Parameters.AddWithValue("@specialnost", DropDownList1.Text);
                IVopros.Parameters.AddWithValue("@vopros", TextBox1.Text);
                //IVopros.Parameters.AddWithValue("@Id_Napravlenie", DropDownList2.Text);

                try
                {
                    IVopros.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception er)
                {
                    Response.Write("ERROR");
                }
                finally
                {
                }


                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        con.Open();
                        string InsertOtvet = "INSERT INTO otveti (otvet, vernyj, ID_voprosy) VALUES     (@otvet,@vernyj,@ID_voprosy)"; // получаем вопросы из категории
                        SqlCommand IOtvet = new SqlCommand(InsertOtvet, con);
                        IOtvet.Parameters.AddWithValue("@otvet", CheckBoxList1.Items[i].Text);
                        IOtvet.Parameters.AddWithValue("@vernyj", 1);
                        IOtvet.Parameters.AddWithValue("@ID_voprosy", SelectIdVopros(TextBox1.Text, Convert.ToInt32(DropDownList1.Text)));

                        try
                        {
                            IOtvet.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception er)
                        {
                            Response.Write("ERROR ZAPIS OTVET VETNII");
                        }
                        finally
                        {
                        }

                    }
                    else
                    {
                        con.Open();
                        string InsertOtvet = "INSERT INTO otveti (otvet, vernyj, ID_voprosy) VALUES     (@otvet,@vernyj,@ID_voprosy)"; // получаем вопросы из категории
                        SqlCommand IOtvet = new SqlCommand(InsertOtvet, con);
                        IOtvet.Parameters.AddWithValue("@otvet", CheckBoxList1.Items[i].Text);
                        IOtvet.Parameters.AddWithValue("@vernyj", 0);
                        IOtvet.Parameters.AddWithValue("@ID_voprosy", SelectIdVopros(TextBox1.Text, Convert.ToInt32(DropDownList1.Text)));

                        try
                        {
                            IOtvet.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception er)
                        {
                            Response.Write("ERROR ZAPIS OTVET VETNII");
                        }
                        finally
                        {
                        }

                    }


                }


            }

            /*for (int j = 0; j < CountPravilnyjOtvet.Length-1; j++)
             {
                 for (int l = 0; l < CheckBoxList1.Items.Count; l++)
                 {
                     if (CheckBoxList1.Items[l].Selected)
                     {
                         if (CheckBoxList1.Items[l].Text == CountPravilnyjOtvet[j])
                         {
                             PravilnyjOtvet++;
                             break;
                         }
                         else
                         { PravilnyjOtvet--; }
                     }
                 }
             }

           if (PravilnyjOtvet == CountPravilnyjOtvet.Length - 1)
           {
               Label2.Text = "Правильно";
               Session["pv"] = Convert.ToString(Convert.ToInt32(Session["pv"]) + 1);
           }
           else
           { Label2.Text = "не правильно"; }
       }
       //  Label2.Text = Convert.ToString(TextBox2.Lines.Length);
       // определения правильного ответа
          for (int j=0;j<=TextBox2.Rows;j++)
          {

          }*/

            Label1.Text = Session["poz"].ToString();
            Clear();

            for (int y = Convert.ToInt32(Session["poz"]) + 1; y <= arrLines.Length; y++)
            {
                if (arrLines[y] != "?")
                {
                    if ((arrLines[y].Remove(1)) == "-")
                    {
                        CheckBoxList1.Items.Add(arrLines[y].Remove(0, 1));
                        if (arrLines[y + 1] == "?")
                        {
                            Session["poz"] = y;
                            break;
                        }
                    }
                    else if (arrLines[y].Remove(1) == "+")
                    {
                        CheckBoxList1.Items.Add(arrLines[y].Remove(0, 1));
                        //CheckBoxList1.Items.Count
                        CheckBoxList1.Items[CheckBoxList1.Items.Count - 1].Selected = true;
                        // CheckBoxList1.Items.
                        // CheckBoxList1..Items.
                        //   TextBox2.Text += arrLines[y].Remove(0, 2) + "$";
                        if (arrLines[y + 1] == "?")
                        {
                            Session["poz"] = y;
                            break;
                        }
                    }
                    else
                    { message(arrLines[y]); }


                }

                // for (int i = Convert.ToInt32(Session["poz"]) )
                //RadioButtonList1.Items.Add(arrLines[y]); 


            }
            Label3.Text = Session["pv"].ToString();

            // TextBox1.Text = arrLines[1];
        }
        Response.Write(TextBox2.Text+" ГОТОВО!");

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["poz"] = TextBox3.Text;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
     
            for (int i = 0; i < Convert.ToInt32(TextBox5.Text);i++)
            {

                con.Close();
                TextBox4.Text += "----" + i.ToString() + "----" + "\n";
                con.Open();


                string SelectDoubleVopros = "SELECT  TOP (1)   voprosy.vopros FROM         voprosy INNER JOIN specialnost ON voprosy.specialnost = specialnost.id_specialnost INNER JOIN [dolzhnost-specialnost] ON specialnost.id_specialnost = [dolzhnost-specialnost].specialnost INNER JOIN dolzhnost ON [dolzhnost-specialnost].dolzhnost = dolzhnost.ID GROUP BY voprosy.vopros, dolzhnost.ID HAVING      (COUNT(voprosy.id_voprosy) > 1) AND (dolzhnost.ID = @dolz)"; // получаем вопросы из категории
                SqlCommand SDV = new SqlCommand(SelectDoubleVopros, con);
                SDV.Parameters.AddWithValue("@dolz", DropDownList2.Text);
                string vopros = SDV.ExecuteScalar().ToString();

                TextBox4.Text += vopros + "\n";
                con.Close();

                con.Open();
                string DelVopros = "DELETE FROM voprosy WHERE     (vopros = @vopros)"; // получаем вопросы из категории
                SqlCommand DV = new SqlCommand(DelVopros, con);
                DV.Parameters.AddWithValue("@vopros", vopros);
                try
                {
                    DV.ExecuteNonQuery();
                    TextBox4.Text += "удалю " + "\n";
                    con.Close();
                }
                catch (Exception er)
                {
                    TextBox4.Text += "Не удалю " + "\n";
                }
                finally
                {
                }
            }
        
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string clientScript = "javascript:showSuccessToast('sfsdfsfsdf')";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "MyClientScript", clientScript);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label3.Text = TextBox2.Text + DropDownList1.SelectedItem.ToString() + ".qst";
        string stroka = "javascript:showSuccessToast('" + DropDownList1.SelectedItem.ToString() + "')";
        HyperLink1.NavigateUrl = stroka;

       // Response.Redirect(stroka);
       // Button7.OnClientClick = stroka;

        //Button7.Click;
        //HyperLink1.
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
       // StreamReader reader = new StreamReader(@TextBox2.Text+DropDownList1.SelectedItem.ToString() + ".qst", Encoding.Default);
         string[] fs = Directory.GetFiles(@TextBox2.Text, "*.qst");
           // Array.Sort(fs, 1, 3);
            for (int i = 0; i < fs.Length; i++)
            {
                string fl = Path.GetFileName(fs[i]);
                string sp = fl.Remove(fl.Length - 4, 4);
                //Response.Write( + "<br/>");
                //  Label6.Text += Path.GetFileName(fs[i]) + "<br/>";
                //string fl = Path.GetFileName(fs[i]); // только имя файла с расширением
                // добавляем fl к списку файлов в ListBox
              //  con.Open();
                string InsertSP = "INSERT INTO specialnost                          (naimenovanie) VALUES        (@sp)"; // получаем вопросы из категории
                SqlCommand ISP = new SqlCommand(InsertSP, con);
                ISP.Parameters.AddWithValue("@sp", sp);

                try
                {
                    con.Open();
                    ISP.ExecuteNonQuery();
                    con.Close();
                    TextBox6.Text += sp + "\n";
                }
                catch (Exception er)
                {
                    con.Close();
                    TextBox6.Text=Convert.ToString(er);
                }
            }
    }
    
}