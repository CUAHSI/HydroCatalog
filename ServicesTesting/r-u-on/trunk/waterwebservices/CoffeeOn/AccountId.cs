using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ruon;

namespace CoffeeOn
{
    /// <summary>
    /// This form is used to showcase all the possible ways to get the user's account id
    /// </summary>
    public partial class AccountId : Form
    {
        string value;


        /// <summary>
        /// C'tor
        /// </summary>
        public AccountId()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get the account id;
        /// </summary>
        /// <returns>
        /// The account id or null if cancel was clicked
        /// </returns>
        public static string Get()
        {
            AccountId accountId = new AccountId();
            try
            {
                return accountId.ShowDialog() == DialogResult.OK ? accountId.value : null;
            }
            finally
            {
                accountId.Dispose();
            }
        }

        private void AccountId_FormClosing(object sender, FormClosingEventArgs ev)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:
                            value = Account.ResolveAccountID(email.Text, password.Text);
                            break;
                        case 1:
                            value = AccountIdBox.Text;
                            break;
                        case 2:
                            if (c_pwd1.Text != c_pwd2.Text)
                            {
                                throw new Exception("The password fields do not match");
                            }
                            value = Account.CreateAccount(c_email.Text, c_pwd1.Text, c_parent_aid.Text);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ev.Cancel = true;
            }
        }
    }
}