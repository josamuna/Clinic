using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ApprovisionementArticleFrm : Form
    {
        public ApprovisionementArticleFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clslivraison approvisionnement = new clslivraison();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;
        bool doUpdate = false;

        public void enabledItem(bool etat)
        {
            btnDelete.Enabled = etat;
            btnSave.Enabled = etat;
            btnAdd.Enabled = etat;
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
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", approvisionnement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", approvisionnement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", approvisionnement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", approvisionnement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtDate, cboArticle, cboConditionnement, cboFournisseur, txtDateExpiration, txtQuantite, txtPUAchat };
            clearforbinding(tbcontrols);

            setbindingcls(txtDate, "Date", 0);
            setbindingcls(cboArticle, "Id_article", 1);
            setbindingcls(cboFournisseur, "Id_fournisseur", 1);
            setbindingcls(txtDateExpiration, "Dateexpiration", 0);
            setbindingcls(txtQuantite, "Quantinte", 0);
            setbindingcls(cboConditionnement, "Id_conditionnement", 1);
            setbindingcls(txtPUAchat, "Puachat", 0);
        }

        private void bindignlst()
        {
            //btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, cboArticle, cboConditionnement, cboFournisseur, txtDateExpiration, txtQuantite, txtPUAchat };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(cboArticle, "Id_article", 1);
            setbindinglst(cboFournisseur, "Id_fournisseur", 1);
            setbindinglst(txtDateExpiration, "Dateexpiration", 0);
            setbindinglst(cboConditionnement, "Id_conditionnement", 1);
            setbindinglst(txtQuantite, "Quantinte", 0);
            setbindinglst(txtPUAchat, "Puachat", 0);

            //Recuperation de la valeur de la quantite affiche pour probable modification du stock
            clsDoTraitement.oldValueStockModifie = Convert.ToDouble(txtQuantite.Text);
        }

        private void New()
        {
            approvisionnement = new clslivraison();
            //btnSave.Enabled = true;
            bln = false;
            bindingcls();
            if (cboArticle.Items.Count > 0) cboArticle.SelectedIndex = 0;
            if (cboFournisseur.Items.Count > 0) cboFournisseur.SelectedIndex = 0;
            if (cboConditionnement.Items.Count > 0) cboConditionnement.SelectedIndex = 0;
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
                if (!chkAfficheAll.Checked)
                {
                    //On affiche toutes les sorties pour la date du jour : Today
                    if (doUpdate) bsrc.DataSource = clsMetier.GetInstance().getAllClslivraison2(clsMetier.dateMAJAppro.ToString().Substring(0, 10));
                    else bsrc.DataSource = clsMetier.GetInstance().getAllClslivraison2(txtDateSortie.Value.ToString().Substring(0, 10));
                }
                else
                {
                    //On affiche toutes les sorties sans exception
                    bsrc.DataSource = clsMetier.GetInstance().getAllClslivraison();
                }

                doUpdate = false;

                cboArticle.DataSource = clsMetier.GetInstance().getAllClsarticle();
                setMembersallcbo(cboArticle, "Desination", "Id");
                cboFournisseur.DataSource = clsMetier.GetInstance().getAllClsfournisseur();
                setMembersallcbo(cboFournisseur, "Nom_complet", "Id");
                cboConditionnement.DataSource = clsMetier.GetInstance().getAllClsconditionnement();
                setMembersallcbo(cboConditionnement, "Designation", "Id");

                if (cboArticle.Items.Count > 0) cboArticle.SelectedIndex = 0;
                if (cboFournisseur.Items.Count > 0) cboFournisseur.SelectedIndex = 0;
                if (cboConditionnement.Items.Count > 0) cboConditionnement.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmApprovisionementArticle_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                ComboBox[] cbo = { cboArticle, cboFournisseur, cboConditionnement };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void FrmApprovisionementArticle_Load(object sender, EventArgs e)
        {
            chkAfficheAll.Checked = false;
            txtDateSortie.Enabled = true;

            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();

                //bool ok1 = true, ok2 = true, ok3 = true, ok4 = true, ok5 = true, ok6 = true;
                //foreach (string str_groupe in clsDoTraitement.valueUser)
                //{
                //    if (str_groupe.Equals("Administrateur"))
                //    {
                //        this.enabledItem(true);
                //        break;
                //    }
                //    else if (str_groupe.Equals("Médecin") && ok1)
                //    {
                //        this.enabledItem(false);
                //        ok1 = false;
                //    }
                //    else if (str_groupe.Equals("Infirmier") && ok2)
                //    {
                //        this.enabledItem(false);
                //        ok2 = false;
                //    }
                //    else if (str_groupe.Equals("Laborantin") && ok3)
                //    {
                //        this.enabledItem(false);
                //        ok2 = false;
                //    }
                //    else if (str_groupe.Equals("Pharmacien"))
                //    {
                //        this.enabledItem(true);
                //        break;
                //    }
                //    else if (str_groupe.Equals("Caissier") && ok4)
                //    {
                //        this.enabledItem(false);
                //        ok4 = false;
                //    }
                //    else if (str_groupe.Equals("Médecin gynéco.") && ok5)
                //    {
                //        this.enabledItem(false);
                //        ok5 = false;
                //    }
                //    else if (str_groupe.Equals("Service") && ok6)
                //    {
                //        this.enabledItem(false);
                //        ok6 = false;
                //    }
                //}
            }
            catch (Exception EX) { MessageBox.Show("Erreur lors du chargement des listes déroulantes..." + EX.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            
            //btnDelete.Enabled = false;
            //btnSave.Enabled = false;
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
                    approvisionnement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clslivraison s = (clslivraison)bsrc.Current;
                        new clslivraison().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                doUpdate = true;
                this.New();
                refresh();
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
                        clslivraison d = (clslivraison)bsrc.Current;
                        new clslivraison().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormVaccination = true;
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

        private void cboArticle_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormArticle)
            {
                try
                {
                    cboArticle.DataSource = clsMetier.GetInstance().getAllClsarticle();
                }
                catch (Exception) { }
            }
        }

        private void cboConditionnement_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormConditionnement)
            {
                try
                {
                    cboConditionnement.DataSource = clsMetier.GetInstance().getAllClsconditionnement();
                }
                catch (Exception) { }
            }
        }

        private void lblConditionnement_Click(object sender, EventArgs e)
        {
            CondtionnementFrm frm = new CondtionnementFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;

                    //bool ok1 = true, ok2 = true, ok3 = true, ok4 = true, ok5 = true, ok6 = true, ok7 = false;
                    //foreach (string str_groupe in clsDoTraitement.valueUser)
                    //{
                    //    if (str_groupe.Equals("Administrateur"))
                    //    {
                    //        this.enabledItem(true);
                    //        break;
                    //    }
                    //    else if (str_groupe.Equals("Médecin") && ok1)
                    //    {
                    //        this.enabledItem(false);
                    //        ok1 = false;
                    //    }
                    //    else if (str_groupe.Equals("Infirmier") && ok2)
                    //    {
                    //        this.enabledItem(false);
                    //        ok2 = false;
                    //    }
                    //    else if (str_groupe.Equals("Laborantin") && ok3)
                    //    {
                    //        this.enabledItem(false);
                    //        ok2 = false;
                    //    }
                    //    else if (str_groupe.Equals("Pharmacien"))
                    //    {
                    //        this.enabledItem(true);
                    //        break;
                    //    }
                    //    else if (str_groupe.Equals("Caissier") && ok4)
                    //    {
                    //        this.enabledItem(false);
                    //        ok4 = false;
                    //    }
                    //    else if (str_groupe.Equals("Médecin gynéco.") && ok5)
                    //    {
                    //        this.enabledItem(false);
                    //        ok5 = false;
                    //    }
                    //    else if (str_groupe.Equals("Service") && ok6)
                    //    {
                    //        this.enabledItem(false);
                    //        ok6 = false;
                    //    }
                    //}
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void lblAddArticle_Click(object sender, EventArgs e)
        {
            ArticleFrm frm = new ArticleFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }
    }
}
