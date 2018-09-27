using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ExamenFrm : Form
    {
        public ExamenFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsexamen examen = new clsexamen();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDesignation, cboTypeExamen, txtPrix };
            clearforbinding(tbcontrols);

            setbindingcls(txtDesignation, "Designation", 0);
            setbindingcls(cboTypeExamen, "Id_typeexamen", 1);
            setbindingcls(txtPrix, "Prix", 0);

        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDesignation, cboTypeExamen,txtPrix };
            clearforbinding(tbcontrols);

            setbindinglst(txtDesignation, "Designation", 0);
            setbindinglst(cboTypeExamen, "Id_typeexamen", 1);
            setbindinglst(txtPrix, "Prix", 0);
        }

        private void New()
        {
            examen = new clsexamen();
            bln = false;
            bindingcls();
            if (cboTypeExamen.Items.Count > 0) cboTypeExamen.SelectedIndex = 0;
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsexamen();

                cboTypeExamen.DataSource = clsMetier.GetInstance().getAllClstypeexamen();
                setMembersallcbo(cboTypeExamen, "Designation", "Id");

                if (cboTypeExamen.Items.Count > 0) cboTypeExamen.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    examen.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsexamen s = (clsexamen)bsrc.Current;
                        new clsexamen().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if (bsrc.DataSource != null)
                    //{
                    //    clsexamen s = new clsexamen();
                    //    Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                    //    int i = 0;
                    //    foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                    //    {
                    //        if (dtc.ToString().Equals("designation")) s.Designation = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("prix")) s.Prix = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("id")) s.Id = ((int)obj[i]);
                    //        else if (dtc.ToString().Equals("id_typeexamen")) s.Id_typeexamen = ((int)obj[i]);
                    //        i++;
                    //    }
                    //    new clsexamen().update(s);
                    //    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                //Permet l'actualisation des valeur des examen sur le formulaire appelant
                clsDoTraitement.EnterForFormExamen = true;
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
                        clsexamen d = (clsexamen)bsrc.Current;
                        new clsexamen().delete(d);
                        //Permet l'actualisation des valeur des examen sur le formulaire appelant
                        clsDoTraitement.EnterForFormExamen = true;
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

        private void cboTypeExamen_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormTypeExamen)
            {
                try
                {
                    cboTypeExamen.DataSource = clsMetier.GetInstance().getAllClstypeexamen();
                }
                catch (Exception) { }
            }
        }

        private void lblAddTypeExamen_Click(object sender, EventArgs e)
        {
            TypeExamenFrm fr = new TypeExamenFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void FrmExamen_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void FrmExamen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                ComboBox[] cbo = { cboTypeExamen };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }
    }
}
