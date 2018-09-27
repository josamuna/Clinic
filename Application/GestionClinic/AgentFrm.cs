using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class AgentFrm : Form
    {
        public AgentFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsagent agent = new clsagent();
        clspersonne personne = new clspersonne();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void unloadData()
        {
            bsrc.Dispose();
            dgvAgent.Dispose();
            cboCategorieAgent.Dispose();
            cboFonction.Dispose();
            cboQualification.Dispose();
            cboService.Dispose();
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtMatriculeAgent, txtNumInss, txtDateEngagement, cboQualification, cboFonction, cboCategorieAgent, cboService, txtGrade };
            clearforbinding(tbcontrols);

            setbindingcls(txtMatriculeAgent, "Matricule", 0);
            setbindingcls(txtNumInss, "Numeroinss", 0);
            setbindingcls(txtDateEngagement, "Dateangagement", 0);
            setbindingcls(cboQualification, "Id_qualification", 1);
            setbindingcls(cboFonction, "Id_fonction", 1);
            //setbindingcls(txtPersonne, "Nom", 0);
            setbindingcls(cboCategorieAgent, "Id_categorieagent", 1);
            setbindingcls(cboService, "Id_service", 1);
            setbindingcls(txtGrade, "Grade", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtMatriculeAgent, txtPersonne, txtNumInss, txtDateEngagement, cboQualification, cboFonction, cboCategorieAgent, cboService, txtGrade };
            pbPhotoPersonne.DataBindings.Clear();
            clearforbinding(tbcontrols);

            setbindinglst(txtMatriculeAgent, "Matricule", 0);
            setbindinglst(txtNumInss, "Numeroinss", 0);
            setbindinglst(txtDateEngagement, "Dateangagement", 0);
            setbindinglst(cboQualification, "Id_qualification", 1);
            setbindinglst(cboFonction, "Id_fonction", 1);
            setbindinglst(txtPersonne, "Nom", 0);
            setbindinglst(cboCategorieAgent, "Id_categorieagent", 1);
            setbindinglst(cboService, "Id_service", 1);
            setbindinglst(txtGrade, "Grade", 0);
        }

        private void clearforbinding(Control[] ctrl)
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

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", agent, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", agent, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", agent, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", agent, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            agent = new clsagent();
            bln = false;
            bindingcls();

            btnAfficherDonnees.Enabled = false;
            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtMatriculeAgent.Clear();
            txtSexe.Clear();
            txtEtatCivil.Clear();
            txtNumInss.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtGrade.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsagent1(-100);
                dgvAgent.DataSource = bsrc;

                if (cboFonction.Items.Count > 0) cboFonction.SelectedIndex = 0;
                if (cboQualification.Items.Count > 0) cboQualification.SelectedIndex = 0;
                if (cboCategorieAgent.Items.Count > 0) cboCategorieAgent.SelectedIndex = 0;
                if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
            }
            catch (Exception) { }

            RecherchePersonneFrm frm = new RecherchePersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();

            if (clsDoTraitement.doubleclicRecherchePersonneDg)
            {
                btnSave.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneDg = false;
                txtPersonne.Text = clsDoTraitement.FullNamePersonne;
            }
            else btnSave.Enabled = false;
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void refresh()
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtMatriculeAgent.Clear();
            txtSexe.Clear();
            txtEtatCivil.Clear();
            txtNumInss.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtGrade.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsagent1(-100);
                dgvAgent.DataSource = bsrc;
            }
            catch (Exception) { }

            try
            {
                cboFonction.DataSource = clsMetier.GetInstance().getAllClsfonction();
                setMembersallcbo(cboFonction, "Designation", "Id");
                cboQualification.DataSource = clsMetier.GetInstance().getAllClsqualification();
                setMembersallcbo(cboQualification, "Designation", "Id");
                cboCategorieAgent.DataSource = clsMetier.GetInstance().getAllClscategorieagent();
                setMembersallcbo(cboCategorieAgent, "Designation", "Id");
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmAgentcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dgv = { dgvAgent };
                ComboBox[] cbo = { cboCategorieAgent, cboCategorieAgent, cboFonction, cboQualification, cboService };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dgv, cbo);
            }
            catch (Exception) { } 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    agent.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsagent s = new clsagent();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("matricule")) s.Matricule = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("numeroinss")) s.Numeroinss = (((string)obj[i]) == DBNull.Value.ToString()) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("grade")) s.Grade = (((string)obj[i]) == DBNull.Value.ToString()) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("dateangagement")) s.Dateangagement = ((DateTime)obj[i]);
                            else if (dtc.ToString().Equals("idAg")) s.IdAgent = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_fonction")) s.Id_fonction = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_qualification")) s.Id_qualification = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_categorieagent")) s.Id_categorieagent = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_service")) s.Id_service = ((int)obj[i]);
                            i++;
                        }
                        new clsagent().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des informations du malade sélectionné =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //this.New();
            //refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        clsagent s = new clsagent();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("matricule")) s.Matricule = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("numeroinss")) s.Numeroinss = (((string)obj[i]) == DBNull.Value.ToString()) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("grade")) s.Grade = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("dateangagement")) s.Dateangagement = ((DateTime)obj[i]);
                            else if (dtc.ToString().Equals("idAg")) s.IdAgent = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_fonction")) s.Id_fonction = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_qualification")) s.Id_qualification = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_categorieagent")) s.Id_categorieagent = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_service")) s.Id_service = ((int)obj[i]);
                            i++;
                        }
                        new clsagent().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.New();
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAjouterQualifaction_Click(object sender, EventArgs e)
        {
            QualificationFrm form = new QualificationFrm();
            form.setFormPrincipal(principal);
            form.Icon = this.Icon;
            form.ShowDialog();
        }

        private void lblAjouterFonction_Click(object sender, EventArgs e)
        {
            FonctionFrm form = new FonctionFrm();
            form.setFormPrincipal(principal);
            form.Icon = this.Icon;
            form.ShowDialog();
        }

        private void cboQualification_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormQualification)
            {
                try
                {
                    cboQualification.DataSource = clsMetier.GetInstance().getAllClsqualification();
                }
                catch (Exception) { }
            }
        }

        private void cboFonction_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormFonction)
            {
                try
                {
                    cboFonction.DataSource = clsMetier.GetInstance().getAllClsfonction();
                }
                catch (Exception) { }
            }
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Matricule LIKE '%" + txtSeach.Text + "%' OR NumeroInss LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void FrmAgentcs_Load(object sender, EventArgs e)
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            bindingcls();
            dgvAgent.DataSource = bsrc;

            if (cboFonction.Items.Count > 0) cboFonction.SelectedIndex = 0;
            if (cboQualification.Items.Count > 0) cboQualification.SelectedIndex = 0;
            if (cboCategorieAgent.Items.Count > 0) cboCategorieAgent.SelectedIndex = 0;
            if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;

            try
            {
                cboFonction.DataSource = clsMetier.GetInstance().getAllClsfonction();
                setMembersallcbo(cboFonction, "Designation", "Id");
                cboQualification.DataSource = clsMetier.GetInstance().getAllClsqualification();
                setMembersallcbo(cboQualification, "Designation", "Id");
                cboCategorieAgent.DataSource = clsMetier.GetInstance().getAllClscategorieagent();
                setMembersallcbo(cboCategorieAgent, "Designation", "Id");
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulante", "Chargement des listes déroulante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }
        }

        private void loadData()
        {
            bsrc.DataSource = clsMetier.GetInstance().getAllClsagent1(clsDoTraitement.Identifiant_Agent);

            try
            {
                personne = clsMetier.GetInstance().getClspersonne(clsDoTraitement.Identifiant_Personne);
                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;

                txtPersonne.Text = personne.Nom + " " + (string.IsNullOrEmpty(personne.Postnom) ? "" : personne.Postnom) + " " + (string.IsNullOrEmpty(personne.Prenom) ? "" : personne.Prenom);

                try
                {
                    if (personne.Photo != null) pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                    else pbPhotoPersonne.Image = null;
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }

                bindignlst();
                bln = true;
            }
            catch (Exception) { }
        }

        private void lblCategorieAgent_Click(object sender, EventArgs e)
        {
            CategorieAgentFrm form = new CategorieAgentFrm();
            form.setFormPrincipal(principal);
            form.Icon = this.Icon;
            form.ShowDialog();
        }

        private void cboCategorieAgent_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormCategorieAgent)
            {
                try
                {
                    cboCategorieAgent.DataSource = clsMetier.GetInstance().getAllClscategorieagent();
                }
                catch (Exception) { }
            }
        }

        private void lblAddPersonne_Click(object sender, EventArgs e)
        {
            PersonneFrm form = new PersonneFrm();
            form.setFormPrincipal(principal);
            form.Icon = this.Icon;
            form.ShowDialog();
        }

        private void cboService_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormService)
            {
                try
                {
                    cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                }
                catch (Exception) { }
            }
        }

        private void lblAjouterService_Click(object sender, EventArgs e)
        {
            ServiceFrm form = new ServiceFrm();
            form.setFormPrincipal(principal);
            form.Icon = this.Icon;
            form.ShowDialog();
        }

        private void txtPersonne_DoubleClick(object sender, EventArgs e)
        {
            RecherchePersonneAgentFrm frm = new RecherchePersonneAgentFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();

            if (clsDoTraitement.doubleclicRecherchePersonneAgentDg) btnAfficherDonnees.Enabled = true;
            else btnAfficherDonnees.Enabled = false;
        }

        private void btnAfficherDonnees_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneAgentDg = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des informations du malade sélectionné =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
