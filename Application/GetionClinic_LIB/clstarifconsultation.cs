using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifconsultation 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private int id_de_consultation;
 private string designationConplete;

  //***Listes***
  public List<clstarifconsultation> listes(){
 return clsMetier.GetInstance().getAllClstarifconsultation();
}
 public  List<clstarifconsultation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifconsultation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifconsultation(this);
 }
 public  int  update(clstarifconsultation varscls){
 return clsMetier.GetInstance().updateClstarifconsultation(varscls);
 }
 public  int  delete(clstarifconsultation varscls){
 return clsMetier.GetInstance().deleteClstarifconsultation(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifconsultation() 
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
 //***Accesseur de designationComplete***
 public string DesignationConplete
 {
     get { return designationConplete; }
     set { designationConplete = value; }
 }
 public override string ToString()
 {
     return DesignationConplete;//return this.Designation + "=>" + this.Montant + " $US";
 }
 //***Accesseur de id_de_consultation***
 public int Id_de_consultation
 {
     get { return id_de_consultation; }
     set { id_de_consultation = value; }
 }
} //***fin class

} //***fin namespace
