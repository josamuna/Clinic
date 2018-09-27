using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossieravance
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_tarifavance;
        private string etatpaiement;
        //***Listes***
        public List<clsdossieravance> listes()
        {
            return clsMetier.GetInstance().getAllClsdossieravance();
        }
        public List<clsdossieravance> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossieravance(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossieravance(this);
        }
        public int update(clsdossieravance varscls)
        {
            return clsMetier.GetInstance().updateClsdossieravance(varscls);
        }
        public int delete(clsdossieravance varscls)
        {
            return clsMetier.GetInstance().deleteClsdossieravance(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossieravance()
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
        //***Accesseur de id_tarifavance***
        public int? Id_tarifavance
        {
            get { return id_tarifavance; }
            set { id_tarifavance = value; }
        }
        //***Accesseur de etatpaiement***
        public string Etatpaiement
        {
            get { return etatpaiement; }
            set { etatpaiement = value; }
        }

        public override string ToString()
        {
            return Date.ToString();
        }
    }
}
