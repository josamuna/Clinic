using System;
using System.Windows.Forms;
using System.Drawing;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DossierHospitalisationPaiementFrm : Form
    {
        public DossierHospitalisationPaiementFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clshospitalisation hospitalisation = new clshospitalisation();
        BindingSource bsrc = new BindingSource();
        BindingSource bsrcRest = new BindingSource();
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
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", hospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", hospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", hospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", hospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDateDebut, txtDateFin, cboChambre, txtId_malade, txtPaiement };
            clearforbinding(tbcontrols);
            setbindingcls(txtDateDebut, "Datedebut", 0);
            setbindingcls(txtDateFin, "Datefin", 0);
            setbindingcls(cboChambre, "Id_chambre", 1);
            setbindingcls(txtId_malade, "Id_malade", 0);
            setbindingcls(txtPaiement, "Etatpaiement", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDateDebut, txtDateFin, cboChambre, txtId_malade, txtPaiement };
            clearforbinding(tbcontrols);

            setbindinglst(txtDateDebut, "Datedebut", 0);
            setbindinglst(txtDateFin, "Datefin", 0);
            setbindinglst(cboChambre, "Id_chambre", 1);
            setbindinglst(txtId_malade, "Id_malade", 0);
            setbindinglst(txtPaiement, "Etatpaiement", 0);
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void New()
        {
            try
            {
                hospitalisation = new clshospitalisation();
                bln = false;
                bindingcls();
                txtId_malade.Text = clsDoTraitement.IdMalade.ToString();
                txtPaiement.Text = "Non cloturé non payé";
                grpSortie.Enabled = false;
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void refresh()
        {
            try
            {
                bindingcls();
                txtId_malade.Text = clsDoTraitement.IdMalade.ToString();
                bsrc.DataSource = clsMetier.GetInstance().getAllClshospitalisation1(clsDoTraitement.IdMalade, "Non cloturé non payé", "Payé non cloturé");
                bsrcRest.DataSource = clsMetier.GetInstance().getAllClshospitalisation1(clsDoTraitement.IdMalade, "Cloturé non payé", "Cloturé");

                cboChambre.DataSource = clsMetier.GetInstance().getAllClschambre();
                //setMembersallcbo(cboChambre, "", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmDossierHospitalisationPaiement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvHospitalisation };
                ComboBox[] cbo = { cboChambre };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void FrmDossierHospitalisationPaiement_Load(object sender, EventArgs e)
        {
            grpSortie.Enabled = false;
            try
            {
                bindingcls();
                dgvHospitalisation.DataSource = bsrc;
                //setMembersalllst(lstArchive, "Datedebut", "Id");
                refresh();
                if (cboChambre.Items.Count > 0) cboChambre.SelectedIndex = 0;
            }
            catch (Exception) { }
            Affiche1.Height = 203;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    hospitalisation.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clshospitalisation h = (clshospitalisation)bsrc.Current;
                        new clshospitalisation().update(h);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                        clshospitalisation h = (clshospitalisation)bsrc.Current;
                        new clshospitalisation().delete(h);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void cboChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChambre.Items.Count > 0)
            {
                hospitalisation.Id_chambre = ((clschambre)cboChambre.SelectedItem).Id;
            }
        }

        private void cboChambre_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboChambre.DataSource = clsMetier.GetInstance().getAllClschambre();
            }
            catch (Exception) { }
        }

        private void dgvHospitalisation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvHospitalisation.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                    clsDoTraitement.id_hospitalisation = ((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem).Id;
                    clsDoTraitement.id_hospitalisation_consomme = ((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem).Id;
                    clsDoTraitement.id_hospitalisation_mvt = ((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem).Id;


                    if (((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem).Datefin == null)
                    {
                        grpSortie.Enabled = true;
                    }
                    else
                    {
                        grpSortie.Enabled = false;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void lblAddChambre_Click(object sender, EventArgs e)
        {
            ChambresFrm fr = new ChambresFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void cmdAddCatChambre_Click(object sender, EventArgs e)
        {
            CategorieChambreFrm fr = new CategorieChambreFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void valider_Click(object sender, EventArgs e)
        {
            try
            {
                if (bln)
                {
                    clshospitalisation h = new clshospitalisation();
                    h.Id = (((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Id;
                    h.Datedebut = (((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Datedebut;
                    h.Id_chambre = (((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Id_chambre;
                    h.Id_malade = (((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Id_malade;

                    if ((((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Etatpaiement == "Non cloturé non payé")
                    {
                        h.Etatpaiement = "Cloturé non payé";
                        h.Datefin = txtDateFin.Value;
                        if (h.Datefin == null)
                        {
                            MessageBox.Show((((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Id_malade + "", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            h.Datefin = DateTime.Today;
                            new clshospitalisation().update(h);
                            MessageBox.Show("Sortie éffectuée avec succès!", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                        }
                        else
                        {
                            if (h.Datedebut > h.Datefin)
                            {
                                MessageBox.Show("La date de sortie ne peut pas etre inférieur à la date d'entrée", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                new clshospitalisation().update(h);
                                MessageBox.Show("Sortie éffectuée avec succès!", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refresh();
                                //clsDoTraitement.idMaladeDossierPre = ((clsmalade)lstMalade.SelectedItem).Id;
                                //pnAffichage.Controls.Clear();
                                //frmDossierPreconsultationPaiement frm = new frmDossierPreconsultationPaiement();
                                //frm.Parent = pnAffichage;
                            }
                        }
                    }
                    else
                    {
                        h.Etatpaiement = "Cloturé";
                        h.Datefin = txtDateFin.Value;
                        if (h.Datefin == null)
                        {
                            MessageBox.Show((((clshospitalisation)dgvHospitalisation.SelectedRows[0].DataBoundItem)).Id_malade + "", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            h.Datefin = DateTime.Today;
                            new clshospitalisation().update(h);
                            MessageBox.Show("Sortie éffectuée avec succès!", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                        }
                        else
                        {
                            if (h.Datedebut > h.Datefin)
                            {
                                MessageBox.Show("La date de sortie ne peut pas etre inférieur à la date d'entrée", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                new clshospitalisation().update(h);
                                MessageBox.Show("Sortie éffectuée avec succès!", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " >> " + "La date de sortie ne peut pas etre inférieur à la date d'entrée", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
