using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class AccouchementFrm : Form
    {
        public AccouchementFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsaccouchement accouchement = new clsaccouchement();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void clearforbinding(Control[] ctrl)
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

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            lblEnfant.Enabled = false;
            Control[] tbcontrols = { txtLieu, txtDate, txtTraitement, txtBCG, txtVat, txtDegree, cbotype, txtIdFemmeEnceintePers, txtIdAccouchement, txtEtatPaiement };
            clearforbinding(tbcontrols);

            txtIdFemmeEnceintePers.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
            txtIdAccouchement.Text = clsDoTraitement.IdAccouchement.ToString();
            setbindingcls(txtLieu, "Lieu", 0);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtTraitement, "Traitement", 0);
            setbindingcls(txtBCG, "Bcg", 0);
            setbindingcls(txtVat, "Vat", 0);
            setbindingcls(txtDegree, "Degree", 0);
            setbindingcls(cbotype, "Id_typeaccouchement", 1);
            setbindingcls(txtIdFemmeEnceintePers, "Id_maladegrosse", 0);
            setbindingcls(txtEtatPaiement, "Etatpaiement", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtLieu, txtDate, txtTraitement, txtBCG, txtVat, txtDegree, cbotype, txtIdFemmeEnceintePers, txtIdAccouchement, txtEtatPaiement };
            clearforbinding(tbcontrols);

            setbindinglst(txtLieu, "Lieu", 0);
            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtTraitement, "Traitement", 0);
            setbindinglst(txtBCG, "Bcg", 0);
            setbindinglst(txtVat, "Vat", 0);
            setbindinglst(txtDegree, "Degree", 0);
            setbindinglst(cbotype, "Id_typeaccouchement", 1);
            setbindinglst(txtEtatPaiement, "Etatpaiement", 0);

            //Recuperation de l'Id de la femme enceinte
            setbindinglst(txtIdFemmeEnceintePers, "Id_maladegrosse", 0);
            clsDoTraitement.IdFemmeEnceinte = Convert.ToInt32(txtIdFemmeEnceintePers.Text);

            //Recuperation de l'Id de l'Accouchement
            setbindinglst(txtIdAccouchement, "Id", 0);
            clsDoTraitement.IdAccouchement = Convert.ToInt32(txtIdAccouchement.Text);
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", accouchement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", accouchement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", accouchement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", accouchement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            accouchement = new clsaccouchement();
            bln = false;
            bindingcls();
            txtEtatPaiement.Text = "Non payé";
            if (cbotype.Items.Count > 0) cbotype.SelectedIndex = 0;
            txtIdFemmeEnceintePers.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
            txtIdAccouchement.Text = clsDoTraitement.IdAccouchement.ToString();
        }

        private void refresh()
        {
            try
            {
                if (!clsDoTraitement.doubleclicAccouchementDg)
                {
                    bindingcls();
                    //txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();

                    bsrc.DataSource = clsMetier.GetInstance().getAllClsaccouchement();

                    cbotype.DataSource = clsMetier.GetInstance().getAllClstypeaccouchement();
                    setMembersallcbo(cbotype, "Designation", "Id");

                    cboMalade.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMalade, "Nom_complet", "IdFemmeEnceinte");

                    if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
                    if (cbotype.Items.Count > 0) cbotype.SelectedIndex = 0;
                }
                else
                {
                    txtIdAccouchement.Text = clsDoTraitement.idAccouchementDg.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsaccouchement4(clsDoTraitement.idAccouchementDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;

                    cbotype.DataSource = clsMetier.GetInstance().getAllClstypeaccouchement();
                    setMembersallcbo(cbotype, "Designation", "Id");

                    cboMalade.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse2(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMalade, "Nom_complet", "IdFemmeEnceinte");

                    if (bsrc.Count != 0)
                    {
                        //On met les valeurs correspondantes a ceux de l'accouchement selectionee
                        cbotype.Text = clsMetier.GetInstance().getAllClstypeaccouchement1(Convert.ToInt32(((clsaccouchement)bsrc.Current).Id_typeaccouchement)).Designation;
                        txtLieu.Text = ((clsaccouchement)bsrc.Current).Lieu;
                        txtDate.Text = ((clsaccouchement)bsrc.Current).Date.ToString();
                        txtBCG.Text = ((clsaccouchement)bsrc.Current).Bcg.ToString(); 
                        txtVat.Text = ((clsaccouchement)bsrc.Current).Vat.ToString(); 
                        txtDegree.Text = ((clsaccouchement)bsrc.Current).Degree.ToString();
                        txtTraitement.Text = ((clsaccouchement)bsrc.Current).Traitement; 
                    }
                }

                clsDoTraitement.doubleclicEnfantFemmeDg = false;
                clsDoTraitement.idEnfantFemmeDg = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Actualisation du DataGrid du bas suivant l'accouchement choisi
            try
            {
                dgvEnfant.DataSource = clsMetier.GetInstance().getAllClsenfant2(clsDoTraitement.IdFemmeEnceinte);
                lblEnfant.Enabled = true;
            }
            catch (Exception) { MessageBox.Show("Erreur d'affichage des informations complémentaires de la femme", "Erreur d'affichage"); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    accouchement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        if (bsrc.DataSource != null)
                        {
                            clsaccouchement s = (clsaccouchement)bsrc.Current;
                            new clsaccouchement().update(s);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                //Permet l'actualisation des valeur des Accouchements sur le formulaire appelant
                clsDoTraitement.EnterFormAcouchement = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refresh();
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
                        clsaccouchement d = (clsaccouchement)bsrc.Current;
                        new clsaccouchement().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
                //Permet l'actualisation des valeur des Accouchements sur le formulaire appelant
                clsDoTraitement.EnterFormAcouchement = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmAccouchement_Load(object sender, EventArgs e)
        {
            lblMalade.Enabled = false;
            txtIdFemmeEnceintePers.Visible = false;
            txtIdAccouchement.Visible = false;

            try
            {
                bindingcls();
                txtIdFemmeEnceintePers.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                txtIdAccouchement.Text = clsDoTraitement.IdAccouchement.ToString();
                dgvAccouchement.DataSource = bsrc;
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void lblMalade_Click(object sender, EventArgs e)
        {
            EnfantFrm frm = new EnfantFrm();
            frm.ShowDialog();
        }

        private void lblEnfant_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicEnfantFemmeDg = false;
            clsDoTraitement.idEnfantFemmeDg = 0;

            EnfantFrm frm = new EnfantFrm();
            frm.ShowDialog();
        }

        private void dgvAccouchement_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccouchement.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                    clsDoTraitement.IdAccouchement = Convert.ToInt32(txtIdAccouchement.Text);
                    //Chargement du DataGrid du bas suivant l'accouchement choisi
                    dgvEnfant.DataSource = clsMetier.GetInstance().getAllClsenfant2(clsDoTraitement.IdAccouchement);

                    lblEnfant.Enabled = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void dgvAccouchement_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccouchement.RowCount > 0)
                {
                    clsDoTraitement.IdAccouchement = Convert.ToInt32(txtIdAccouchement.Text);
                    clsDoTraitement.IdFemmeEnceinte = Convert.ToInt32(txtIdFemmeEnceintePers.Text);
                }
            }
            catch (Exception) { }
        }

        private void dgvEnfant_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicEnfantFemmeDg = true;
                clsDoTraitement.idEnfantFemmeDg = ((clsenfant)dgvEnfant.SelectedRows[0].DataBoundItem).Id;
                EnfantFrm frm = new EnfantFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void FrmAccouchement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvAccouchement };
                ComboBox[] cbo = { cboMalade };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }
    }
}
