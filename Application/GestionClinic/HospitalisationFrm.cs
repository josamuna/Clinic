using System;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class HospitalisationFrm : Form
    {
        public HospitalisationFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private BindingSource bsrcMalade = new BindingSource();
        clsmalade malade = new clsmalade();

        private void bindingcls()
        {

        }

        void binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                Bitmap bb = new Bitmap(pbPhotoPersonne.Size.Width, pbPhotoPersonne.Size.Height);
                bb = (new clsDoTraitement()).getImageFromByte((byte[])e.Value);
                e.Value = bb;
                //btSupprimerPhoto.Enabled = false;
            }
        }

        private void bingImg(PictureBox pb, Object src, string ctrProp, string obj)
        {
            pb.DataBindings.Clear();
            Binding binding = new Binding(ctrProp, src, obj, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += new ConvertEventHandler(binding_Format);
            pb.DataBindings.Add(binding);
        }

        public void erg()
        {
            lblErgot.Text = "▲";
            lblIntervention.Location = new System.Drawing.Point(16, 55);
            //lblPassationIntervention.Location = new System.Drawing.Point(17, 123);
        }

        public void ergot()
        {
            if (lblErgot.Text == "▼")
            {
                erg();
            }
            else
            {
                lblErgot.Text = "▼";
                lblIntervention.Location = new System.Drawing.Point(17, 79);
            }
        }

        private void FrmHospitalisation_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrcMalade };
                clsDoTraitement.GetInstance().unloadData(bdsrc);
            }
            catch (Exception) { }

            this.Dispose();
        }

        private void lblHospitalisation_Click(object sender, EventArgs e)
        {
            Affichage.Controls.Clear();
            Hospitalisation frm = new Hospitalisation();
            frm.Parent = Affichage;
            //Affichage.Container.Add(frm);
        }

        private void lblErgot_Click(object sender, EventArgs e)
        {
            ergot();
        }

        private void lblIntervention_Click(object sender, EventArgs e)
        {
            Affichage.Controls.Clear();
            PasserIntervationFrm frm = new PasserIntervationFrm();
            frm.Parent = Affichage;
        }

        private void FrmHospitalisation_Load(object sender, EventArgs e)
        {
            clsDoTraitement.reinitialiseValue();
            rdHospitalisation.Checked = true;
            rdIntervention.Checked = false;

            try
            {
                bindingcls();
                bsrcMalade.DataSource = clsMetier.GetInstance().getAllClsmalade1();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //erg();
        }

        private void lblHospitalisation_DoubleClick(object sender, EventArgs e)
        {
            ergot();
        }

        private void lblTraitHospitalisation_DoubleClick(object sender, EventArgs e)
        {
            ergot();
        }

        private void lblIntervention_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblIntervention).ForeColor = Color.WhiteSmoke;
            ((Control)lblIntervention).BackColor = Color.FromArgb(163, 185, 207);
        }

        private void lblIntervention_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblIntervention).BackColor = Color.Empty;
            ((Control)lblIntervention).ForeColor = Color.Black;
        }

        private void lblRecherche_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblRecherche).ForeColor = Color.WhiteSmoke;
            ((Control)lblRecherche).BackColor = Color.FromArgb(163, 185, 207);
        }

        private void lblRecherche_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblRecherche).BackColor = Color.Empty;
            ((Control)lblRecherche).ForeColor = Color.Black;
        }

        private void lblRecherche_Click(object sender, EventArgs e)
        {
            RecherchePersonneMaladeFrm form = new RecherchePersonneMaladeFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void cmdLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                malade.Id = clsDoTraitement.IdMalade;
                clsDoTraitement.idMalade_hospitalisation = malade.Id;
                clsDoTraitement.idMalade_Intervention = malade.Id;

                lblNomMalade.Text = clsDoTraitement.doubleclic_nom_malade;

                try
                {
                    pbPhotoPersonne.Image = clsDoTraitement.GetInstance().getImageFromByte(clsMetier.GetInstance().getClsmalade1(malade.Id).Photo);
                }
                catch (Exception) { }

                if (rdHospitalisation.Checked)
                {
                    clsDoTraitement.blnAutresFraisActivate = false;
                    clsDoTraitement.blnMvtHospitalisationActivate = true;
                    clsDoTraitement.blnConsomationActivate = false;

                    Affichage.Controls.Clear();
                    Hospitalisation frm = new Hospitalisation();
                    frm.Parent = Affichage;
                }
                else if (rdIntervention.Checked)//(blnPassationInstervention == true)
                {
                    Affichage.Controls.Clear();
                    PasserIntervationFrm frm = new PasserIntervationFrm();
                    frm.Parent = Affichage;
                }
            }
            catch (Exception) { }
        }
    }
}
