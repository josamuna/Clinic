using System;
using System.Windows.Forms;
using System.Drawing;
using GestionClinic_LIB;


namespace GestionClinic_WIN
{
    public partial class Hospitalisation : UserControl
    {
        public Hospitalisation()
        {
            InitializeComponent();
        }
        clshospitalisation hospitalisation = new clshospitalisation();
        BindingSource bsrc = new BindingSource();
        BindingSource bsrcRest = new BindingSource();
        private bool bln = false;

        #region Mouvement Hospitalisation
        clsmvmhospitalisation mvmhospitalisation = new clsmvmhospitalisation();
        BindingSource bsrc1 = new BindingSource();
        bool bln1 = false;

        private void clearforbinding1(Control[] ctrl)
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

        private void setbindingcls1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", mvmhospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", mvmhospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", mvmhospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", mvmhospitalisation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls1()
        {
            btnDelete1.Enabled = false;
            Control[] tbcontrols = { txtTemperature, txtDate, txtPLS, txtTa, txtResiration, txtIdHospitalisation };
            clearforbinding1(tbcontrols);

            setbindingcls1(txtTemperature, "Temperature", 0);
            setbindingcls1(txtDate, "Date", 0);
            setbindingcls1(txtPLS, "Pls", 0);
            setbindingcls1(txtTa, "Ta", 0);
            setbindingcls1(txtResiration, "Resiration", 0);
            setbindingcls1(txtIdHospitalisation, "Id_hospitalisation", 0);
        }

        private void bindignlst1()
        {
            btnDelete1.Enabled = true;
            Control[] tbcontrols = { txtTemperature, txtDate, txtPLS, txtTa, txtResiration, txtIdHospitalisation };
            clearforbinding1(tbcontrols);

            setbindinglst1(txtTemperature, "Temperature", 0);
            setbindinglst1(txtDate, "Date", 0);
            setbindinglst1(txtPLS, "Pls", 0);
            setbindinglst1(txtTa, "Ta", 0);
            setbindinglst1(txtResiration, "Resiration", 0);
            setbindinglst1(txtIdHospitalisation, "Id_hospitalisation", 0);
        }

        private void refresh1()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClsmvmhospitalisation1(clsDoTraitement.id_hospitalisation_mvt);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void New1()
        {
            try
            {
                mvmhospitalisation = new clsmvmhospitalisation();
                bln1 = false;
                bindingcls1();
                txtIdHospitalisation.Text = clsDoTraitement.id_hospitalisation_mvt.ToString();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }
        #endregion

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

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDateDebut, txtDateFin, cboChambre, txtId_malade,txtPaiement};
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
                txtId_malade.Text = clsDoTraitement.idMalade_hospitalisation.ToString();
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
                txtId_malade.Text = clsDoTraitement.idMalade_hospitalisation.ToString();
                cboChambre.DataSource = clsMetier.GetInstance().getAllClschambre();
                setMembersallcbo(cboChambre, "DesignationConplete", "Id");

                bsrc.DataSource = clsMetier.GetInstance().getAllClshospitalisation1(clsDoTraitement.idMalade_hospitalisation, "Non cloturé non payé", "Payé non cloturé");
                bsrcRest.DataSource = clsMetier.GetInstance().getAllClshospitalisation1(clsDoTraitement.idMalade_hospitalisation, "Cloturé non payé", "Cloturé");             
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Hospitalisation_Load(object sender, EventArgs e)
        {
            grpSortie.Enabled = false;
            try
            {
                bindingcls();
                dgvHospitalisation.DataSource = bsrc;
                lstArchive.DataSource = bsrcRest;
                //setMembersalllst(lstArchive, "Datedebut", "Id");
                refresh();
                //if (cboChambre.Items.Count > 0) cboChambre.SelectedIndex = 0;

                bindingcls1();
                dgvMouvementHospitalisation.DataSource = bsrc1;
                //refresh1();
            }
            catch (Exception) { }
        }

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    
                    //Chargement des mouvement Hospitalisation
                    try
                    {
                        //bindingcls1();
                        //dgvMouvementHospitalisation.DataSource = bsrc1;
                        refresh1();
                    }
                    catch (Exception) { }
      
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
            ChambresFrm frm = new ChambresFrm();
            frm.ShowDialog();
        }

        private void lblAutresInformations_Click(object sender, EventArgs e)
        {
            ////Affiche2.Controls.Clear();
            ////frmMouvementHospitalisationUser frm = new frmMouvementHospitalisationUser();
            ////frm.Parent = Affiche2;
            ////lblAutresInformations.BackColor = Color.Silver;
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
                MessageBox.Show(ex.Message+" >> "+"La date de sortie ne peut pas etre inférieur à la date d'entrée", "Sortie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChambre.Items.Count > 0)
            {
                hospitalisation.Id_chambre = ((clschambre)cboChambre.SelectedItem).Id;
            }
        }

        private void lstArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstArchive.SelectedItems.Count > 0)
            {
                txtEtatPaiement.Text = clsMetier.GetInstance().getClschambre(((clshospitalisation)lstArchive.SelectedItem).Id_chambre).DesignationConplete;
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clshospitalisation)lstArchive.SelectedItem).Etatpaiement.ToString() == "Cloturé non payé")
                {
                    clshospitalisation h = new clshospitalisation();
                    h.Id = (((clshospitalisation)lstArchive.SelectedItem)).Id;
                    h.Datedebut = (((clshospitalisation)lstArchive.SelectedItem)).Datedebut;
                    h.Id_chambre = (((clshospitalisation)lstArchive.SelectedItem)).Id_chambre;
                    h.Id_malade = (((clshospitalisation)lstArchive.SelectedItem)).Id_malade;
                    h.Datefin = null;
                    h.Etatpaiement = "Non cloturé non payé";
                    new clshospitalisation().update(h);
                    MessageBox.Show("Dossier restauré avec succès!", "Restauration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    clshospitalisation h = new clshospitalisation();
                    h.Id = (((clshospitalisation)lstArchive.SelectedItem)).Id;
                    h.Datedebut = (((clshospitalisation)lstArchive.SelectedItem)).Datedebut;
                    h.Id_chambre = (((clshospitalisation)lstArchive.SelectedItem)).Id_chambre;
                    h.Id_malade = (((clshospitalisation)lstArchive.SelectedItem)).Id_malade;
                    h.Datefin = null;
                    h.Etatpaiement = "Non cloturé payé";
                    new clshospitalisation().update(h);
                    MessageBox.Show("Dossir restauré avec succès!", "Restauration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            New1();
        }

        private void btnRefreh1_Click(object sender, EventArgs e)
        {
            refresh1();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln1)
                {
                    mvmhospitalisation.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc1.DataSource != null)
                    {
                        clsmvmhospitalisation m = (clsmvmhospitalisation)bsrc1.Current;
                        new clsmvmhospitalisation().update(m);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                refresh1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc1.DataSource != null)
                    {
                        clsmvmhospitalisation m = (clsmvmhospitalisation)bsrc1.Current;
                        new clsmvmhospitalisation().delete(m);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                refresh1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvMouvementHospitalisation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMouvementHospitalisation.SelectedRows.Count > 0)
                {
                    bindignlst1();
                    bln1 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void txtTemperature_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtTemperature.Text) == 25)
                {
                    //Rouge fort
                    //Température minimale du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtTemperature.Text) == 42)
                {
                    //Rouge fort
                    //Température maximale du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtTemperature.Text) > 25 && Convert.ToDouble(txtTemperature.Text) < 36.1)
                {
                    //Champ en rouge faible
                    //Températures normales du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(252, 165, 158);
                }
                else if (Convert.ToDouble(txtTemperature.Text) >= 36.1 && Convert.ToDouble(txtTemperature.Text) <= 37.8)
                {
                    //Champ en vert
                    //Températures normales du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(194, 214, 155);
                }
                else if (Convert.ToDouble(txtTemperature.Text) > 37.8 && Convert.ToDouble(txtTemperature.Text) < 42)
                {
                    //Champ en rouge faible
                    //Températures normales du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(252, 165, 158);
                }
                else ((Control)txtTemperature).BackColor = Color.FromArgb(150, 148, 152);
            }
            catch (Exception) { }
        }     
    }
}
