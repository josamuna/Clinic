﻿using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class CondtionnementFrm : Form
    {
        public CondtionnementFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsconditionnement conditionnement = new clsconditionnement();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;
        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtDesignation.DataBindings.Clear();
            txtDesignation.Focus();
            txtDesignation.DataBindings.Add("Text", conditionnement, "Designation", true,DataSourceUpdateMode.OnPropertyChanged);
        }
        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtDesignation.DataBindings.Clear();
            txtDesignation.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void New()
        {
            conditionnement = new clsconditionnement();
            bln = false;
            bindingcls();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsconditionnement();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    conditionnement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsconditionnement s = (clsconditionnement)bsrc.Current;
                        new clsconditionnement().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des conditionnements sur le formulair appellant
                clsDoTraitement.EnterForFormConditionnement = true;
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
                        clsconditionnement d = (clsconditionnement)bsrc.Current;
                        new clsconditionnement().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                    //Permet l'actualisation des valeur des conditionnements sur le formulair appellant
                    clsDoTraitement.EnterForFormConditionnement = true;
                }
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

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void FrmCondtionnement_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void FrmCondtionnement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
