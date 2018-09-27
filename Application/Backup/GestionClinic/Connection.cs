using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionClinic_LIB;


namespace GestionClinic_WIN
{
    public partial class Connection : Form
    {
        clsConnexion connection = new clsConnexion();
        public Connection()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private frmMainMenu frmMainMenu = new frmMainMenu();
        //"superuser", "superpassword"
        public frmMainMenu FrmMainMenu
        {
            get { return frmMainMenu; }
            set { frmMainMenu = value; }
        }

        private bool CallVerifieConnect()
        
        {
            clsutilisateur utilisateur = new clsutilisateur();
            bool ok = false;
            utilisateur.Nomuser = txtNomUser.Text;
            utilisateur.Motpass = txtMotPass.Text;

            //int increment = 0;
            string[] nbdroit = clsMetier.GetInstance().verifieLoginUser(utilisateur.Nomuser, utilisateur.Motpass)[2].Split(',');

            foreach (string str in nbdroit)
            {
                if (str.Equals("10")) throw new Exception("Cet utilisateur n'a encore aucun droit sur l'application");
                else if (str.Equals("20")) throw new Exception("Cet utilisateur n'a pas encore été activé et ne peut pas se connecter à l'application");
                else
                {
                    //increment++;
                    //if (increment == clsDoTraitement.nombre_droit) 
                        clsDoTraitement.valueUser.Add(str);
                    //else clsDoTraitement.valueUser.Add(str + ",");
                    ok = true;
                }
            }

            if (ok)
            {
                MessageBox.Show("Connexion réussie", "Connexion à la base de données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Dispose();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Echec de l'authentification de l'utilisateur", "Authentification de l'utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomUser.Clear();
                txtMotPass.Clear();
                txtNomUser.Focus();
            }
            return ok;
        }

        public void connecter() 
        {
            connection.User = txtNomUser.Text;
            connection.Pwd = txtMotPass.Text;

            clsMetier.GetInstance().Initialize(connection, 1);
            if (clsMetier.GetInstance().isConnect())
            {
                if (CallVerifieConnect())
                {
                    //Enregistrement des param de connexion
                    clsDoTraitement.GetInstance().saveParamConnection(connection.Serveur, connection.DB, connection.User, null, 1, connection.Version);
                    frmMainMenu.enabledMenu(true, "Statut: Connecté | " + "Utilisateur: " + txtNomUser.Text + " | Instance: " + connection.Serveur);

                    //Recupération bd connectée
                    try
                    {
                        clsMetier.bdEnCours = clsMetier.GetInstance().getCurrentDataBase();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            clsDoTraitement.valueUser.Clear();
            frmMainMenu.desabledMenu("Interface Principale");
            try
            {
                //Chardement des parametres de connexion 
                //Ici si le fichier est vide ou qu'il n'existe pas,on charge des paramètres par défaut
                List<string> lstValues = clsDoTraitement.GetInstance().loadParam(1);
                if (lstValues.Count == 0)
                {
                    //On met des paramètres par défaut
                    clsDoTraitement.GetInstance().saveParamConnection(@"127.0.0.1", "gestionclinic", null, null, 1,"complete");
                    List<string> lstValues2 = clsDoTraitement.GetInstance().loadParam(1);
                    connection.Serveur = lstValues2[0];
                    connection.DB = lstValues2[1];
                    connection.Version = lstValues2[2];
                }
                else
                {
                    //On charge les parametres qu'il contient
                    connection.Serveur = lstValues[0];
                    connection.DB = lstValues[1];
                    connection.Version = lstValues[2];
                }
                //connection.User = lstValues[2];
            }
            catch (Exception) { }
            //this.MdiParent.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
                connecter();
                clsDoTraitement.id_Agent_Connecte = clsMetier.GetInstance().getAllClsutilisateur1(txtNomUser.Text).Id_agent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connexion à la base de données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.MdiParent.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void txtMotPass_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    connecter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connexion à la base de données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
