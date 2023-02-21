<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormSignUpIn.aspx.cs" Inherits="ProiectWishlist.FormSignUpIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Password1 {
            width: 158px;
            margin-left: 61px;
            margin-top: 0px;
        }

        #Password2 {
            margin-left: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 20px">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Style="margin-left: 35px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Parola"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" Style="margin-left: 60px"></asp:TextBox>
            </p>
            <asp:Button ID="ButtonSignIn" runat="server" OnClick="ButtonSignIn_Click" Style="margin-left: 105px" Text="Sign In" Width="83px" />

            <p>
                <asp:Label ID="Label3" runat="server" Text="Nume"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Style="margin-left: 63px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Style="margin-left: 37px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Parola"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" Style="margin-left: 62px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="ButtonSignUp" runat="server" OnClick="ButtonSignUp_Click" Style="margin-left: 105px" Text="Sign Up" Width="83px" />
            </p>
            <p>
                <asp:Label ID="LabelEroare" runat="server"></asp:Label>
            </p>
            <asp:Label ID="LabelAutentificare" runat="server"></asp:Label>
            <p>
                <asp:Button ID="ButtonSignOut" runat="server" OnClick="ButtonSignOut_Click" Style="margin-left: 10px" Text="Sign out" Visible="False" />
                <asp:Button ID="ButtonCauta" runat="server" OnClick="ButtonCauta_Click" Style="margin-left: 30px" Text="Cauta produs" Visible="False" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="margin-left: 30px" Text="Vizualizeaza produsele de pe site" Visible="False" />
                <asp:Button ID="ButtonViewWish" runat="server" Style="margin-left: 30px" Text="Vizualizeaza produse din wishlist" Visible="False" OnClick="ButtonViewWish_Click" />
            </p>
            <p>
                <asp:Button ID="Button2GenSemn" runat="server" OnClick="Button2GenSemn_Click" Style="margin-left: 10px" Text="Genereaza semnaturi pentru produse" Visible="False" Width="297px" />
                <asp:Button ID="ButtonAddP" runat="server" OnClick="ButtonAddP_Click" Text="Adauga un produs" Visible="False" Style="margin-left: 17px" />
            </p>
            <asp:Label ID="Label6" runat="server" Text="Descriere" Visible="False" Style="margin-left: 10px"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" Style="margin-left: 30px" Visible="False"></asp:TextBox>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Pret" Visible="False" Style="margin-left: 10px"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" Style="margin-left: 66px" Visible="False"></asp:TextBox>
            </p>
            <p>
                <asp:RadioButton ID="RadioButton1" runat="server" Text="In stoc" Visible="False" />
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Nu e pe stoc" Visible="False" />
            </p>
            <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" Style="margin-left: 10px" />
            <asp:Label ID="Label11" runat="server" Text="Link imagine" Visible="False" Style="margin-left: 10px"></asp:Label>
            <asp:TextBox ID="TextBoxHttp" runat="server" Visible="False"></asp:TextBox>
            <p>
                <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Style="margin-left: 10px" Text="Adauga din stocarea locala" Visible="False" />
                <asp:Button ID="ButtonAddHttp" runat="server" OnClick="ButtonAddHttp_Click" Style="margin-left: 197px" Text="Adauga din HTTP" Visible="False" />
            </p>
            <asp:FileUpload ID="FileUpload3" runat="server" Visible="False" Style="margin-left: 10px" />
            <asp:Button ID="ButtonVideo" runat="server" OnClick="ButtonVideo_Click" Text="Insereaza video" Visible="False" Style="margin-left: 122px" />
            <p>
                <asp:Button ID="ButtonCautaDesc" runat="server" OnClick="ButtonCautaDesc_Click" Text="Cauta dupa denumire" Visible="False" Style="margin-left: 10px" />
                <asp:Button ID="ButtonCautaImg" runat="server" OnClick="ButtonCautaImg_Click" Style="margin-left: 82px" Text="Cauta dupa o imagine de referinta" Visible="False" />
            </p>
            <asp:Label ID="Label8" runat="server" Text="Introdu denumirea produsului" Visible="False" Style="margin-left: 10px"></asp:Label>
            <asp:TextBox ID="TextBoxDen" runat="server" Style="margin-left: 35px" Visible="False"></asp:TextBox>

            <p>
                <asp:Button ID="ButtonAfiseazaDen" runat="server" OnClick="ButtonAfiseazaDen_Click" Text="Afiseaza produsul" Visible="False" Style="margin-left: 10px" />
            </p>
            <asp:Label ID="Label9" runat="server" Text="Alege imaginea de referinta" Visible="False" Style="margin-left: 10px"></asp:Label>
            <asp:FileUpload ID="FileUpload2" runat="server" Style="margin-left: 50px" Visible="False" />
            <p>
                <asp:Button ID="ButtonAfiseazaImg" runat="server" OnClick="ButtonAfiseazaImg_Click" Text="Afiseaza produsul" Visible="False" Style="margin-left: 10px" />
            </p>
            <asp:Button ID="ButtonGrayscale" runat="server" OnClick="ButtonGrayscale_Click" Text="Afiseaza imaginea produsului in oglinda" Visible="False" Width="313px" Style="margin-left: 10px" />
            <p>
                <asp:Button ID="ButtonFlip" runat="server" OnClick="ButtonFlip_Click" Text="Afiseaza imaginea produsului rasturnata" Visible="False" Width="313px" Style="margin-left: 10px" />
            </p>
            <asp:Label ID="Label10" runat="server" Visible="False" Style="margin-left: 10px"></asp:Label>
             <asp:Label ID="Label13" runat="server" Style="margin-left: 10px"></asp:Label>
            <p>
                <asp:Image ID="Image1" runat="server" Height="197px" Visible="False" Width="361px" />
            </p>
            <p>
                <asp:Button ID="ButtonAddWish" runat="server" OnClick="ButtonAddWish_Click" Text="Adauga produsul in wishlist" Visible="False" Width="215px" />
            </p>
            <p>
                <asp:Label ID="Label12" runat="server" Text="Introdu denumirea produsului pentru a vedea videoclipul lui de prezentare" Visible="False"></asp:Label>
                <asp:TextBox ID="TextBoxVideo" runat="server" Style="margin-left: 34px" Visible="False"></asp:TextBox>
            </p>
            <asp:Button ID="ButtonSalvareVideo" runat="server" OnClick="ButtonSalvareVideo_Click" Text="Salveaza videoclipul" Visible="False" />
            <p>
                <asp:Button ID="ButtonAfisareVideo" runat="server" OnClick="ButtonAfisareVideo_Click" Text="Afiseaza videoclipul" Visible="False" />
            </p>
            <video id="video" runat="server" type="video/mp4" autoplay="autoplay" controls="controls" hidden></video>
            <div id="divrb" runat="server" style="display:flex"></div>
        </div>
    </form>
</body>
</html>
