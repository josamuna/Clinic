using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clssubit 
{
  //***Les variables globales***
 private int   id ;
 private DateTime?  date ;
 private string   observation ;
 private int   id_malade ;
 private int   id_intervention ;
 private string etatpaiement;
 private string designationComplete;

  //***Listes***
  public List<clssubit> listes(){
 return clsMetier.GetInstance().getAllClssubit();
}
 public  List<clssubit>   listes(string criteria){
 return clsMetier.GetInstance().getAllClssubit(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClssubit(this);
 }
 public  int  update(clssubit varscls){
 return clsMetier.GetInstance().updateClssubit(varscls);
 }
 public  int  delete(clssubit varscls){
 return clsMetier.GetInstance().deleteClssubit(varscls);
 }
  //***Le constructeur par defaut***
  public    clssubit() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de observation***
 public  string   Observation {

get { return observation; } 
set { observation = value; }
}
  //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de id_intervention***
 public  int   Id_intervention {

get { return id_intervention; } 
set { id_intervention = value; }
}

 public string Etatpaiement
 {
     get { return etatpaiement; }
     set { etatpaiement = value; }
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
} //***fin class

} //***fin namespace
