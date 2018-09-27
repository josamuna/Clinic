using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class UtilisateurFrm : Form
    {
        public UtilisateurFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsutilisateur utilisateur = new clsutilisateur();
        private BindingSource bsrcCreate = new BindingSource();
        private BindingSource bsrcModif = new BindingSource();
        private BindingSource bsrcSupp = new BindingSource();
        private BindingSource bsrcAff = new BindingSource();
        private BindingSource bsrcAff2 = new BindingSource();
        private string userName = "", olPwd = "";
        private int id_personne = 0, id_utilisateur = 0, identifiant_user = 0;
        private bool okDoubleClicDgv = false;
        private string schema_user = "";
        private bool bln1 = false;

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void clearforbindingText(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void clearforbindingCombo(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((ComboBox)ctrl[0]).Focus();
        }

        private void clearforbindingChechBox(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", utilisateur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", utilisateur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", utilisateur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", utilisateur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstCreate(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcCreate, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcCreate, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcCreate, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcCreate, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstDelete(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcSupp, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcSupp, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcSupp, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcSupp, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstModifie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcModif, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcModif, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcModif, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcModif, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        //private void bindingclsDroits()
        //{
        //    cmdDelete.Enabled = false;
        //    Control[] tbcontrols = { cboUtilisateur1 };
        //    clearforbindingCombo(tbcontrols);

        //    setbindingcls(cboUtilisateur1, "Nomuser", 1);
        //}

        private void bindingclsCreate()
        {
            cmdDelete.Enabled = false;
            Control[] tbcontrols = { txtNomUser, txtMotPasse, cboAgent };
            clearforbindingChechBox(tbcontrols);

            setbindingcls(txtNomUser, "Nomuser", 0);
            setbindingcls(txtMotPasse, "Motpass", 0);
            setbindingcls(cboAgent, "Id_agent", 1);
            //setbindingcls(chkActivationUser, "Activation", 0);
        }

        private void bindinglstCreate()
        {
            cmdDelete.Enabled = false;
            Control[] tbcontrols = { txtNomUser, txtMotPasse, cboAgent };
            clearforbindingChechBox(tbcontrols);

            setbindinglstCreate(txtNomUser, "Nomuser", 0);
            setbindinglstCreate(txtMotPasse, "Motpass", 0);
            setbindinglstCreate(cboAgent, "Id_agent", 1);
            //setbindinglstCreate(chkActivationUser, "Activation", 0);
        }

        private void bindinglstDroits()
        {
            cmdDelete.Enabled = false;
            Control[] tbcontrols = { cboUtilisateur1 };
            clearforbindingCombo(tbcontrols);

            setbindinglstCreate(cboUtilisateur1, "Nomuser", 1);
        }

        private void bindingclsDelete()
        {
            cmdDelete.Enabled = false;
            Control[] tbcontrols = { CboUserSup };
            clearforbindingCombo(tbcontrols);

            setbindingcls(CboUserSup, "Id", 0);
        }

        private void bindinglstDelete()
        {
            cmdDelete.Enabled = false;
            Control[] tbcontrols = { CboUserSup };
            clearforbindingCombo(tbcontrols);

            setbindinglstDelete(CboUserSup, "Id", 0);
        }

        private void bindinglstModifie()
        {
            cmdDelete.Enabled = false;
            Control[] tbcontrols = { txtOldMotPasse, cboUtilisateur, chkActivationUserModi };
            clearforbindingChechBox(tbcontrols);

            setbindinglstCreate(txtOldMotPasse, "Motpass", 0);
            setbindinglstCreate(cboUtilisateur, "Id", 1);
            //setbindinglstCreate(txtConfNewMotPasse, "Confmotpass", 0);
            setbindinglstCreate(chkActivationUserModi, "Activation", 0);
        }

        private void New()
        {
            utilisateur = new clsutilisateur();
            bln1 = false;
            bindingclsCreate();
            if (cboAgent.Items.Count > 0) cboAgent.SelectedIndex = 0;
            utilisateur.Activation = chkActivationUser.Checked;
        }

        private void refresh()
        {
            try
            {
                cboAgent.DataSource = clsMetier.GetInstance().getAllClsagent();
                setMembersallcbo(cboAgent, "Nom_complet", "IdAgent");
                cboUtilisateur.DataSource = clsMetier.GetInstance().getAllClsutilisateur();
                setMembersallcbo(cboUtilisateur, "Nomuser", "Id");
                cboUtilisateur1.DataSource = clsMetier.GetInstance().getAllClsutilisateur();
                setMembersallcbo(cboUtilisateur1, "Nomuser", "Id");
                CboUserSup.DataSource = clsMetier.GetInstance().getAllClsutilisateur();
                setMembersallcbo(CboUserSup, "Nomuser", "Id");

                if (cboAgent.Items.Count > 0) cboAgent.SelectedIndex = 0;
                if (cboUtilisateur.Items.Count > 0) cboUtilisateur.SelectedIndex = 0;
                if (CboUserSup.Items.Count > 0) CboUserSup.SelectedIndex = 0;
                if (cboUtilisateur1.Items.Count > 0) cboUtilisateur1.SelectedIndex = -1;

                bsrcCreate.DataSource = clsMetier.GetInstance().getAllClsutilisateur1();
                bsrcAff.DataSource = clsMetier.GetInstance().getAllClsutilisateur1();
                bsrcModif.DataSource = clsMetier.GetInstance().getAllClsutilisateur();
                bsrcSupp.DataSource = clsMetier.GetInstance().getAllClsutilisateur1();
                chkLevelAdmin.Checked = false; 
                chkLevelMedecin.Checked = false; 
                chkLevelInfirmier.Checked = false;
                chkLevelLaborantin.Checked = false;
                chkLevelPharmacien.Checked = false;
                chkLevelCaissier.Checked = false;
                chkLevelMedecinGyneco.Checked = false;
                chkLevelService.Checked = false;
                //bsrcAff2.DataSource = clsMetier.GetInstance().getAllClsutilisateur1(identifiant_user);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmUtilisateur_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrcAff, bsrcCreate, bsrcModif, bsrcSupp };
                DataGridView[] dg = { dgv };
                ComboBox[] cbo = { cboAgent, cboUtilisateur, CboUserSup };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void FrmUtilisateur_Load(object sender, EventArgs e)
        {
            rdUserSeul.Checked = true;
            txtNewMotPasse.Enabled = false;
            cmdAfficherDroit.Enabled = false;
            cmdAccorderDroit.Enabled = false;
            cmdRetirerDroit.Enabled = false;
            activate_desactivetModifieUser(false);

            try
            {
                bindingclsCreate();
                dgv.DataSource = bsrcAff;
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabManage_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //Se produit lorsque l'on change un onglet
            if (tabManage.SelectedIndex == 0) { }
            else if (tabManage.SelectedIndex == 1)
            {
                activate_desactivetModifieUser(false);

                if (bsrcSupp.Count != 0) cmdDelete.Enabled = true;
                if (!okDoubleClicDgv)
                {
                    txtOldMotPasse.Clear();
                    txtNewMotPasse.Clear();
                    txtNewUser.Focus();
                }
            }
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrcAff.Filter = "Nomuser LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            okDoubleClicDgv = true;
            if (dgv.SelectedRows.Count > 0)
            {
                tabMainManage.SelectedIndex = 2;
                //On met les valeurs correspondantes à l'Agent (Utilisateur) Selectionné
                try
                {
                    bsrcModif.DataSource = clsMetier.GetInstance().getAllClsutilisateur2(id_utilisateur);
                    bindinglstModifie();

                    bsrcSupp.DataSource = clsMetier.GetInstance().getAllClsutilisateur2(id_utilisateur);
                    bindinglstDelete();

                    //Modification
                    if (bsrcModif.Count != 0)
                    {
                        //clsutilisateur s = new clsutilisateur();
                        Object[] obj = ((DataRowView)bsrcModif.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrcModif.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("nomuser")) { cboUtilisateur.Text = ((string)obj[i]); userName = ((string)obj[i]); }
                            else if (dtc.ToString().Equals("motpass")) { txtOldMotPasse.Text = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(((string)obj[i])); olPwd = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(((string)obj[i])); }
                            else if (dtc.ToString().Equals("activation")) chkActivationUserModi.Checked = ((bool)obj[i]);
                            else if (dtc.ToString().Equals("activation")) chkActivationUserModi.Checked = ((bool)obj[i]);
                            else if (dtc.ToString().Equals("idUser")) id_utilisateur = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("schema_user")) schema_user = ((string)obj[i]);

                            i++;
                        }

                        //Suppression
                        if (bsrcSupp.Count != 0)
                        {
                            //clsutilisateur s = new clsutilisateur();
                            Object[] obj1 = ((DataRowView)bsrcSupp.Current).Row.ItemArray;
                            int i1 = 0;
                            foreach (DataColumn dtc in ((DataRowView)bsrcSupp.Current).Row.Table.Columns)
                            {
                                if (dtc.ToString().Equals("nomuser")) CboUserSup.Text = ((string)obj1[i1]);
                                else if (dtc.ToString().Equals("idUser")) id_utilisateur = ((int)obj1[i1]);
                                else if (dtc.ToString().Equals("id_personne")) id_personne = ((int)obj1[i1]);
                                else if (dtc.ToString().Equals("schema_user")) schema_user = ((string)obj[i1]);
                                i1++;
                            }
                        }
                    }
                    activate_desactivetModifieUser(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de sélection des informations de l'utilisateur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                txtOldMotPasse.Clear();
                txtNewMotPasse.Clear();
                txtNewUser.Focus();
            }
        }

        private void activate_desactivetModifieUser(bool state)
        {
            cboUtilisateur.Enabled = state;
            txtNewUser.Enabled = state;
            txtOldMotPasse.Enabled = state;
            //txtNewMotPasse.Enabled = state;
            chkActivationUserModi.Enabled = state;
            groupBox2.Enabled = state;
            cmdModifierCompte.Enabled = state;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //Recuperation de l'Id de l'Utilisateur
                if (bsrcAff.Count != 0)
                {
                    Object[] obj = ((DataRowView)bsrcAff.Current).Row.ItemArray;
                    int i = 0;
                    foreach (DataColumn dtc in ((DataRowView)bsrcAff.Current).Row.Table.Columns)
                    {
                        if (dtc.ToString().Equals("idUser")) id_utilisateur = ((int)obj[i]);
                        //else if (dtc.ToString().Equals("id_personne")) id_personne = ((int)obj[i]);
                        i++;
                    }
                    if (utilisateur.Activation.HasValue) chkActivationUser.Checked = (bool)utilisateur.Activation;
                    else chkActivationUser.Checked = false;

                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void cmdNouveauUser_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { cmdValiderUser.Enabled = false; }
        }

        private void cmdValiderUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln1)
                {
                    bindingclsCreate();
                    utilisateur.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkActivationUser.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refresh();
        }

        private void tabMainManage_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //Se produit lorsque l'on change un onglet
            if (tabMainManage.SelectedIndex == 0) { activate_desactivetModifieUser(false); }
            else if (tabMainManage.SelectedIndex == 1)
            {
                if (cboAgent.Items.Count > 0) cboAgent.SelectedIndex = 0;
                gpParamServeur.Enabled = false;
                chkParamServeur.Checked = false;
                activate_desactivetModifieUser(false);
            }
            else if (tabMainManage.SelectedIndex == 2)
            {
                rdUserSeul.Checked = true; 
                if (cboUtilisateur.Items.Count > 0) cboUtilisateur.SelectedIndex = 0;
                if (CboUserSup.Items.Count > 0) CboUserSup.SelectedIndex = 0;
            }
            else if (tabMainManage.SelectedIndex == 3) {activate_desactivetModifieUser(false);}
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrcSupp.DataSource != null)
                    {
                        clsutilisateur s = new clsutilisateur();
                        Object[] obj = ((DataRowView)bsrcSupp.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrcSupp.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("nomuser")) { s.Nomuser = ((string)obj[i]); userName = ((string)obj[i]); }
                            else if (dtc.ToString().Equals("motpass")) { s.Motpass = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(((string)obj[i])); olPwd = ((string)obj[i]); }
                            else if (dtc.ToString().Equals("activation")) s.Activation = ((bool)obj[i]);
                            else if (dtc.ToString().Equals("idUser")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_agent")) s.Id_agent = ((int)obj[i]);
                            else if (dtc.ToString().Equals("droits")) s.Droits = ((string)obj[i]);
                            else if (dtc.ToString().Equals("schema_user")) s.Schema_user = ((string)obj[i]);
                            i++;
                        }
                        new clsutilisateur().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkActivationUser_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                utilisateur.Activation = chkActivationUser.Checked;
            }
            catch (Exception) { }
        }

        private void cmdModifierCompte_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsrcModif.DataSource != null)
                {
                    //////if (bsrcModif.DataSource != null)
                    //////{
                    //////    clsutilisateur s = (clsutilisateur)bsrcModif.Current;
                    //////    new clsutilisateur().update(s);
                    //////    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //////}

                    ////bindingclsModifie(); 
                    ////Arrangement car le bindingclsModifie ne bosse pas
                    clsutilisateur s = new clsutilisateur();
                    Object[] obj = ((DataRowView)bsrcModif.Current).Row.ItemArray;
                    int i = 0;
                    foreach (DataColumn dtc in ((DataRowView)bsrcModif.Current).Row.Table.Columns)
                    {
                        if (dtc.ToString().Equals("nomuser"))
                        {
                            if (rdUserSeul.Checked)
                            {
                                clsDoTraitement.oldUser = ((string)obj[i]);
                                clsDoTraitement.newUser = txtNewUser.Text;
                                s.Nomuser = clsDoTraitement.newUser;
                            }
                            else if (rdPwdSeul.Checked) 
                            {
                                clsDoTraitement.oldUser = ((string)obj[i]);
                            }
                            else if (rdUserEtPwd.Checked)
                            {
                                clsDoTraitement.oldUser = ((string)obj[i]);
                                clsDoTraitement.newUser = txtNewUser.Text;
                                s.Nomuser = clsDoTraitement.newUser;
                            }
                            else if (rdActivationUser.Checked)
                            {
                                s.Nomuser = ((string)obj[i]);
                            }
                        }
                        else if (dtc.ToString().Equals("motpass"))
                        {
                            if (rdUserSeul.Checked) 
                            {
                                clsDoTraitement.oldPassword = CryptageJosam_LIB.clsMetier.GetInstance().doDeCrypte(((string)obj[i]));
                            }
                            else if (rdPwdSeul.Checked) 
                            {
                                clsDoTraitement.newPassword = txtNewMotPasse.Text;
                                s.Motpass = clsDoTraitement.newPassword;
                            }
                            else if (rdUserEtPwd.Checked)
                            {
                                clsDoTraitement.newPassword = txtNewMotPasse.Text; 
                                s.Motpass = clsDoTraitement.newPassword;
                            }
                            else if (rdActivationUser.Checked) { }
                        }
                        //else if (dtc.ToString().Equals("activation")) s.Activation = ((bool)obj[i]);
                        else if (dtc.ToString().Equals("idUser")) s.Id = ((int)obj[i]);
                        else if (dtc.ToString().Equals("id_agent")) s.Id_agent = ((int)obj[i]);
                        else if (dtc.ToString().Equals("schema_user")) s.Schema_user = ((string)obj[i]);
                        i++;
                    }

                    s.Activation = chkActivationUserModi.Checked;
                    clsDoTraitement.activationUser = (bool)s.Activation;
                    //Fin Arrangement
                    //Verification des valeurs 

                    s.Nomuser = cboUtilisateur.Text;

                    //Recupération des ancienne valeur

                    if (rdUserSeul.Checked)
                    {
                        //Modification de l'utilisateur seulement
                        if (!txtNewUser.Text.Equals(""))
                        {
                            clsDoTraitement.etat_modification_user = 1;
                            new clsutilisateur().update(s);
                            MessageBox.Show("Modification effectuée!", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.New();
                            refresh();
                        }
                        else
                        {
                            MessageBox.Show("Le nom de l'utilisateur ne peut être vide", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNewUser.Focus();
                        }
                    }
                    else if (rdPwdSeul.Checked)
                    {
                        //Modification du mot de passe seulement
                        if (!txtOldMotPasse.Text.Equals(""))
                        {
                            if (!txtNewMotPasse.Text.Equals(""))
                            {
                                clsDoTraitement.etat_modification_user = 2;
                                new clsutilisateur().update(s);
                                MessageBox.Show("Modification effectuée!", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.New();
                                refresh();
                            }
                            else
                            {
                                MessageBox.Show("Le nouveau mot de passe ne peut être vide", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtNewMotPasse.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("L'ancien mot de passe ne peut être vide", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtOldMotPasse.Focus();
                        }
                    }
                    else if (rdUserEtPwd.Checked)
                    {
                        //Modification du nom d'utilisateur et du mot de passe
                        if (!txtNewUser.Text.Equals(""))
                        {
                            if (!txtOldMotPasse.Text.Equals(""))
                            {
                                if (!txtNewMotPasse.Text.Equals(""))
                                {
                                    clsDoTraitement.etat_modification_user = 3;
                                    new clsutilisateur().update(s);
                                    MessageBox.Show("Modification effectuée!", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.New();
                                    refresh();
                                }
                                else
                                {
                                    MessageBox.Show("Le nouveau mot de passe ne peut être vide", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtNewMotPasse.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("L'ancien mot de passe ne peut être vide", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtOldMotPasse.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le nom de l'utilisateur ne peut être vide", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNewUser.Focus();
                        }
                    }
                    else if (rdActivationUser.Checked)
                    {
                        //Modification du nom d'utilisateur et du mot de passe
                        clsDoTraitement.etat_modification_user = 4;
                        new clsutilisateur().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.New();
                        refresh();
                    }
                }
                activate_desactivetModifieUser(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification, " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdUserSeul_CheckedChanged(object sender, EventArgs e)
        {
            clsDoTraitement.etat_modification_user = 1;
            txtNewMotPasse.Enabled = false;
            txtNewUser.Enabled = true;
            txtNewMotPasse.Clear();
            txtMotPasse.Clear();
            txtNewUser.Focus();
        }

        private void rdPwdSeul_CheckedChanged(object sender, EventArgs e)
        {
            clsDoTraitement.etat_modification_user = 2;
            txtNewUser.Enabled = false;
            txtNewMotPasse.Enabled = true;
            txtNewUser.Clear();
            txtNewMotPasse.Focus();
        }

        private void rdUserEtPwd_CheckedChanged(object sender, EventArgs e)
        {
            clsDoTraitement.etat_modification_user = 3;
            txtNewUser.Enabled = true;
            txtNewMotPasse.Enabled = true;
            txtNewUser.Clear();
            txtNewMotPasse.Clear();
            txtMotPasse.Clear();
            txtNewUser.Focus();
        }

        private void cboUtilisateur1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAfficherDroit.Enabled = true;

            try
            {
                identifiant_user = clsMetier.GetInstance().getClsutilisateurUser(cboUtilisateur1.Text).Id;
            }
            catch (Exception) { }
        }

        private void cmdAfficherDroit_Click(object sender, EventArgs e)
        {
            try
            {
                //bindingclsDroits();
                bsrcAff2.DataSource = clsMetier.GetInstance().getAllClsutilisateur1(identifiant_user);
                dgv1.DataSource = bsrcAff2;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            cmdAccorderDroit.Enabled = true;
            cmdRetirerDroit.Enabled = true;
        }

        private void chkLevelAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLevelAdmin.Checked)
            {
                chkLevelMedecin.Enabled = false;
                chkLevelCaissier.Enabled = false;
                chkLevelInfirmier.Enabled = false;
                chkLevelLaborantin.Enabled = false;
                chkLevelMedecinGyneco.Enabled = false;
                chkLevelPharmacien.Enabled = false;
                chkLevelService.Enabled = false;
            }
            else
            {
                chkLevelMedecin.Enabled = true;
                chkLevelCaissier.Enabled = true;
                chkLevelInfirmier.Enabled = true;
                chkLevelLaborantin.Enabled = true;
                chkLevelMedecinGyneco.Enabled = true;
                chkLevelPharmacien.Enabled = true;
                chkLevelService.Enabled = true;
            }
        }

        private void cmdAccorderDroit_Click(object sender, EventArgs e)
        {
            bool okCheched = false;
            bool ok0 = true, ok1 = true, ok2 = true, ok3 = true, ok4 = true, ok5 = true, ok6 = true, ok7 = true;
            List<int> liste = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                if (chkLevelAdmin.Checked && ok0)
                {
                    liste.Add(0);
                    ok0 = false;
                }
                else if (chkLevelMedecin.Checked && ok1)
                {
                    liste.Add(1);
                    ok1 = false;
                }
                else if (chkLevelInfirmier.Checked && ok2)
                {
                    liste.Add(2);
                    ok2 = false;
                }
                else if (chkLevelLaborantin.Checked && ok3)
                {
                    liste.Add(3);
                    ok3 = false;
                }
                else if (chkLevelPharmacien.Checked && ok4)
                {
                    liste.Add(4);
                    ok4 = false;
                }
                else if (chkLevelCaissier.Checked && ok5)
                {
                    liste.Add(5);
                    ok5 = false;
                }
                else if (chkLevelMedecinGyneco.Checked && ok6)
                {
                    liste.Add(6);
                    ok6 = false;
                }
                else if (chkLevelService.Checked && ok7)
                {
                    liste.Add(7);
                    ok7 = false;
                }
            }

            if (chkLevelAdmin.Checked || chkLevelMedecin.Checked || chkLevelInfirmier.Checked ||
                chkLevelLaborantin.Checked || chkLevelPharmacien.Checked || chkLevelCaissier.Checked ||
                chkLevelMedecinGyneco.Checked || chkLevelService.Checked) okCheched = true;
            if (okCheched)
            {
                try
                {
                    clsutilisateur ut = new clsutilisateur();
                    //string nom_utilisateur = clsMetier.GetInstance().getSchemaUser(((clsutilisateur)cboUtilisateur1.SelectedItem).Id);
                    string[] items = clsMetier.GetInstance().getLogin_SchemaUser(identifiant_user);
                    clsMetier.GetInstance().grantPermission(liste, items[0], items[1]);

                    //Recupération des tous les droit du user pour mis à jour
                    int increment = 0;
                    int taille = liste.Count;
                    string droit = "";
                    foreach (int str in liste)
                    {
                        increment++;
                        if (increment == taille)
                        {
                            if (str == 0) droit = droit + "Administrateur";
                            else if (str == 1) droit = droit + "Médecin";
                            else if (str == 2) droit = droit + "Infirmier";
                            else if (str == 3) droit = droit + "Laborantin";
                            else if (str == 4) droit = droit + "Pharmacien";
                            else if (str == 5) droit = droit + "Caissier";
                            else if (str == 6) droit = droit + "Médecin gynéco.";
                            else if (str == 7) droit = droit + "Service";
                        }
                        else
                        {
                            if (str == 0) droit = droit + "Administrateur,";
                            else if (str == 1) droit = droit + "Médecin,";
                            else if (str == 2) droit = droit + "Infirmier,";
                            else if (str == 3) droit = droit + "Laborantin,";
                            else if (str == 4) droit = droit + "Pharmacien,";
                            else if (str == 5) droit = droit + "Caissier,";
                            else if (str == 6) droit = droit + "Médecin gynéco.,";
                            else if (str == 7) droit = droit + "Service,";
                        }
                    }

                    clsMetier.GetInstance().updateClsutilisateur_droit(identifiant_user, droit);
                    
                    //On met à jour les droits de l'utilisateur
                    MessageBox.Show("Droits attribué avec succès", "Attributions droits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'attribution des droits, " + ex.Message, "Attributions droits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else MessageBox.Show("Veuillez choisir une catégorie des droits à attribuer à l'utilisateur svp !!","Attributions droits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            cboUtilisateur1.SelectedIndex = 0;
        }

        private void cmdRetirerDroit_Click(object sender, EventArgs e)
        {
            bool okCheched = false;

            List<int> liste_droit_user = new List<int>();
            List<int> listeDelete = new List<int>();
            List<int> listeDroit = new List<int>();
            List<int> listeCheckBox = new List<int>();

            //On récuperer l'etat des droit que le user a cocher
            if (chkLevelAdmin.Checked) listeCheckBox.Add(0);
            if (chkLevelMedecin.Checked) listeCheckBox.Add(1);
            if (chkLevelInfirmier.Checked) listeCheckBox.Add(2);
            if (chkLevelLaborantin.Checked) listeCheckBox.Add(3);
            if (chkLevelPharmacien.Checked) listeCheckBox.Add(4);
            if (chkLevelCaissier.Checked) listeCheckBox.Add(5);
            if (chkLevelMedecinGyneco.Checked) listeCheckBox.Add(6);
            if (chkLevelService.Checked) listeCheckBox.Add(7);

            //On récuperer les anciens droits de l'utilisateur choisi
            try
            {
                liste_droit_user = clsMetier.GetInstance().getDroitsUser(identifiant_user);

                if (liste_droit_user.Count == 0) throw new Exception("L'utilisateur n'a aucun droit à lui retiré !!");

                int item = 0;

                foreach (int str in listeCheckBox)
                {
                    foreach (int str1 in liste_droit_user)
                    {
                        if (str == str1)
                        {
                            //Correspondance avec droit existant pour revocation 
                            listeDelete.Add(str);
                        }
                        else
                        {
                            //Aucune correspondance trouvee entre le droit et celui cocher
                            item++;
                        }
                    }
                    if (item == liste_droit_user.Count) 
                    {
                        //On genere une erreur car le droit a revoker n'appartient pas au user
                        throw new Exception("Vous assayez de retirer un droit que l'utilisateur n'a pas !!!");
                    }
                    item = 0;
                }

                if (chkLevelAdmin.Checked || chkLevelMedecin.Checked || chkLevelInfirmier.Checked ||
                    chkLevelLaborantin.Checked || chkLevelPharmacien.Checked || chkLevelCaissier.Checked ||
                    chkLevelMedecinGyneco.Checked || chkLevelService.Checked) okCheched = true;
                if (okCheched)
                {
                    try
                    {
                        clsutilisateur ut = new clsutilisateur();
                        //string nom_utilisateur = clsMetier.GetInstance().getSchemaUser(((clsutilisateur)cboUtilisateur1.SelectedItem).Id);
                        string[] items = clsMetier.GetInstance().getLogin_SchemaUser(identifiant_user);
                        clsMetier.GetInstance().revokePermission(liste_droit_user, items[0], items[1]);

                        //Mise a jour des droits non revoke qui seront ceux ne se trouvant pas dans la liste liste
                        int tailleDelete = 0;
                        foreach (int str in liste_droit_user)
                        {
                            foreach (int str1 in listeDelete)
                            {
                                if (str == str1)
                                {
                                    //Droit revoke et on ne fait rien 
                                }
                                else
                                {
                                    //Droit a ne pas revoke mais a garder
                                    tailleDelete++;                                    
                                }
                            }
                            if(tailleDelete == listeDelete.Count) listeDroit.Add(str);
                            tailleDelete = 0;
                        }

                        //Recupération des tous les droit du user pour mis à jour
                        int increment = 0;
                        int taille = listeDroit.Count;
                        string droit = "";
                        if (taille == 0) droit = "Aucun";
                        else
                        {
                            foreach (int str in listeDroit)
                            {
                                increment++;
                                if (increment == taille)
                                {
                                    if (str == 0) droit = droit + "Administrateur";
                                    else if (str == 1) droit = droit + "Médecin";
                                    else if (str == 2) droit = droit + "Infirmier";
                                    else if (str == 3) droit = droit + "Laborantin";
                                    else if (str == 4) droit = droit + "Pharmacien";
                                    else if (str == 5) droit = droit + "Caissier";
                                    else if (str == 6) droit = droit + "Médecin gynéco.";
                                    else if (str == 7) droit = droit + "Service";
                                }
                                else
                                {
                                    if (str == 0) droit = droit + "Administrateur,";
                                    else if (str == 1) droit = droit + "Médecin,";
                                    else if (str == 2) droit = droit + "Infirmier,";
                                    else if (str == 3) droit = droit + "Laborantin,";
                                    else if (str == 4) droit = droit + "Pharmacien,";
                                    else if (str == 5) droit = droit + "Caissier,";
                                    else if (str == 6) droit = droit + "Médecin gynéco.,";
                                    else if (str == 7) droit = droit + "Service,";
                                }
                            }
                        }

                        clsMetier.GetInstance().updateClsutilisateur_droit(identifiant_user, droit);

                        //On met à jour les droits de l'utilisateur
                        MessageBox.Show("Droits retirés avec succès", "Retrait droits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors du retrait des droits, " + ex.Message, "Retrait droits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else MessageBox.Show("Veuillez choisir une catégorie des droits à retirer à l'utilisateur svp !!", "Retrait droits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du retrait des droits, " + ex.Message, "Retrait droits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }  
            cboUtilisateur1.SelectedIndex = 0;
        }

        private void cmdLoadParam_Click(object sender, EventArgs e)
        {
            try
            {
                //Charement des param de connexion                
                List<string> lstValues = clsDoTraitement.GetInstance().loadParam(1);
                txtServeur.Text = lstValues[0];
                txtBD.Text = lstValues[1];
                txtVersion.Text = lstValues[2];
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erreur lors du chargement des paramètres de connexion, " + ex.Message, "Paramètres de connexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                //Enregistrement des param de connexion                
                clsDoTraitement.GetInstance().saveParamConnection(txtServeur.Text, txtBD.Text, "", null, 1,txtVersion.Text.ToLower());
                MessageBox.Show("Enregistrement effectué avec succès", "Paramètres de connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServeur.Clear();
                txtBD.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement des paramètres de connexion, " + ex.Message, "Paramètres de connexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkParamServeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParamServeur.Checked) gpParamServeur.Enabled = true;
            else gpParamServeur.Enabled = false;
        }

        private void rdActivationUser_CheckedChanged(object sender, EventArgs e)
        {
            txtOldMotPasse.Enabled = false;
            txtNewMotPasse.Enabled = false;
            txtNewUser.Enabled = false;
            txtNewMotPasse.Enabled = false;
            txtNewUser.Clear();
            txtNewMotPasse.Focus();
        }
    }
}
