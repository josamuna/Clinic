using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsprise_vitamine 
{
  //***Les variables globales***
 private int   id ;
 private int?  id_periode ;
 private int?  id_malade ;
 private int?  id_vitamine ;
 private DateTime?  date_operation ;

 public string Designation
 {
     get { return id_periode + "(CdPeriode)-" + id_malade + "CdMalade-" + id_vitamine + "CdVitamine_" + date_operation; }
     //set { designation = value; }
 }
  //***Listes***
  public List<clsprise_vitamine> listes(){
 return clsMetier.GetInstance().getAllClsprise_vitamine();
}
 public  List<clsprise_vitamine>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsprise_vitamine(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsprise_vitamine(this);
 }
 public  int  update(clsprise_vitamine varscls){
 return clsMetier.GetInstance().updateClsprise_vitamine(varscls);
 }
 public  int  delete(clsprise_vitamine varscls){
 return clsMetier.GetInstance().deleteClsprise_vitamine(varscls);
 }
  //***Le constructeur par defaut***
  public    clsprise_vitamine() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_periode***
 public  int ?   Id_periode {

get { return id_periode; } 
set { id_periode = value; }
}
  //***Accesseur de id_malade***
 public  int ?   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de id_vitamine***
 public  int ?   Id_vitamine {

get { return id_vitamine; } 
set { id_vitamine = value; }
}
  //***Accesseur de date_operation***
 public  DateTime ?   Date_operation {

get { return date_operation; } 
set { date_operation = value; }
}

} //***fin class

} //***fin namespace
