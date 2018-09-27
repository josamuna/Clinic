using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class clsmouvementmaladiegynecologique
    {
  //***Les variables globales***
 private int   id ;
 private DateTime? date;
 private int   id_maladie ;
 private int id_consultationgynecologique;
  //***Listes***
 public List<clsmouvementmaladiegynecologique> listes()
 {
     return clsMetier.GetInstance().getAllClsmouvementmaladiegynecologique();
 }
 public List<clsmouvementmaladiegynecologique> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClsmouvementmaladiegynecologique(criteria);
 }
 public int inserts()
 {
     return clsMetier.GetInstance().insertClsmouvementmaladiegynecologique(this);
 }
 public int update(clsmouvementmaladiegynecologique varscls)
 {
     return clsMetier.GetInstance().updateClsmouvementmaladiegynecologique(varscls);
 }
 public int delete(clsmouvementmaladiegynecologique varscls)
 {
     return clsMetier.GetInstance().deleteClsmouvementmaladiegynecologique(varscls);
 }
  //***Le constructeur par defaut***
 public clsmouvementmaladiegynecologique() 
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
 public int Id_consultationgynecologique
 {

     get { return id_consultationgynecologique; }
     set { id_consultationgynecologique = value; }
}
 //***Accesseur de date***

 public DateTime? Date
 {
     get { return date; }
     set { date = value; }
 }
} //***fin class
}
