using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ArticleFrm : Form
    {
        public ArticleFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsarticle  medicament = new clsarticle();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", medicament, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", medicament, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnAddFonction_Click(object sender, EventArgs e)
        {
            New();
        }

        private void New()
        {
            try
            {
                medicament = new clsarticle();
                bln = false;
                bindingcls();
                txtStock.Text = "0";
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDesignation, txtStkAlert, txtPU, txtCaracteristique, chkFicheSupplementaire };
            clearforbinding(tbcontrols);

            setbindingcls(txtDesignation, "Desination", 0);
            setbindingcls(txtPU, "Pu", 0);
            setbindingcls(txtCaracteristique, "Caracteristique", 0);
            setbindingcls(txtStkAlert, "Stock_alert", 0);
            setbindingcls(chkFicheSupplementaire, "Fiche_supplementaire", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDesignation, txtPU,txtStkAlert, txtCaracteristique, txtStock,chkFicheSupplementaire };
            clearforbinding(tbcontrols);

            setbindinglst(txtDesignation, "Desination", 0);
            setbindinglst(txtPU, "Pu", 0);
            setbindinglst(txtCaracteristique, "Caracteristique", 0);
            setbindinglst(txtStkAlert, "Stock_alert", 0);
            setbindinglst(txtStock, "Stock", 0);
            setbindinglst(chkFicheSupplementaire, "Fiche_supplementaire", 0);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsarticle();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    medicament.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsDoTraitement.EnterFormArticle = true;
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsarticle m = (clsarticle)bsrc.Current;
                        new clsarticle().update(m);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
                        clsarticle m = (clsarticle)bsrc.Current;
                        new clsarticle().delete(m);
                        clsDoTraitement.EnterFormArticle = true;
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

        private void dgvMedicament_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMedicament.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void FrmMedicament_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgvMedicament.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void FrmArticle_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvMedicament };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
