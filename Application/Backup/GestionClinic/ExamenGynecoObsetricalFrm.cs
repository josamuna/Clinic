using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ExamenGynecoObsetricalFrm : Form
    {
        public ExamenGynecoObsetricalFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsexamengynecoobsetrical examenGyneco = new clsexamengynecoobsetrical();
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", examenGyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", examenGyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", examenGyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", examenGyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtHU, txtPresentation, txtBCF, txtContractionUterin, txtMFA, cboExamenAuSpeculum, cboAspectCol,
                                       txtTVColEfface, txtTVColDilate, cboPocheDeEaux, txtHeureRupture,cboAspectLiquide,cboDegreEngagemnt,
                                       cboApreciationBassin,txtIdConsultationPrenatale };
            clearforbinding(tbcontrols);

            txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
            setbindingcls(txtHU, "Hu", 0);
            setbindingcls(txtPresentation, "Presentation", 0);
            setbindingcls(txtBCF, "Bcf", 0);
            setbindingcls(txtContractionUterin, "Contractionuterine", 0);
            setbindingcls(txtMFA, "Mfa", 0);
            setbindingcls(cboExamenAuSpeculum, "Exauspeculum", 0);
            setbindingcls(cboAspectCol, "Colaspect", 0);
            setbindingcls(txtTVColEfface, "Tvcolefface", 0);
            setbindingcls(txtTVColDilate, "Tvcoldilate", 0);
            setbindingcls(cboPocheDeEaux, "Pochedeeaux", 0);
            setbindingcls(txtHeureRupture, "Dateheureruptrurecole", 0);
            setbindingcls(cboAspectLiquide, "Aspectduliquide", 0);
            setbindingcls(cboDegreEngagemnt, "Degreengagement", 0);
            setbindingcls(cboApreciationBassin, "Appreciationdubassin", 0);
            setbindingcls(txtIdConsultationPrenatale, "Id_consultationprenatal", 0);
        }

        private void bindinglst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtHU, txtPresentation, txtBCF, txtContractionUterin, txtMFA, cboExamenAuSpeculum, cboAspectCol,
                                       txtTVColEfface, txtTVColDilate, cboPocheDeEaux, txtHeureRupture,cboAspectLiquide,cboDegreEngagemnt,
                                       cboApreciationBassin,txtIdConsultationPrenatale };
            clearforbinding(tbcontrols);

            setbindinglst(txtHU, "Hu", 0);
            setbindinglst(txtPresentation, "Presentation", 0);
            setbindinglst(txtBCF, "Bcf", 0);
            setbindinglst(txtContractionUterin, "Contractionuterine", 0);
            setbindinglst(txtMFA, "Mfa", 0);
            setbindinglst(cboExamenAuSpeculum, "Exauspeculum", 0);
            setbindinglst(cboAspectCol, "Colaspect", 0);
            setbindinglst(txtTVColEfface, "Tvcolefface", 0);
            setbindinglst(txtTVColDilate, "Tvcoldilate", 0);
            setbindinglst(cboPocheDeEaux, "Pochedeeaux", 0);
            setbindinglst(txtHeureRupture, "Dateheureruptrurecole", 0);
            setbindinglst(cboAspectLiquide, "Aspectduliquide", 0);
            setbindinglst(cboDegreEngagemnt, "Degreengagement", 0);
            setbindinglst(cboApreciationBassin, "Appreciationdubassin", 0);
            setbindinglst(txtIdConsultationPrenatale, "Id_consultationprenatal", 0);
        }

        private void New()
        {
            examenGyneco = new clsexamengynecoobsetrical();
            bln = false;
            bindingcls();
            txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
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
                        clsexamengynecoobsetrical d = (clsexamengynecoobsetrical)bsrc.Current;
                        new clsexamengynecoobsetrical().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cboExamenAuSpeculum.Items.Add("Si pertes des eaux");
            cboExamenAuSpeculum.Items.Add("Hémoragie génitale");
            cboExamenAuSpeculum.Items.Add("Pertes purulente");

            cboAspectCol.Items.Add("Ancien soin");
            cboAspectCol.Items.Add("Cerclage du col");
            cboAspectCol.Items.Add("Déchirure");
            cboAspectCol.Items.Add("Inflammé");
            cboAspectCol.Items.Add("Col cicatrisé");

            cboPocheDeEaux.Items.Add("Rompue");
            cboPocheDeEaux.Items.Add("Non rompue");

            cboAspectLiquide.Items.Add("Claire");
            cboAspectLiquide.Items.Add("Verdâtre");
            cboAspectLiquide.Items.Add("Sanguinolent");
            cboAspectLiquide.Items.Add("Jaunâtre");
            cboAspectLiquide.Items.Add("Purulent");
            
            cboDegreEngagemnt.Items.Add("haut");
            cboDegreEngagemnt.Items.Add("Amorcé");
            cboDegreEngagemnt.Items.Add("Fixé");
            cboDegreEngagemnt.Items.Add("Engagé");
            
            cboApreciationBassin.Items.Add("bon");
            cboApreciationBassin.Items.Add("Limité");
            cboApreciationBassin.Items.Add("Rétréci");
            cboApreciationBassin.Items.Add("Asymétrique");

            cboExamenAuSpeculum.SelectedIndex = 0;
            cboAspectCol.SelectedIndex = 0;
            cboPocheDeEaux.SelectedIndex = 0;
            cboAspectLiquide.SelectedIndex = 0;
            cboDegreEngagemnt.SelectedIndex = 0;
            cboApreciationBassin.SelectedIndex = 0;
        }

        private void FrmExamenGynecoObsetrical_Load(object sender, EventArgs e)
        {
            txtIdConsultationPrenatale.Visible = false;
            try
            {
                ChargementCombo();
                if (!clsDoTraitement.doubleclicExamenGynecoObstetriqueDg)
                {
                    bindingcls();
                    txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsexamen();
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsexamengynecoobsetrical2(clsDoTraitement.idExamenGynecoObstetriqueDg);
                    bln = true;
                    bindinglst();
                    btnAdd.Enabled = false;

                    //On met les valeur correspondant a ceux de Examen Gyneco Obstetric selectionee
                    if (bsrc.Count != 0)
                    {
                        txtHU.Text = ((clsexamengynecoobsetrical)bsrc.Current).Hu.ToString();
                        txtPresentation.Text = ((clsexamengynecoobsetrical)bsrc.Current).Presentation.ToString();
                        txtBCF.Text = ((clsexamengynecoobsetrical)bsrc.Current).Bcf.ToString();
                        txtContractionUterin.Text = ((clsexamengynecoobsetrical)bsrc.Current).Contractionuterine;
                        txtMFA.Text = ((clsexamengynecoobsetrical)bsrc.Current).Mfa;
                        cboExamenAuSpeculum.Text = ((clsexamengynecoobsetrical)bsrc.Current).Exauspeculum;
                        cboAspectCol.Text = ((clsexamengynecoobsetrical)bsrc.Current).Colaspect;
                        txtTVColEfface.Text = ((clsexamengynecoobsetrical)bsrc.Current).Tvcolefface.ToString();
                        txtTVColDilate.Text = ((clsexamengynecoobsetrical)bsrc.Current).Tvcoldilate.ToString();
                        cboPocheDeEaux.Text = ((clsexamengynecoobsetrical)bsrc.Current).Pochedeeaux;
                        txtHeureRupture.Text = ((clsexamengynecoobsetrical)bsrc.Current).Dateheureruptrurecole.ToString();
                        cboAspectLiquide.Text = ((clsexamengynecoobsetrical)bsrc.Current).Aspectduliquide;
                        cboDegreEngagemnt.Text = ((clsexamengynecoobsetrical)bsrc.Current).Degreengagement;
                        cboApreciationBassin.Text = ((clsexamengynecoobsetrical)bsrc.Current).Appreciationdubassin;
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    examenGyneco.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsexamengynecoobsetrical s = (clsexamengynecoobsetrical)bsrc.Current;
                        new clsexamengynecoobsetrical().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
