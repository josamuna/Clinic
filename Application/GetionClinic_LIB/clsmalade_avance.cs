using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsmalade_avance
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_dossieravance;
        private double? avance;
        private double? montant;
        private double? cumul;
        private bool? solde;

        //***Listes***
        public List<clsmalade_avance> listes()
        {
            return clsMetier.GetInstance().getAllClsmalade_avance();
        }
        public List<clsmalade_avance> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsmalade_avance(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsmalade_avance(this);
        }
        public int update(clsmalade_avance varscls)
        {
            return clsMetier.GetInstance().updateClsmalade_avance(varscls);
        }
        public int delete(clsmalade_avance varscls)
        {
            return clsMetier.GetInstance().deleteClsmalade_avance(varscls);
        }
        //***Le constructeur par defaut***
        public clsmalade_avance()
        {
        }

        //***Accesseur de id***
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        //***Accesseur de date***
        public DateTime? Date
        {
            get { return date; }
            set { date = value; }
        }
        //***Accesseur de id_malade***
        public int? Id_malade
        {
            get { return id_malade; }
            set { id_malade = value; }
        }
        //***Accesseur de montant***
        public double? Montant
        {
            get { return montant; }
            set { montant = value; }
        }
        //***Accesseur de id_dossieravance***
        public int? Id_dossieravance
        {
            get { return id_dossieravance; }
            set { id_dossieravance = value; }
        }
        //***Accesseur de avance***
        public double? Avance
        {
            get { return avance; }
            set { avance = value; }
        }
        //***Accesseur de cumul***
        public double? Cumul
        {
            get { return cumul; }
            set { cumul = value; }
        }
        //***Accesseur de solde***
        public bool? Solde
        {
            get { return solde; }
            set { solde = value; }
        }

        public override string ToString()
        {
            return Date.ToString();
        }
    }
}
