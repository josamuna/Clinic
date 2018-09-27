
using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clstarifconsultationprenatal 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationComplete;
 private int id_de_dossierconsultationprenatale;

  //***Listes***
  public List<clstarifconsultationprenatal> listes(){
 return clsMetier.GetInstance().getAllClstarifconsultationprenatal();
}
 public  List<clstarifconsultationprenatal>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifconsultationprenatal(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifconsultationprenatal(this);
 }
 public  int  update(clstarifconsultationprenatal varscls){
 return clsMetier.GetInstance().updateClstarifconsultationprenatal(varscls);
 }
 public  int  delete(clstarifconsultationprenatal varscls){
 return clsMetier.GetInstance().deleteClstarifconsultationprenatal(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifconsultationprenatal() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de designation***
 public  string   Designation {

get { return designation; } 
set { designation = value; }
}
  //***Accesseur de montant***
 public  double ?   Montant {

get { return montant; } 
set { montant = value; }
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
 //***Accesseur de id_de_dossierconsultationprenatale***
 public int Id_de_dossierconsultationprenatale
 {
     get { return id_de_dossierconsultationprenatale; }
     set { id_de_dossierconsultationprenatale = value; }
 }
} //***fin class

} //***fin namespace
