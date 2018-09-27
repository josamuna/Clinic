using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossierechographie
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_agent;
        private int? id_tarifechographie;
        private string etatpaiement;
        private string designationComplete;

        //***Listes***
        public List<clsdossierechographie> listes()
        {
            return clsMetier.GetInstance().getAllClsdossierechographie();
        }
        public List<clsdossierechographie> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossierechographie(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossierechographie(this);
        }
        public int update(clsdossierechographie varscls)
        {
            return clsMetier.GetInstance().updateClsdossierechographie(varscls);
        }
        public int delete(clsdossierechographie varscls)
        {
            return clsMetier.GetInstance().deleteClsdossierechographie(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossierechographie()
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
        //***Accesseur de id_tarifechographie***
        public int? Id_tarifechographie
        {
            get { return id_tarifechographie; }
            set { id_tarifechographie = value; }
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
