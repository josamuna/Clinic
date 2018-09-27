using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifconsultationpostnatal 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationComplete;
 private int id_de_dossierconsultationpostnatal;

  //***Listes***
  public List<clstarifconsultationpostnatal> listes(){
 return clsMetier.GetInstance().getAllClstarifconsultationpostnatal();
}
 public  List<clstarifconsultationpostnatal>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifconsultationpostnatal(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifconsultationpostnatal(this);
 }
 public  int  update(clstarifconsultationpostnatal varscls){
 return clsMetier.GetInstance().updateClstarifconsultationpostnatal(varscls);
 }
 public  int  delete(clstarifconsultationpostnatal varscls){
 return clsMetier.GetInstance().deleteClstarifconsultationpostnatal(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifconsultationpostnatal() 
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
 //***Accesseur de id_de_dossierconsultationpostnatal***
 public int Id_de_dossierconsultationpostnatal
 {
     get { return id_de_dossierconsultationpostnatal; }
     set { id_de_dossierconsultationpostnatal = value; }
 }
 public override string ToString()
 {
     return DesignationComplete;
 }
} //***fin class

} //***fin namespace
