using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class LaboPaiementFrmDossier : Form
    {
        public LaboPaiementFrmDossier()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsoperation_laboratoire operation = new clsoperation_laboratoire();
        bool bln = false;
        BindingSource bsrc = new BindingSource();

        private void clearforbindingOperation(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingclsOperation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsOperation()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, cboExamen, txtIdMalade, txtetatPaiement };
            clearforbindingOperation(tbcontrols);

            setbindingclsOperation(txtDateOuvertureDossier, "Date", 0);
            setbindingclsOperation(cboExamen, "Id_examen", 1);
            setbindingclsOperation(txtIdMalade, "Id_malade", 0);
            setbindingclsOperation(txtetatPaiement, "Etatpaiement", 0);
        }

        private void New()
        {
            operation = new clsoperation_laboratoire();
            bln = false;
            bindingclsOperation();
            txtIdMalade.Text = clsDoTraitement.idMaladeDossierPre.ToString();
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void refreshOperation()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsoperation_laboratoire2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
                cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();
                setMembersallcbo(cboExamen, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstOperation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstOperation()
        {

            Control[] tbcontrols = { txtDateOuvertureDossier, cboExamen, txtIdMalade, txtetatPaiement };
            clearforbindingOperation(tbcontrols);

            setbindinglstOperation(txtDateOuvertureDossier, "Date", 0);
            setbindinglstOperation(cboExamen, "Id_examen", 1);
            setbindinglstOperation(txtIdMalade, "Id_malade", 0);
            setbindinglstOperation(txtetatPaiement, "Etatpaiement", 0);
        }

        private void btnRefreshDossier_Click(object sender, EventArgs e)
        {
            refreshOperation();
        }

        private void btnAddDossier_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                txtetatPaiement.Text = "Non cloturé non payé";
            }
            catch (Exception)
            {
                btnSaveDossier.Enabled = false;
            }
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    operation.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsoperation_laboratoire o = (clsoperation_laboratoire)bsrc.Current;
                        new clsoperation_laboratoire().update(o);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsoperation_laboratoire2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmDossierLaboPaiement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            try
            {
                lstDossierEncCours.DataSource = bsrc;
                refreshOperation();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste", "Erreur de Chargement");
            }
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.Items.Count > 0)
                {
                    bindiglstOperation();
                    bln = true;
                    btnDelete.Enabled = true;

                    try
                    {
                        txtPrix.Text = clsMetier.GetInstance().getClsexamen(((clsexamen)cboExamen.SelectedItem).Id).Prix.ToString();
                    }
                    catch (Exception) { txtPrix.Clear(); }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
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
                        clsoperation_laboratoire a = (clsoperation_laboratoire)bsrc.Current;
                        new clsoperation_laboratoire().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refreshOperation();
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtPrix.Text = clsMetier.GetInstance().getClsexamen(((clsexamen)cboExamen.SelectedItem).Id).Prix.ToString();
            }
            catch (Exception) { txtPrix.Clear(); }
        }

        private void cboExamen_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.MAJ_Labo)
            {
                try
                {
                    cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();
                    setMembersallcbo(cboExamen, "Designation", "Id");
                }
                catch (Exception) { }
            }
        }

        private void lblAddTarif_Click(object sender, EventArgs e)
        {
            TarifsFrm fr = new TarifsFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }
    }
}
