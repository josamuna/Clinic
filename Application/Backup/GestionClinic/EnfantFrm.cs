using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class EnfantFrm : Form
    {
        public EnfantFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsenfant enfant = new clsenfant();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", enfant, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", enfant, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", enfant, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", enfant, strValue, true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtPoids, cboSoinDuCordo, cboSenn, chkMiseAuSein, txtTaille, cboSexe, txtMalformation,txtPC,txtIdFemmeEnceinte };
            clearforbinding(tbcontrols);

            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
            setbindingcls(txtPoids, "Poid", 0);
            setbindingcls(cboSoinDuCordo, "Soinsducordo", 0);
            setbindingcls(cboSenn, "Senn", 0);
            setbindingcls(chkMiseAuSein, "Miseausiendansheurquisuitaccouchement", 0);
            setbindingcls(txtTaille, "Taille", 0);
            setbindingcls(cboSexe, "Sexe", 0);
            setbindingcls(txtMalformation, "Malformation", 0);
            setbindingcls(txtPC, "Pc", 0);
            setbindingcls(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
        }

        private void bindinglst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtPoids, cboSoinDuCordo, cboSenn, chkMiseAuSein, txtTaille, cboSexe, txtMalformation, txtPC, txtIdFemmeEnceinte };
            clearforbinding(tbcontrols);

            setbindinglst(txtPoids, "Poid", 0);
            setbindinglst(cboSoinDuCordo, "Soinsducordo", 0);
            setbindinglst(cboSenn, "Senn", 0);
            setbindinglst(chkMiseAuSein, "Miseausiendansheurquisuitaccouchement", 0);
            setbindinglst(txtTaille, "Taille", 0);
            setbindinglst(cboSexe, "Sexe", 0);
            setbindinglst(txtMalformation, "Malformation", 0);
            setbindinglst(txtPC, "Pc", 0);
            setbindinglst(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
        }

        private void New()
        {
            enfant = new clsenfant();
            bln = false;
            bindingcls();
            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
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
                    enfant.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsenfant s = (clsenfant)bsrc.Current;
                        new clsenfant().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        clsenfant d = (clsenfant)bsrc.Current;
                        new clsenfant().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refresh()
        {
            try
            {
                if (!clsDoTraitement.doubleclicEnfantFemmeDg)
                {
                    bindingcls();
                    txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsavortement();
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsenfant2(clsDoTraitement.IdFemmeEnceinte);
                    bln = true;
                    bindinglst();
                    btnAdd.Enabled = false;

                    //On met les valeurs correspondant a ceux de l'enfant selectione
                    txtPoids.Text = ((clsenfant)bsrc.Current).Poid.ToString();
                    cboSoinDuCordo.Text = ((clsenfant)bsrc.Current).Soinsducordo;
                    cboSenn.Text = ((clsenfant)bsrc.Current).Senn;
                    chkMiseAuSein.Text = ((clsenfant)bsrc.Current).Miseausiendansheurquisuitaccouchement.ToString();
                    txtTaille.Text = ((clsenfant)bsrc.Current).Taille.ToString();
                    cboSexe.Text = ((clsenfant)bsrc.Current).Sexe;
                    txtMalformation.Text = ((clsenfant)bsrc.Current).Malformation;
                    txtPC.Text = ((clsenfant)bsrc.Current).Pc.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmEnfant_Load(object sender, EventArgs e)
        {
            //txtIdFemmeEnceinte.Visible = false;
            try
            {
                cboSexe.Items.Add("M");
                cboSexe.Items.Add("F");
                cboSexe.SelectedIndex = 0;

                cboSoinDuCordo.Items.Add("Lame strérile");
                cboSoinDuCordo.Items.Add("Fil sterile");
                cboSoinDuCordo.Items.Add("Air libre");
                cboSoinDuCordo.SelectedIndex = 0;

                cboSenn.Items.Add("Maintien temperature");
                cboSenn.Items.Add("Températue auxilliaire");
                cboSenn.SelectedIndex = 0;
                bindingcls();
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
