using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DelivranceFrm : Form
    {
        public DelivranceFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsdelivrance  delivrance = new clsdelivrance();
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
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", delivrance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", delivrance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", delivrance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", delivrance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", delivrance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtOcytocine, chkTraction, chkMassage, txtDate, txtDateDelivranceArtificiel, cboPlacenta, 
                                       txtAspectDuPlanceta, cboMembrane, txtHemoragie,txtIdFemmeEnceinte };
            clearforbinding(tbcontrols);

            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
            setbindingcls(txtOcytocine, "Ocyticine10uim", 0);
            setbindingcls(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
            setbindingcls(chkTraction, "Tractioncontroleducordon", 0);
            setbindingcls(chkMassage, "Massageuterinapredelivrance", 0);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtDateDelivranceArtificiel, "Delivranceartificiel", 0);
            setbindingcls(cboPlacenta, "Plancenta", 0);
            setbindingcls(txtAspectDuPlanceta, "Aspect", 0);
            setbindingcls(cboMembrane, "Membranes", 0);
            setbindingcls(txtHemoragie, "Hemoragie", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtOcytocine, chkTraction, chkMassage, txtDate, txtDateDelivranceArtificiel, cboPlacenta, 
                                       txtAspectDuPlanceta, cboMembrane, txtHemoragie,txtIdFemmeEnceinte };
            clearforbinding(tbcontrols);

            setbindinglst(txtOcytocine, "Ocyticine10uim", 0);
            setbindinglst(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
            setbindinglst(chkTraction, "Tractioncontroleducordon", 0);
            setbindinglst(chkMassage, "Massageuterinapredelivrance", 0);
            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtDateDelivranceArtificiel, "Delivranceartificiel", 0);
            setbindinglst(cboPlacenta, "Plancenta", 0);
            setbindinglst(txtAspectDuPlanceta, "Aspect", 0);
            setbindinglst(cboMembrane, "Membranes", 0);
            setbindinglst(txtHemoragie, "Hemoragie", 0);
        }

        private void New()
        {
            delivrance = new clsdelivrance();
            bln = false;
            bindingcls();
            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
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
                if (!clsDoTraitement.doubleclicDelivranceDg)
                {
                    bindingcls();
                    txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsdelivrance();

                    cboMaladeGrosse.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMaladeGrosse, "Nom_complet", "IdFemmeEnceinte");

                    if (cboMaladeGrosse.Items.Count > 0) cboMaladeGrosse.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsdelivrance2(clsDoTraitement.idDelivranceDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboMaladeGrosse.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMaladeGrosse, "Nom_complet", "IdFemmeEnceinte");

                    //On met les valeur correspondant a ceux de la delivrance selectionee
                    if (bsrc.Count != 0)
                    {
                        //On met les valeurs correspondantes a ceux de l'accouchement selectionee
                        txtOcytocine.Text = ((clsdelivrance)bsrc.Current).Ocyticine10uim;
                        chkTraction.Checked = (bool)((clsdelivrance)bsrc.Current).Tractioncontroleducordon;
                        chkMassage.Checked = (bool)((clsdelivrance)bsrc.Current).Massageuterinapredelivrance;
                        txtDate.Text = ((clsdelivrance)bsrc.Current).Date.ToString();
                        txtDateDelivranceArtificiel.Text = ((clsdelivrance)bsrc.Current).Delivranceartificiel.ToString();
                        cboPlacenta.Text = ((clsdelivrance)bsrc.Current).Plancenta;
                        txtAspectDuPlanceta.Text = ((clsdelivrance)bsrc.Current).Aspect;
                        cboMembrane.Text = ((clsdelivrance)bsrc.Current).Membranes;
                        txtHemoragie.Text = ((clsdelivrance)bsrc.Current).Hemoragie;
                    }                    
                }
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
                    delivrance.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsdelivrance s = (clsdelivrance)bsrc.Current;
                        new clsdelivrance().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.EnterFormDelivrance = true;
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
                        clsdelivrance d = (clsdelivrance)bsrc.Current;
                        new clsdelivrance().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormDelivrance = true;
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

        private void ChargementCombo()
        {
            cboPlacenta.Items.Add("Complet");
            cboPlacenta.Items.Add("Incomplet");

            cboMembrane.Items.Add("Complet");
            cboMembrane.Items.Add("Incomplet");

            cboMembrane.SelectedIndex = 0;
            cboPlacenta.SelectedIndex = 0;
        }

        private void FrmDelivrance_Load(object sender, EventArgs e)
        {
            lblMalade.Enabled = false;
            txtIdFemmeEnceinte.Visible = false;

            try
            {
                bindingcls();
                ChargementCombo();
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }

        private void cboMaladeGrosse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdFemmeEnceinte = ((clsmaladegrosse)cboMaladeGrosse.SelectedItem).IdFemmeEnceinte;
            }
            catch (Exception) { }
        }
    }
}
