using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsdossierconsultationprenatale
    {
        //***Les variables globales***
        //****private string schaine_conn*****
        private int id;
        private DateTime? date;
        private int? id_malade;
        private int? id_agent;
        private int? id_tarifconsultationprenatatale;
        private string etatpaiement;
        private string designationComplete;

        //***Listes***
        public List<clsdossierconsultationprenatale> listes()
        {
            return clsMetier.GetInstance().getAllClsdossierconsultationprenatale();
        }
        public List<clsdossierconsultationprenatale> listes(string criteria)
        {
            return clsMetier.GetInstance().getAllClsdossierconsultationprenatale(criteria);
        }

        public int inserts()
        {
            return clsMetier.GetInstance().insertClsdossierconsultationprenatale(this);
        }
        public int update(clsdossierconsultationprenatale varscls)
        {
            return clsMetier.GetInstance().updateClsdossierconsultationprenatale(varscls);
        }
        public int delete(clsdossierconsultationprenatale varscls)
        {
            return clsMetier.GetInstance().deleteClsdossierconsultationprenatale(varscls);
        }
        //***Le constructeur par defaut***
        public clsdossierconsultationprenatale()
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
        //***Accesseur de id_tarifconsultation***
        public int? Id_tarifconsultationprenatatale
        {

            get { return id_tarifconsultationprenatatale; }
            set { id_tarifconsultationprenatatale = value; }
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
        public override string ToString()
        {
            return DesignationComplete;
        }

        public string DesignationComplete
        {
            get { return designationComplete; }
            set { designationComplete = value; }
        }
    }
}
