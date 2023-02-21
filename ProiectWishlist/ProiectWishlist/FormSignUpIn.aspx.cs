using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectWishlist
{
    public partial class FormSignUpIn : System.Web.UI.Page
    {
        OracleConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cons = "User ID=; Password=; Data Source=(DESCRIPTION=" +
            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=)(PORT=)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=)));";
            conn = new OracleConnection(cons);
        }

        protected void ButtonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command = new OracleCommand("preadclient", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("vusername", OracleDbType.Varchar2, 10);
            command.Parameters.Add("vparola", OracleDbType.Varchar2, 20);
            command.Parameters.Add("flux", OracleDbType.Varchar2, 10);
            command.Parameters[0].Direction = ParameterDirection.Input;
            command.Parameters[1].Direction = ParameterDirection.Input;
            command.Parameters[2].Direction = ParameterDirection.Output;
            command.Parameters[0].Value = TextBox1.Text;
            command.Parameters[1].Value = TextBox4.Text;
            try
            {
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            TextBox1.Visible = false;
            TextBox4.Visible = false;
            ButtonSignIn.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox5.Visible = false;
            ButtonSignUp.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            ButtonSignOut.Visible = true;
            LabelEroare.Visible = false;
            ButtonCauta.Visible = true;
            Button1.Visible = true;
            ButtonVideo.Visible = false;
            ButtonViewWish.Visible = true;
            LabelAutentificare.Text = "Bine ai venit, " + command.Parameters[2].Value.ToString() + " !";
            if (command.Parameters[2].Value.ToString() == "admin")
            {
                ButtonAddP.Visible = true;
                Button2GenSemn.Visible = true;
            }
            conn.Close();
        }

        protected void ButtonSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand cmd = new OracleCommand("psinserareclient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vnume", OracleDbType.Varchar2, 50);
            cmd.Parameters.Add("vusername", OracleDbType.Varchar2, 10);
            cmd.Parameters.Add("vparola", OracleDbType.Varchar2, 20);
            cmd.Parameters[0].Value = TextBox2.Text;
            cmd.Parameters[1].Value = TextBox3.Text;
            cmd.Parameters[2].Value = TextBox5.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare" + ex.Message;
            }
            LabelEroare.Text = "Utilizator adaugat cu succes";
            conn.Close();
        }

        protected void ButtonSignOut_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            TextBox4.Visible = true;
            ButtonSignIn.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox5.Visible = true;
            ButtonSignUp.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            LabelAutentificare.Visible = false;
            ButtonSignOut.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            FileUpload1.Visible = false;
            ButtonAdd.Visible = false;
            Label11.Visible = false;
            TextBoxHttp.Visible = false;
            ButtonAddHttp.Visible = false;
            ButtonCautaDesc.Visible = false;
            ButtonCautaImg.Visible = false;
            Label12.Visible = false;
            TextBoxVideo.Visible = false;
            ButtonSalvareVideo.Visible = false;
            Label8.Visible = false;
            TextBoxDen.Visible = false;
            ButtonAfiseazaDen.Visible = false;
            ButtonGrayscale.Visible = false;
            ButtonFlip.Visible = false;
            Label9.Visible = false;
            FileUpload2.Visible = false;
            ButtonAfiseazaImg.Visible = false;
            ButtonGrayscale.Visible = false;
            ButtonFlip.Visible = false;
            ButtonAddWish.Visible = false;
            Image1.Visible = false;
            Label10.Visible = false;
            ButtonAfisareVideo.Visible = false;
            LabelEroare.Text = "";
            ButtonCauta.Visible = false;
            Button1.Visible = false;
            ButtonViewWish.Visible = false;
            Button2GenSemn.Visible = false;
            ButtonAddP.Visible = false;
            video.Attributes["hidden"] = "hidden";
            FileUpload3.Visible = false;
            ButtonVideo.Visible = false;
        }

        protected void ButtonAddP_Click(object sender, EventArgs e)
        {
            Label6.Visible = true;
            Label7.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
            FileUpload1.Visible = true;
            ButtonAdd.Visible = true;
            Label11.Visible = true;
            TextBoxHttp.Visible = true;
            ButtonAddHttp.Visible = true;
            ButtonCautaDesc.Visible = false;
            ButtonCautaImg.Visible = false;
            FileUpload3.Visible = true;
            ButtonVideo.Visible = true;
            ButtonSalvareVideo.Visible = false;
            ButtonAfisareVideo.Visible = false;
            Label12.Visible = false;
            TextBoxVideo.Visible = false;

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            LabelEroare.Text = "";
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(@"D:\SCOALA\Master Semestrul 1\M2 - BD Multimedia\Seminar\Proiect\produse\" + FileUpload1.FileName);
                LabelEroare.Text = "Fisier incarcat " + FileUpload1.FileName;
                using (var img = System.IO.File.OpenRead(@"D:\SCOALA\Master Semestrul 1\M2 - BD Multimedia\Seminar\Proiect\produse\" + FileUpload1.FileName))
                {
                    var imageBytes = new byte[img.Length];
                    img.Read(imageBytes, 0, (int)img.Length);
                    LabelEroare.Text = "Imaginea are " + img.Length.ToString();
                    try
                    {
                        conn.Open();
                    }
                    catch (OracleException ex)
                    {
                        LabelEroare.Text = "Eroare " + ex.Message;
                    }
                    OracleCommand cmd = new OracleCommand("psinserareprodus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
                    cmd.Parameters.Add("vpret", OracleDbType.Int32);
                    cmd.Parameters.Add("vInStoc", OracleDbType.Varchar2, 2);
                    cmd.Parameters.Add("fis", OracleDbType.Blob);
                    cmd.Parameters[0].Value = TextBox6.Text;
                    cmd.Parameters[1].Value = Convert.ToInt32(TextBox7.Text);
                    if (RadioButton1.Checked == true)
                    {
                        cmd.Parameters[2].Value = "Da";
                    }
                    else if (RadioButton2.Checked == true)
                    {
                        cmd.Parameters[2].Value = "Nu";
                    }
                    cmd.Parameters[3].Value = imageBytes;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        LabelEroare.Text = "Eroare" + ex.Message;
                    }
                    LabelEroare.Visible = true;
                    LabelEroare.Text = "Produsul " + TextBox6.Text + " a fost adaugat.";
                    conn.Close();
                }

            }
            else
            {
                LabelEroare.Text = "Nu exista niciun fisier selectat!";
            }
        }

        protected void ButtonCauta_Click(object sender, EventArgs e)
        {
            ButtonCautaDesc.Visible = true;
            ButtonCautaImg.Visible = true;
            Label12.Visible = true;
            TextBoxVideo.Visible = true;
            ButtonSalvareVideo.Visible = true;
            Label6.Visible = false;
            Label7.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            FileUpload1.Visible = false;
            Label11.Visible = false;
            TextBoxHttp.Visible = false;
            ButtonAdd.Visible = false;
            ButtonAddHttp.Visible = false;
            FileUpload3.Visible = false;
            ButtonVideo.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LabelEroare.Visible = false;
            Image1.ImageUrl = "";
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command1 = new OracleCommand("psnumberrowsproduse", conn);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add("nr", OracleDbType.Int32);
            command1.Parameters[0].Direction = ParameterDirection.Output;
            try
            {
                command1.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            string rez = command1.Parameters[0].Value.ToString();
            int nr = Convert.ToInt32(rez);
            //System.Diagnostics.Debug.WriteLine(rez);
            for (int i = 1; i <= nr; i++)
            {
                OracleCommand command = new OracleCommand("preadproduse", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("vid", OracleDbType.Int32);
                command.Parameters.Add("flux", OracleDbType.Blob);
                command.Parameters[0].Direction = ParameterDirection.Input;
                command.Parameters[1].Direction = ParameterDirection.Output;
                command.Parameters[0].Value = i;
                Image img = new Image();
                this.Controls.Add(img);
                try
                {
                    command.ExecuteScalar();
                    Byte[] blob = new Byte[((OracleBlob)command.Parameters[1].Value).Length];
                    try
                    {
                        ((OracleBlob)command.Parameters[1].Value).Read(blob, 0, blob.Length);
                    }
                    catch (Exception ex)
                    {
                        LabelEroare.Text = "Eroare " + ex.Message;
                    }
                    string myimg = Convert.ToBase64String(blob, 0, blob.Length);
                    img.ImageUrl = "data:image/gif;base64," + myimg;
                }
                catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare " + ex.Message;
                }
            }
            conn.Close();
        }

        protected void ButtonCautaDesc_Click(object sender, EventArgs e)
        {
            Label8.Visible = true;
            TextBoxDen.Visible = true;
            ButtonAfiseazaDen.Visible = true;
            ButtonGrayscale.Visible = true;
            ButtonFlip.Visible = true;
            Label9.Visible = false;
            FileUpload2.Visible = false;
            ButtonAfiseazaImg.Visible = false;
        }

        protected void ButtonCautaImg_Click(object sender, EventArgs e)
        {
            Label9.Visible = true;
            FileUpload2.Visible = true;
            ButtonAfiseazaImg.Visible = true;
            ButtonGrayscale.Visible = true;
            ButtonFlip.Visible = true;
            Label8.Visible = false;
            TextBoxDen.Visible = false;
            ButtonAfiseazaDen.Visible = false;
            Label13.Visible = false;
        }

        protected void ButtonAfiseazaDen_Click(object sender, EventArgs e)
        {
            ButtonAddWish.Visible = true;
            Image1.Visible = true;
            LabelEroare.Visible = true;
            Image1.ImageUrl = "";
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command1 = new OracleCommand("preadprodusdescriere", conn);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            command1.Parameters.Add("flux", OracleDbType.Varchar2, 255);
            command1.Parameters[0].Direction = ParameterDirection.Input;
            command1.Parameters[1].Direction = ParameterDirection.Output;
            command1.Parameters[0].Value = TextBoxDen.Text;
            try
            {
                command1.ExecuteScalar();
                Label13.Text = command1.Parameters[1].Value.ToString();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }

            OracleCommand command = new OracleCommand("preadprodus", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            command.Parameters.Add("flux", OracleDbType.Blob);
            command.Parameters[0].Direction = ParameterDirection.Input;
            command.Parameters[1].Direction = ParameterDirection.Output;
            command.Parameters[0].Value = TextBoxDen.Text;
            try
            {
                command.ExecuteScalar();
                Byte[] blob = new Byte[((OracleBlob)command.Parameters[1].Value).Length];
                FileStream fs = null;
                try
                {
                    ((OracleBlob)command.Parameters[1].Value).Read(blob, 0, blob.Length);
                }
                catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare " + ex.Message;
                }
                fs = new FileStream("D:\\SCOALA\\Master Semestrul 1\\M2 - BD Multimedia\\Seminar\\Proiect\\produse\\preluate\\" + TextBoxDen.Text + ".jpg", FileMode.Create, FileAccess.ReadWrite);
                fs.Write(blob, 0, blob.Length);
                fs.Close();
                conn.Close();
                string myimg = Convert.ToBase64String(blob, 0, blob.Length);
                Image1.ImageUrl = "data:image/gif;base64," + myimg;
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
        }

        protected void Button2GenSemn_Click(object sender, EventArgs e)
        {
            LabelEroare.Visible = true;
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;

            }
            OracleCommand cmd = new OracleCommand("psgensemnprod", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            conn.Close();
            LabelEroare.Text = "Semnaturile produselor au fost generate cu succes!";
        }

        protected void ButtonAfiseazaImg_Click(object sender, EventArgs e)
        {
            ButtonAddWish.Visible = true;
            Label10.Visible = true;
            Image1.Visible = true;
            LabelEroare.Visible = true;
            LabelEroare.Text = "";
            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs("D:\\SCOALA\\Master Semestrul 1\\M2 - BD Multimedia\\Seminar\\Proiect\\produse\\" + FileUpload2.FileName);
                using (var img = System.IO.File.OpenRead("D:\\SCOALA\\Master Semestrul 1\\M2 - BD Multimedia\\Seminar\\Proiect\\produse\\" + FileUpload2.FileName))
                {
                    Byte[] imageByte = new Byte[img.Length];
                    img.Read(imageByte, 0, (int)img.Length);
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        LabelEroare.Text = "Eroare " + ex.Message;
                    }
                    OracleCommand cmd = new OracleCommand("psregasireprodus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("fis", OracleDbType.Blob);
                    cmd.Parameters.Add("vdetalii", OracleDbType.Varchar2, 255);
                    cmd.Parameters[0].Direction = ParameterDirection.Input;
                    cmd.Parameters[1].Direction = ParameterDirection.Output;
                    cmd.Parameters[0].Value = imageByte;

                    try
                    {
                        cmd.ExecuteScalar();
                    }
                    catch (OracleException ex)
                    {
                        LabelEroare.Text = "Eroare " + ex.Message;
                    }
                    Label10.Text = cmd.Parameters[1].Value.ToString();
                    string[] den = Label10.Text.Split(',');
                    conn.Close();
                    TextBoxDen.Text = den[0];
                    this.ButtonAfiseazaDen_Click(this, e);
                }
            }
        }

        protected void ButtonAddWish_Click(object sender, EventArgs e)
        {
            LabelEroare.Visible = true;
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand cmd = new OracleCommand("psinserarewish", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vuser", OracleDbType.Varchar2, 10);
            cmd.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            string[] user = LabelAutentificare.Text.Split(',');
            string[] userfinal = user[1].Split(' ');
            string[] den = Label10.Text.Split(',');
            cmd.Parameters[0].Value = TextBox1.Text;
            cmd.Parameters[1].Value = TextBoxDen.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare" + ex.Message;
            }
            LabelEroare.Text = "Produsul a fost adaugat in wishlist!";
            conn.Close();
        }

        protected void ButtonViewWish_Click(object sender, EventArgs e)
        {
            LabelEroare.Visible = true;
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command = new OracleCommand("preadprodusewish", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("vuser", OracleDbType.Varchar2, 255);
            command.Parameters.Add("wish", OracleDbType.Varchar2, 255);
            command.Parameters[0].Direction = ParameterDirection.Input;
            command.Parameters[1].Direction = ParameterDirection.Output;
            command.Parameters[0].Value = TextBox1.Text;
            try
            {
                command.ExecuteScalar();
                string[] prodWish = command.Parameters[1].Value.ToString().Split(',');
                System.Diagnostics.Debug.WriteLine(prodWish[1]);
                for (int i = 1; i < prodWish.Length; i++)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = prodWish[i];
                    divrb.Controls.Add(rb);
                    rb.Checked = true;
                }
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
        }

        protected void ButtonVideo_Click(object sender, EventArgs e)
        {
            LabelEroare.Visible = true;
            LabelEroare.Text = "";
            if (FileUpload3.HasFile)
            {
                FileUpload3.SaveAs(@"D:\SCOALA\Master Semestrul 1\M2 - BD Multimedia\Seminar\Proiect\video\" + FileUpload3.FileName);
                LabelEroare.Text = "Fisier incarcat " + FileUpload3.FileName;
                using (var img = System.IO.File.OpenRead(@"D:\SCOALA\Master Semestrul 1\M2 - BD Multimedia\Seminar\Proiect\video\" + FileUpload3.FileName))
                {
                    var imageBytes = new byte[img.Length];
                    img.Read(imageBytes, 0, (int)img.Length);
                    LabelEroare.Text = "Video are " + img.Length.ToString();
                    try
                    {
                        conn.Open();
                    }
                    catch (OracleException ex)
                    {
                        LabelEroare.Text = "Eroare " + ex.Message;
                    }
                    OracleCommand cmd = new OracleCommand("psinserarevideoprodus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
                    cmd.Parameters.Add("fis", OracleDbType.Blob);
                    cmd.Parameters[0].Value = TextBox6.Text;
                    cmd.Parameters[1].Value = imageBytes;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        LabelEroare.Text = "Eroare" + ex.Message;
                    }
                    LabelEroare.Text = "Produsul " + TextBox6.Text + " a fost actualizat cu un video de prezentare.";
                    conn.Close();
                }

            }
            else //nu a fost selectat niciun fisier
            {
                LabelEroare.Text = "Nu exista niciun fisier selectat!";
            }
        }

        protected void ButtonSalvareVideo_Click(object sender, EventArgs e)
        {
            ButtonAfisareVideo.Visible = true;
            LabelEroare.Visible = true;
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command = new OracleCommand("preadvideoprodus", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            command.Parameters.Add("flux", OracleDbType.Blob);
            command.Parameters[0].Direction = ParameterDirection.Input;
            command.Parameters[1].Direction = ParameterDirection.Output;
            command.Parameters[0].Value = TextBoxVideo.Text;
            try
            {
                command.ExecuteScalar();
                Byte[] blob = new Byte[((OracleBlob)command.Parameters[1].Value).Length];
                FileStream fs = null;
                try
                {
                    ((OracleBlob)command.Parameters[1].Value).Read(blob, 0, blob.Length);
                }
                catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare " + ex.Message;
                }
                fs = new FileStream("D:\\SCOALA\\Master Semestrul 1\\M2 - BD Multimedia\\Seminar\\Proiect\\ProiectWishlist\\ProiectWishlist\\preluate\\" + TextBoxVideo.Text + ".mp4", FileMode.Create, FileAccess.ReadWrite);
                fs.Write(blob, 0, blob.Length);
                fs.Close();
                LabelEroare.Text = "Videoclipul a fost salvat";
                conn.Close();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
        }

        protected void ButtonAfisareVideo_Click(object sender, EventArgs e)
        {
            video.Attributes["hidden"] = null;
            video.Attributes["src"] = "~/preluate/" + TextBoxVideo.Text + ".mp4";
        }

        protected void ButtonGrayscale_Click(object sender, EventArgs e)
        {
            ButtonAddWish.Visible = true;
            Image1.Visible = true;
            LabelEroare.Visible = true;
            Image1.ImageUrl = "";
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command = new OracleCommand("psgrayscale", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            command.Parameters.Add("flux", OracleDbType.Blob);
            command.Parameters[0].Direction = ParameterDirection.Input;
            command.Parameters[1].Direction = ParameterDirection.Output;
            command.Parameters[0].Value = TextBoxDen.Text;
            try
            {
                command.ExecuteScalar();
                Byte[] blob = new Byte[((OracleBlob)command.Parameters[1].Value).Length];
                FileStream fs = null;
                try
                {
                    ((OracleBlob)command.Parameters[1].Value).Read(blob, 0, blob.Length);
                }
                catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare " + ex.Message;
                }
                fs = new FileStream("D:\\SCOALA\\Master Semestrul 1\\M2 - BD Multimedia\\Seminar\\Proiect\\produse\\preluate\\" + TextBoxDen.Text + ".jpg", FileMode.Create, FileAccess.ReadWrite);
                fs.Write(blob, 0, blob.Length);
                fs.Close();
                conn.Close();
                string myimg = Convert.ToBase64String(blob, 0, blob.Length);
                Image1.ImageUrl = "data:image/gif;base64," + myimg;
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
        }

        protected void ButtonFlip_Click(object sender, EventArgs e)
        {
            ButtonAddWish.Visible = true;
            Image1.Visible = true;
            LabelEroare.Visible = true;
            Image1.ImageUrl = "";
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand command = new OracleCommand("psflip", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            command.Parameters.Add("flux", OracleDbType.Blob);
            command.Parameters[0].Direction = ParameterDirection.Input;
            command.Parameters[1].Direction = ParameterDirection.Output;
            command.Parameters[0].Value = TextBoxDen.Text;
            try
            {
                command.ExecuteScalar();
                Byte[] blob = new Byte[((OracleBlob)command.Parameters[1].Value).Length];
                FileStream fs = null;
                try
                {
                    ((OracleBlob)command.Parameters[1].Value).Read(blob, 0, blob.Length);
                }
                catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare " + ex.Message;
                }
                fs = new FileStream("D:\\SCOALA\\Master Semestrul 1\\M2 - BD Multimedia\\Seminar\\Proiect\\produse\\preluate\\" + TextBoxDen.Text + ".jpg", FileMode.Create, FileAccess.ReadWrite);
                fs.Write(blob, 0, blob.Length);
                fs.Close();
                conn.Close();
                string myimg = Convert.ToBase64String(blob, 0, blob.Length);
                Image1.ImageUrl = "data:image/gif;base64," + myimg;
            }
            catch (Exception ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
        }

        protected void ButtonAddHttp_Click(object sender, EventArgs e)
        {
            LabelEroare.Text = "";
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare " + ex.Message;
            }
            OracleCommand cmd = new OracleCommand("psinserareprodushttp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vdescriere", OracleDbType.Varchar2, 255);
            cmd.Parameters.Add("vpret", OracleDbType.Int32);
            cmd.Parameters.Add("vInStoc", OracleDbType.Varchar2, 2);
            cmd.Parameters.Add("cale", OracleDbType.Varchar2);
            cmd.Parameters.Add("imaginehttp", OracleDbType.Varchar2);
            cmd.Parameters[0].Value = TextBox6.Text;
            cmd.Parameters[1].Value = Convert.ToInt32(TextBox7.Text);
            if (RadioButton1.Checked == true)
            {
                cmd.Parameters[2].Value = "Da";
            }
            else if (RadioButton2.Checked == true)
            {
                cmd.Parameters[2].Value = "Nu";
            }
            cmd.Parameters[3].Value = TextBoxHttp.Text.Substring(0, TextBoxHttp.Text.LastIndexOf(@"/")) + "/";
            cmd.Parameters[4].Value = TextBoxHttp.Text.Substring(TextBoxHttp.Text.LastIndexOf(@"/") + 1);
            System.Diagnostics.Debug.WriteLine(cmd.Parameters[4].Value);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                LabelEroare.Text = "Eroare" + ex.Message;
            }
            LabelEroare.Visible = true;
            LabelEroare.Text = "Produsul " + TextBox6.Text + " a fost adaugat.";
            conn.Close();
        }

    }
}