using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossiersoin
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_agent;
        private int? id_tarifsoin;
        private string etatpaiement;
        private string designationComplete;

        //***Listes***
        public List<clsdossiersoin> listes()
        {
            return clsMetier.GetInstance().getAllClsdossiersoin();
        }
        public List<clsdossiersoin> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossiersoin(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossiersoin(this);
        }
        public int update(clsdossiersoin varscls)
        {
            return clsMetier.GetInstance().updateClsdossiersoin(varscls);
        }
        public int delete(clsdossiersoin varscls)
        {
            return clsMetier.GetInstance().deleteClsdossiersoin(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossiersoin()
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
        //***Accesseur de id_tarifsoin***
        public int? Id_tarifsoin
        {

            get { return id_tarifsoin; }
            set { id_tarifsoin = value; }
        }
        //***Accesseur de etatpaiement***
        public string Etatpaiement
        {

            get { return etatpaiement; }
            set { etatpaiement = value; }
        }

        public int? Id_agent
        {
            get { return id_agent; }
            set { id_agent = value; }
        }
        public string DesignationComplete
        {
            get { return designationComplete; }
            set { designationComplete = value; }
        }
        public override string ToString()
        {
            return DesignationComplete;
        }
    }
}
