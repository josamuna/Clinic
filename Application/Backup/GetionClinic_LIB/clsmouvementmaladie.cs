using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsmouvementmaladie
    {
  //***Les variables globales***
 private int   id ;
 private DateTime? date;
 private int   id_maladie ;
 private int   id_mouvementconsultation ;
  //***Listes***
 public List<clsmouvementmaladie> listes()
 {
     return clsMetier.GetInstance().getAllClsmouvementmaladie();
 }
 public List<clsmouvementmaladie> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClsmouvementmaladie(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsmouvementmaladie(this);
 }
 public int update(clsmouvementmaladie varscls)
 {
     return clsMetier.GetInstance().updateClsmouvementmaladie(varscls);
 }
 public int delete(clsmouvementmaladie varscls)
 {
     return clsMetier.GetInstance().deleteClsmouvementmaladie(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmouvementmaladie() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_maladie***
 public  int   Id_maladie {

get { return id_maladie; } 
set { id_maladie = value; }
}
  //***Accesseur de id_mouvementconsultation***
 public  int   Id_mouvementconsultation {

get { return id_mouvementconsultation; } 
set { id_mouvementconsultation = value; }
}
 //***Accesseur de date***

 public DateTime? Date
 {
     get { return date; }
     set { date = value; }
 }
} //***fin class
}
