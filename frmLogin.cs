using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace College_Management_System
{
    public partial class frmLogin : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string status = "Available";
        public frmLogin()
        {
            InitializeComponent();
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        string results = null;
        string resultss = null;
        string resultsss = null;
        string resultssss = null;

        string results1 = null;
        string results2 = null;
        string results3 = null;
        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results = Encoding.UTF8.GetString(bytesDecrypted);

            return results;
        }
        public string DecryptText1(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results1 = Encoding.UTF8.GetString(bytesDecrypted);

            return results1;
        }
        public string DecryptText2(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results2 = Encoding.UTF8.GetString(bytesDecrypted);

            return results2;
        }
        public string DecryptText3(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            results3 = Encoding.UTF8.GetString(bytesDecrypted);

            return results3;
        }
        string result = null;
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        public string EncryptText1(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultss = Convert.ToBase64String(bytesEncrypted);

            return resultss;
        }
        public string EncryptText2(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultsss = Convert.ToBase64String(bytesEncrypted);

            return resultsss;
        }
        public string EncryptText3(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            resultssss = Convert.ToBase64String(bytesEncrypted);

            return resultssss;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
          
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {
                if (txtUserName.Text == "ADMIN" && txtPassword.Text == "Jesus@lord1")
                {
                    this.Hide();
                    frmMainMenu frm = new frmMainMenu();
                    frm.User.Text = "ADMIN";
                    frm.UserType.Text = "ADMIN";
                    DateTime dt = DateTime.Today.Date;
                    string dts = DateTime.Now.ToLongTimeString();
                    string currentdate = dt.ToString("dd/MMM/yyyy");
                    string computername = Environment.MachineName;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Successful')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                    cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                    cmd.Parameters["@d1"].Value = txtUserName.Text;
                    cmd.Parameters["@d2"].Value = txtUserName.Text;
                    cmd.Parameters["@d3"].Value = currentdate;
                    cmd.Parameters["@d4"].Value = dts;
                    cmd.Parameters["@d5"].Value = computername;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    frm.Show();
                }
                else
                {
                    EncryptText(txtPassword.Text, "essentialschools");
                    con = new SqlConnection(cs.DBConn);
                    SqlCommand myCommand = default(SqlCommand);
                    myCommand = new SqlCommand("SELECT Username,Name,usertype FROM User_Registration WHERE  Username = @username AND Password = @UserPassword", con);
                    SqlParameter uName = new SqlParameter("@username", SqlDbType.NChar);
                    SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.NChar);
                    uName.Value = txtUserName.Text;
                    uPassword.Value = result;
                    myCommand.Parameters.Add(uName);
                    myCommand.Parameters.Add(uPassword);
                    myCommand.Connection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    if (myReader.Read() == true)
                    {
                        int i;
                        ProgressBar1.Visible = true;
                        ProgressBar1.Maximum = 5000;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 4;
                        ProgressBar1.Step = 1;

                        for (i = 0; i <= 5000; i++)
                        {
                            ProgressBar1.PerformStep();
                        }

                        if(myReader["usertype"].ToString().Trim() == "Student")
                        {
                            string usertypes = myReader["usertype"].ToString().Trim();
                            string realname = myReader["Name"].ToString().Trim();

                            DateTime dt = DateTime.Today.Date;
                            string dts = DateTime.Now.ToLongTimeString();
                            string currentdate = dt.ToString("dd/MMM/yyyy");
                            string computername = Environment.MachineName;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Successful')";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                            cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                            cmd.Parameters["@d1"].Value = txtUserName.Text;
                            cmd.Parameters["@d2"].Value = realname;
                            cmd.Parameters["@d3"].Value = currentdate;
                            cmd.Parameters["@d4"].Value = dts;
                            cmd.Parameters["@d5"].Value = computername;
                            cmd.ExecuteNonQuery();
                            con.Close();
                            this.Hide();
                            frmStudentAcess frm = new frmStudentAcess();
                            frm.password.Text = txtUserName.Text;
                            frm.Username.Text = myReader["Name"].ToString().Trim();
                            frm.Show();
                        }
                        else
                        {
                            string usertypes = myReader["usertype"].ToString().Trim();
                            string realname = myReader["Name"].ToString().Trim();

                            DateTime dt = DateTime.Today.Date;
                            string dts = DateTime.Now.ToLongTimeString();
                            string currentdate = dt.ToString("dd/MMM/yyyy");
                            string computername = Environment.MachineName;
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Successful')";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                            cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                            cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                            cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                            cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                            cmd.Parameters["@d1"].Value = txtUserName.Text;
                            cmd.Parameters["@d2"].Value = realname;
                            cmd.Parameters["@d3"].Value = currentdate;
                            cmd.Parameters["@d4"].Value = dts;
                            cmd.Parameters["@d5"].Value = computername;
                            cmd.ExecuteNonQuery();
                            con.Close();
                            this.Hide();
                            frmMainMenu frm = new frmMainMenu();
                            frm.User.Text = txtUserName.Text;
                            frm.UserType.Text = myReader["Name"].ToString().Trim();
                            frm.Show();
                        }
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb1 = "update User_Registration set Status=@d2 where Username=@d1";
                        cmd = new SqlCommand(cb1);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 30, "Username"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 12, "Status"));
                        cmd.Parameters["@d1"].Value = txtUserName.Text.Trim();
                        cmd.Parameters["@d2"].Value = status;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    else
                    {
                        DateTime dt = DateTime.Today.Date;
                        string dts = DateTime.Now.ToLongTimeString();
                        string currentdate = dt.ToString("dd/MMM/yyyy");
                        string computername = Environment.MachineName;
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string cb = "insert into Logins(UserName,FullNames,Date,Time,ComputerName,Success) VALUES (@d1,@d2,@d3,@d4,@d5,'Failed')";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.NChar, 20, "UserName"));
                        cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NChar, 50, "FullNames"));
                        cmd.Parameters.Add(new SqlParameter("@d3", System.Data.SqlDbType.NChar, 30, "Date"));
                        cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.NChar, 20, "Time"));
                        cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.NChar, 50, "ComputerName"));
                        cmd.Parameters["@d1"].Value = txtUserName.Text;
                        cmd.Parameters["@d2"].Value = txtUserName.Text;
                        cmd.Parameters["@d3"].Value = currentdate;
                        cmd.Parameters["@d4"].Value = dts;
                        cmd.Parameters["@d5"].Value = computername;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Login Failed, Username and Password do not match....Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassword.Clear();
                        txtUserName.Focus();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
            frm.txtUserName.Text = "";
            frm.txtNewPassword.Text = "";
            frm.txtOldPassword.Text = "";
            frm.txtConfirmPassword.Text = "";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRecoveryPassword frm = new frmRecoveryPassword();
            frm.txtEmail.Focus();
            frm.Show();
        }
    }
}
