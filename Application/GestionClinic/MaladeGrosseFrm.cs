using System;
using System.Data;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class MaladeGrosseFrm : Form
    {
        public MaladeGrosseFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsmaladegrosse malade = new clsmaladegrosse();
        clsmalade personne = new clsmalade();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void refresh()
        {
            try
            {
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmalade();
                setMembersallcbo(cboMalade, "Nom_complet", "Id");

                bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse1();

                clsDoTraitement.doubleclicAccouchementDg = false;
                clsDoTraitement.doubleclicAvortementDg = false;
                clsDoTraitement.doubleclicDelivranceDg = false;

                clsDoTraitement.idAccouchementDg = 0;
                clsDoTraitement.idAvortementDg = 0;
                clsDoTraitement.idDelivranceDg = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Actualisation des DataGrid du bas suivant la femme enceinte choisi
            try
            {
                dgvAccouchement.DataSource = clsMetier.GetInstance().getAllClsaccouchement2(clsDoTraitement.IdFemmeEnceinte);
                dgvAvortement.DataSource = clsMetier.GetInstance().getAllClsavortement3(clsDoTraitement.IdFemmeEnceinte);
                dgvDelivrance.DataSource = clsMetier.GetInstance().getAllClsdelivrance3(clsDoTraitement.IdFemmeEnceinte);
                dgvCPN.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal3(clsDoTraitement.IdFemmeEnceinte);
            }
            catch (Exception) { MessageBox.Show("Erreur d'affichage des informations complémentaires du aptitude", "Erreur d'affichage"); }
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtConjoin, txtNumerRegistre, cboMalade };
            clearforbinding(tbcontrols);

            //Malade
            setbindingcls(cboMalade, "Id_malade", 1);
            setbindingcls(txtNumerRegistre, "Numeroregistre", 0);
            setbindingcls(txtConjoin, "Conjoin", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtConjoin, cboMalade, txtNumerRegistre, txtIdPersonneFemme };
            clearforbinding(tbcontrols);

            setbindinglst(cboMalade, "Id_malade", 1);
            setbindinglst(txtNumerRegistre, "Numeroregistre", 0);
            setbindinglst(txtConjoin, "Conjoin", 0);
            //Recuperation de l'Id de la femme enceinte
            setbindinglst(txtIdPersonneFemme, "idMalGros", 0);
            clsDoTraitement.IdFemmeEnceinte = Convert.ToInt32(txtIdPersonneFemme.Text);
        }

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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            malade = new clsmaladegrosse();
            bln = false;
            bindingcls();
            if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    malade.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsmaladegrosse s = new clsmaladegrosse();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("numero")) s.Numero = ((string)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.IdFemmeEnceinte = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_malade")) s.Id_malade = ((int)obj[i]);

                            else if (dtc.ToString().Equals("conjoin")) s.Conjoin = (((string)obj[i]) == DBNull.Value.ToString()) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("numeroregistre")) s.Numeroregistre = ((string)obj[i]);
                            i++;
                        }
                        new clsmaladegrosse().update(s);
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
                        clsmaladegrosse s = new clsmaladegrosse();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("numero")) s.Numero = ((string)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.IdFemmeEnceinte = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_malade")) s.Id_malade = ((int)obj[i]);

                            else if (dtc.ToString().Equals("conjoin")) s.Conjoin = (((string)obj[i]) == DBNull.Value.ToString()) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("numeroregistre")) s.Numeroregistre = ((string)obj[i]);
                            i++;
                        }
                        new clsmaladegrosse().delete(s);
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

        private void FrmMaladeGrosse_Load(object sender, EventArgs e)
        {
            lblAccouchement.Enabled = false;
            lblAvortement.Enabled = false;
            lblDelivrance.Enabled = false;
            lblCPN.Enabled = false;
            txtIdPersonneFemme.Visible = false;
            txtIdPers.Visible = false;

            try
            {
                bindingcls();
                txtIdPersonneFemme.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                dgvFemmeEnceinte.DataSource = bsrc;
                refresh();
                if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
                txtNumero.Enabled = false;
                txtNumerRegistre.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAccouchement_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicAccouchementDg = false;
            clsDoTraitement.idAccouchementDg = 0;

            AccouchementFrm frm = new AccouchementFrm();
            frm.ShowDialog();
        }

        private void lblAvortement_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicAvortementDg = false;
            clsDoTraitement.idAvortementDg = 0;

            AvortementFrm frm = new AvortementFrm();
            frm.ShowDialog();
        }

        private void lblDelivrance_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicDelivranceDg = false;
            clsDoTraitement.idDelivranceDg = 0;

            DelivranceFrm frm = new DelivranceFrm();
            frm.ShowDialog();
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Numero LIKE '%" + txtSeach.Text + "%' OR Numeroregistre LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void dgvAccouchement_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicAccouchementDg = true;
                clsDoTraitement.idAccouchementDg = ((clsaccouchement)dgvAccouchement.SelectedRows[0].DataBoundItem).Id;
                AccouchementFrm frm = new AccouchementFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void dgvAvortement_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicAvortementDg = true;
                clsDoTraitement.idAvortementDg = ((clsavortement)dgvAvortement.SelectedRows[0].DataBoundItem).Id;
                AvortementFrm frm = new AvortementFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void dgvDelivrance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicDelivranceDg = true;
                clsDoTraitement.idDelivranceDg = ((clsdelivrance)dgvDelivrance.SelectedRows[0].DataBoundItem).Id;
                DelivranceFrm frm = new DelivranceFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void dgvFemmeEnceinte_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFemmeEnceinte.RowCount > 0) clsDoTraitement.IdFemmeEnceinte = Convert.ToInt32(txtIdPersonneFemme.Text);
            }
            catch (Exception) { }
        }

        private void lblCPN_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicConsultationFicheDg = false;
            clsDoTraitement.idCPNDg = 0;

            ConsultationPreNataleFrm frm = new ConsultationPreNataleFrm();
            frm.ShowDialog();
        }

        private void dgvCPN_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicCPNDg = true;
                clsDoTraitement.idCPNDg = ((clsconsultationprenatal)dgvCPN.SelectedRows[0].DataBoundItem).Id;
                ConsultationPreNataleFrm frm = new ConsultationPreNataleFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void dgvFemmeEnceinte_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvFemmeEnceinte.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                    //Chargement des DataGrid du bas suivant la femme enceinte choisie 
                    dgvAccouchement.DataSource = clsMetier.GetInstance().getAllClsaccouchement2(clsDoTraitement.IdFemmeEnceinte);
                    dgvAvortement.DataSource = clsMetier.GetInstance().getAllClsavortement3(clsDoTraitement.IdFemmeEnceinte);
                    dgvDelivrance.DataSource = clsMetier.GetInstance().getAllClsdelivrance3(clsDoTraitement.IdFemmeEnceinte);
                    dgvCPN.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal3(clsDoTraitement.IdFemmeEnceinte);

                    lblAccouchement.Enabled = true;
                    lblAvortement.Enabled = true;
                    lblDelivrance.Enabled = true;
                    lblCPN.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                personne = clsMetier.GetInstance().getClsmalade(((clsmalade)cboMalade.SelectedItem).Id);

                txtIdPers.Text = personne.IdPers.ToString();
                txtNumero.Text = personne.Numero;
                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtCategorie.Text = clsMetier.GetInstance().getClscategoriemalade(Convert.ToInt32(personne.Id_categoriemalade)).Designation;
                txtProfession.Text = clsMetier.GetInstance().getClsprofession(Convert.ToInt32(personne.Id_profession)).Designation;
                txtEtablissement.Text = clsMetier.GetInstance().getClsetablissementpriseencharge(Convert.ToInt32(personne.Id_etablissement)).Denomination;
                txtAireSante.Text = clsMetier.GetInstance().getClsairsante(Convert.ToInt32(personne.Id_airsante)).Designation;
                pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
            }
            catch (Exception) { }//{ MessageBox.Show("Erreur lors de la sélection de la personne", "Erreur de sélection"); }
        }
    }
}
