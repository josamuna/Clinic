using System;
using System.Data;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class SystemeFrm : Form
    {
        public SystemeFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clstypesysteme typeSysteme = new clstypesysteme();
        clsmouvementsysteme mvtSysteme = new clsmouvementsysteme();
        private BindingSource bsrc = new BindingSource();
        private BindingSource bsrc1 = new BindingSource();
        private bool okAddTypeSysteme = false;//Variable permettant de mettre à jour le combo de type systeme en cas
        //de modification, ajout ous suppression
        private bool bln = false;
        private bool bln1 = false;

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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", mvtSysteme, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", mvtSysteme, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", mvtSysteme, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtDesignation.DataBindings.Clear();
            txtDesignation.Focus();
            txtDesignation.DataBindings.Add("Text", typeSysteme, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtDesignation.DataBindings.Clear();
            txtDesignation.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls1()
        {
            btnDelete1.Enabled = false;
            Control[] tbcontrols = { txtCommentaire, cboTypeSystem, txtIdCPN };
            clearforbinding(tbcontrols);

            txtIdCPN.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
            setbindingcls(txtCommentaire, "Commentaire", 0);
            setbindingcls(cboTypeSystem, "Id_typesysteme", 1);
            setbindingcls(txtIdCPN, "Id_consultationprenatal", 0);
            //setbindingcls(txtIdTypeSysteme, "Id_typesysteme", 0);
        }

        private void bindignlst1()
        {
            btnDelete1.Enabled = true;
            Control[] tbcontrols = { txtCommentaire, cboTypeSystem, txtIdCPN };
            clearforbinding(tbcontrols);

            setbindinglst(txtCommentaire, "Commentaire", 0);
            setbindinglst(cboTypeSystem, "Id_typesysteme", 1);
            setbindinglst(txtIdCPN, "Id_consultationprenatal", 0);
            //setbindinglst(txtIdTypeSysteme, "Id_typesysteme", 0);
        }

        private void New()
        {
            typeSysteme = new clstypesysteme();
            bln = false;
            bindingcls();
        }

        private void New1()
        {
            mvtSysteme = new clsmouvementsysteme();
            bln1 = false;
            bindingcls1();
            if (cboTypeSystem.Items.Count > 0) cboTypeSystem.SelectedIndex = 0;
            txtIdCPN.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
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
                bsrc.DataSource = clsMetier.GetInstance().getAllClstypesysteme();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refresh1()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClsmouvementsysteme();
                cboTypeSystem.DataSource = clsMetier.GetInstance().getAllClstypesysteme();
                setMembersallcbo(cboTypeSystem, "Designation", "Id");
                cboConsultationPrenatale.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal2(Convert.ToInt32(txtIdCPN.Text));
                setMembersallcbo(cboConsultationPrenatale, "Designation", "Id");

                if (cboTypeSystem.Items.Count > 0) cboTypeSystem.SelectedIndex = 0;
                if (cboConsultationPrenatale.Items.Count > 0) cboConsultationPrenatale.SelectedIndex = 0;
                if (clsDoTraitement.IdConsultationPreNatal == -1) MessageBox.Show("Veuillez sélectionner une Consultation Pré Natale svp!!!", "Sélection d'une CPN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    typeSysteme.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clstypesysteme s = (clstypesysteme)bsrc.Current;
                        new clstypesysteme().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des Consultation PreNatale sur le formulair des Systeme
                clsDoTraitement.EnterFormConsultationPreNatale = true;
                //Permet l'actualisation des valeur des Types sur le formulair des Systeme
                //clsDoTraitement.EnterFormTypeSysteme = true;
                okAddTypeSysteme = true;
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
                        clstypesysteme d = (clstypesysteme)bsrc.Current;
                        new clstypesysteme().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                    //Permet l'actualisation des valeur des Consultation PreNatale sur le formulair des Systeme
                    clsDoTraitement.EnterFormConsultationPreNatale = true;
                    //Permet l'actualisation des valeur des Types sur le formulair des Systeme
                    //clsDoTraitement.EnterFormTypeSysteme = true;
                    okAddTypeSysteme = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvTypeSysteme_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTypeSysteme.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void lblAddCPN_Click(object sender, EventArgs e)
        {
            ConsultationPreNataleFrm frm = new ConsultationPreNataleFrm();
            frm.ShowDialog();
        }

        private void cboConsultationPrenatale_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormConsultationPreNatale)
            {
                try
                {
                    cboConsultationPrenatale.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal();
                }
                catch (Exception) { }
            }
        }

        private void FrmSysteme_Load(object sender, EventArgs e)
        {
            txtIdCPN.Visible = false;
            try
            {
                bindingcls();
                bindingcls1();
                txtIdCPN.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
                dgvTypeSysteme.DataSource = bsrc;
                dgvMvtSysteme.DataSource = bsrc1;
                refresh();
                refresh1();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboTypeSystem_MouseDown(object sender, MouseEventArgs e)
        {
            if (okAddTypeSysteme)
            {
                try
                {
                    cboTypeSystem.DataSource = clsMetier.GetInstance().getAllClstypesysteme();
                }
                catch (Exception) { }
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                New1();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln1)
                {
                    mvtSysteme.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc1.DataSource != null)
                    {
                        clsmouvementsysteme s = new clsmouvementsysteme();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("commentaire")) s.Commentaire = ((string)obj[i]);
                            else if (dtc.ToString().Equals("id_consultationPrenatal")) s.Id_consultationprenatal = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_typeSysteme")) s.Id_typesysteme = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.Id = ((int)obj[i]);
                            i++;
                        }
                        new clsmouvementsysteme().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New1();
            refresh1();
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            refresh1();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        clsmouvementsysteme s = new clsmouvementsysteme();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("commentaire")) s.Commentaire = ((string)obj[i]);
                            else if (dtc.ToString().Equals("id_consultationPrenatal")) s.Id_consultationprenatal = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_typeSysteme")) s.Id_typesysteme = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.Id = ((int)obj[i]);
                            i++;
                        }
                        new clsmouvementsysteme().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New1();
                        refresh1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboConsultationPrenatale_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdConsultationPreNatal = ((clsconsultationprenatal)cboConsultationPrenatale.SelectedItem).Id;
            }
            catch (Exception) { }
        }

        private void dgvMvtSysteme_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMvtSysteme.SelectedRows.Count > 0)
                {
                    bindignlst1();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }
    }
}
