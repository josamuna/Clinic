using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class RendezVousFrm : Form
    {
        public RendezVousFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsrendezvous rendezvous = new clsrendezvous();
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", rendezvous, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", rendezvous, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtObservation, txtDate,txtIdEnfant };
            clearforbinding(tbcontrols);
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();

            setbindingcls(txtObservation, "Observation", 0);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtIdEnfant, "Id_maladeenconsultationpostnatal", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtObservation, txtDate, txtIdEnfant };
            clearforbinding(tbcontrols);

            setbindinglst(txtObservation, "Observation", 0);
            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtIdEnfant, "Id_maladeenconsultationpostnatal", 0);
        }

        private void New()
        {
            rendezvous = new clsrendezvous();
            bln = false;
            bindingcls();
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
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
            //MessageBox.Show(rendezvous.Id_maladeenconsultationpostnatal.ToString());
            try
            {
                if (!bln)
                {
                    rendezvous.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsrendezvous s = (clsrendezvous)bsrc.Current;
                        new clsrendezvous().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des rendez vous sur le formulair appelant
                clsDoTraitement.EnterForFormRendezVous = true;
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
                        clsrendezvous d = (clsrendezvous)bsrc.Current;
                        new clsrendezvous().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                    }

                    //Permet l'actualisation des valeur des rendez vous sur le formulair appelant
                    clsDoTraitement.EnterForFormRendezVous = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmRendezVous_Load(object sender, EventArgs e)
        {
            txtIdEnfant.Visible = false;
            try
            {
                if (!clsDoTraitement.doubleclicRendezvousDg)
                {
                    bindingcls();
                    txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsrendezvous();
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsrendezvous2(clsDoTraitement.idRendezvousDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;

                    //On met les valeur correspondant a ceux du rendez vous selectionee
                    if (bsrc.Count != 0)
                    {
                        txtDate.Text = ((clsrendezvous)bsrc.Current).Date.ToString();
                        txtObservation.Text = ((clsrendezvous)bsrc.Current).Observation; 
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
    }
}
