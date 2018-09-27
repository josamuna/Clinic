using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class FournisseurFrm : Form
    {
        public FournisseurFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsfournisseur fourniseur = new clsfournisseur();
        clspersonne personne = new clspersonne();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtNumero };
            clearforbinding(tbcontrols);

            setbindingcls(txtNumero, "Numero", 0);
            //setbindingcls(txtPersonne, "Nom", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtPersonne, txtNumero };
            clearforbinding(tbcontrols);

            setbindinglst(txtNumero, "Numero", 0);
            setbindinglst(txtPersonne, "Nom", 0);
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", fourniseur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", fourniseur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", fourniseur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", fourniseur, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            fourniseur = new clsfournisseur();
            bln = false;
            bindingcls();

            btnAfficherDonnees.Enabled = false;
            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            txtSexe.Clear();
            txtEtatCivil.Clear();
            txtNumero.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsfournisseur1(-100);
                dgv.DataSource = bsrc;
            }
            catch (Exception) { }

            RecherchePersonneFrm frm = new RecherchePersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
    
            if (clsDoTraitement.doubleclicRecherchePersonneDg)
            {
                btnSave.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneDg = false;
                txtPersonne.Text = clsDoTraitement.FullNamePersonne;
            }
            else btnSave.Enabled = false;
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void refresh()
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            txtSexe.Clear();
            txtEtatCivil.Clear();
            txtNumero.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsfournisseur1(-100);
                dgv.DataSource = bsrc;
            }
            catch (Exception) { }
        }

        private void FrmFournisseur_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { } 
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Numero LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
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
                    fourniseur.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsfournisseur s = new clsfournisseur();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("numero")) s.Numero = ((string)obj[i]);
                            else if (dtc.ToString().Equals("idFrss")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            i++;
                        }
                        new clsfournisseur().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des informations du fournisseur sélectionné =>" + ex.Message, "Affichage informations fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //this.New();
            //refresh();
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
                        clsfournisseur s = new clsfournisseur();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("numero")) s.Numero = ((string)obj[i]);
                            else if (dtc.ToString().Equals("idFrss")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            i++;
                        }
                        new clsfournisseur().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.New();
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmFournisseur_Load(object sender, EventArgs e)
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            bindingcls();
            dgv.DataSource = bsrc;

            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }
        }

        private void lblAddPersonne_Click(object sender, EventArgs e)
        {
            PersonneFrm frm = new PersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void txtPersonne_DoubleClick(object sender, EventArgs e)
        {
            RecherchePersonneFournisseurFrm frm = new RecherchePersonneFournisseurFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();

            if (clsDoTraitement.doubleclicRecherchePersonneFournisseurDg) btnAfficherDonnees.Enabled = true;
            else btnAfficherDonnees.Enabled = false;
        }

        private void btnAfficherDonnees_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneFournisseurDg = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des informations du fournisseur sélectionné =>" + ex.Message, "Affichage informations fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loadData()
        {
            bsrc.DataSource = clsMetier.GetInstance().getAllClsfournisseur1(clsDoTraitement.Identifiant_Fournisseur);

            try
            {
                personne = clsMetier.GetInstance().getClspersonne(clsDoTraitement.Identifiant_Personne);

                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtAdresse.Text = personne.Adresse;

                txtPersonne.Text = personne.Nom + " " + (string.IsNullOrEmpty(personne.Postnom) ? "" : personne.Postnom) + " " + (string.IsNullOrEmpty(personne.Prenom) ? "" : personne.Prenom);

                try
                {
                    pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }

                bindignlst();
                bln = true;
            }
            catch (Exception) { }
        }
    }
}
