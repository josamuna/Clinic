using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class IntervationFrm : Form
    {
        public IntervationFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsintervention intervention = new clsintervention();
        clsbloc bloc = new clsbloc();
        clsservice service = new clsservice();
        private BindingSource bsrc = new BindingSource();
        private BindingSource bsrcBloc = new BindingSource();
        private BindingSource bsrcService = new BindingSource();
        private bool blnBloc = false, bln=false, blnService=false;
   
        private void New()
        {
            intervention = new clsintervention();
            bln = false;
            bindingcls();
            if (cboBloc.Items.Count > 0) cboBloc.SelectedIndex = 0;
        }

        #region Binding
        private void setbindingclsIntervention(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindingclsService(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindingclsBloc(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstIntervetion(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstService(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstBloc(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void clearforbindingBloc(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDesignationIntervention, txtPrix, cboBloc };
            clearforbindingBloc(tbcontrols);

            setbindingclsIntervention(txtDesignationIntervention, "Designation", 0);
            setbindingclsIntervention(txtPrix, "Prix", 0);
            setbindingclsIntervention(cboBloc, "Id_bloc", 1);
        }

        public void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDesignationIntervention, txtPrix, cboBloc };
            clearforbinding(tbcontrols);

            setbindinglstIntervetion(txtDesignationIntervention, "Designation", 0);
            setbindinglstIntervetion(txtPrix, "Prix", 0);
            setbindinglstIntervetion(cboBloc, "Id_bloc", 1);
        }

        private void bindingclsBloc()
        {
            btnDeleteBloc.Enabled = false;
            Control[] tbcontrols = { txtDesignationBloc, cboService };
            clearforbinding(tbcontrols);

            setbindingclsBloc(txtDesignationBloc, "Designation", 0);
            setbindingclsBloc(cboService, "Id_service", 1);
        }

        public void bindignlstBloc()
        {
            btnDeleteBloc.Enabled = true;
            Control[] tbcontrols = { txtDesignationBloc, cboService };
            clearforbinding(tbcontrols);

            setbindinglstBloc(txtDesignationBloc, "Designation", 0);
            setbindinglstBloc(cboService, "Id_service", 1);
        }

        private void bindingclsService()
        {
            btnDeleteService.Enabled = false;
            Control[] tbcontrols = { txtDesignationService };
            clearforbinding(tbcontrols);
            setbindingclsService(txtDesignationService, "Designation", 0);
        }

        private void bindignlstService()
        {
            btnDeleteService.Enabled = true;
            Control[] tbcontrols = { txtDesignationService };
            clearforbinding(tbcontrols);

            setbindinglstService(txtDesignationService, "Designation", 0);
        }

        #endregion
     
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsintervention();
                cboBloc.DataSource = clsMetier.GetInstance().getAllClsbloc();
                setMembersallcbo(cboBloc, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    intervention.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsintervention i = (clsintervention)bsrc.Current;
                        new clsintervention().update(i);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Appel pour recuperer un cas de lis a jour pour le formulaire appelant
                clsDoTraitement.EnterFormIntervention = true;
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
                        clsintervention i = (clsintervention)bsrc.Current;
                        new clsintervention().delete(i);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
                //Appel pour recuperer un cas de lis a jour pour le formulaire appelant
                clsDoTraitement.EnterFormIntervention = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void setbindinglst(Control ctrl, string strValue,int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void dgvIntervention_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvIntervention.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void lblAddBloc_Click(object sender, EventArgs e)
        {
             bdnBloc.Enabled = true;
             tabControl1.SelectTab(tbBloc);
        }

        private void FrmIntervation_Load(object sender, EventArgs e)
        {
            try
            {
                bindingclsBloc();
                bindingcls();
                bindingclsService();
                dgvIntervention.DataSource = bsrc;
                dgvBloc.DataSource = bsrcBloc;
                dgvService.DataSource = bsrcService;
                refresh();
                refreshBloc();
                refreshService();
                if (cboBloc.Items.Count > 0) cboBloc.SelectedIndex = 0;
                if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bdnBloc.Enabled = false;
            bdnService.Enabled = false;
            if (clsDoTraitement.blnBloc)
            {
                bdnBloc.Enabled = true;
                tabControl1.SelectTab(tbBloc);
                clsDoTraitement.blnBloc = false;
            }
            if (clsDoTraitement.blnService)
            {
                bdnService.Enabled = true;
                tabControl1.SelectTab(tbService);
                clsDoTraitement.blnService = false;
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            bdnBloc.Enabled = true;
        }

        private void btnAddBloc_Click(object sender, EventArgs e)
        {
            newBloc();
        }

        private void newBloc()
        {
            bloc = new clsbloc();
            blnBloc = false;
            bindingclsBloc();
        }

        private void btnRefreshBloc_Click(object sender, EventArgs e)
        {
            refreshBloc();
        }

        private void refreshBloc()
        {
            try
            {
                bsrcBloc.DataSource = clsMetier.GetInstance().getAllClsbloc();
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSaveBloc_Click(object sender, EventArgs e)
        {
            try
            {
                if (!blnBloc)
                {
                    bloc.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrcBloc.DataSource != null)
                    {
                        clsbloc b = (clsbloc)bsrcBloc.Current;
                        new clsbloc().update(b);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refreshBloc();
        }

        private void btnDeleteBloc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrcBloc.DataSource != null)
                    {
                        clsbloc b = (clsbloc)bsrcBloc.Current;
                        new clsbloc().delete(b);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refreshBloc();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvBloc_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvBloc.SelectedRows.Count > 0)
                {
                    bindignlstBloc();
                    blnBloc = true;
                    bdnBloc.Enabled = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            bdnService.Enabled = true;
            tabControl1.SelectTab(tbService);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            newService();
        }

        private void newService()
        {
            service = new clsservice();
            blnService = false;
            bindingclsService();
        }

        private void btnRefreshService_Click(object sender, EventArgs e)
        {
            refreshService();
        }

        private void refreshService()
        {
            try
            {
                bsrcService.DataSource = clsMetier.GetInstance().getAllClsservice ();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                if (!blnService)
                {
                    service.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrcService.DataSource != null)
                    {
                        clsservice s = (clsservice)bsrcService.Current;
                        new clsservice().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refreshService();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrcBloc.DataSource != null)
                    {
                        clsservice s = (clsservice)bsrc.Current;
                        new clsservice().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refreshService();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvService_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvService.SelectedRows.Count > 0)
                {
                    bindignlstService();
                    blnService = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void cboService_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
            }
            catch (Exception) { }
        }

        private void cboBloc_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboBloc.DataSource = clsMetier.GetInstance().getAllClsbloc();
            }
            catch (Exception) { }
        }

        private void FrmIntervation_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc, bsrcBloc, bsrcService };
                DataGridView[] dg = { dgvBloc, dgvIntervention, dgvService };
                ComboBox[] cbo = { cboBloc, cboService };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }
    }
}
