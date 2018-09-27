using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifpreconsultation 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationConplete;
 private int id_de_dossierpreconsultation;

  //***Listes***
  public List<clstarifpreconsultation> listes(){
 return clsMetier.GetInstance().getAllClstarifpreconsultation();
}
 public  List<clstarifpreconsultation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifpreconsultation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifpreconsultation(this);
 }
 public  int  update(clstarifpreconsultation varscls){
 return clsMetier.GetInstance().updateClstarifpreconsultation(varscls);
 }
 public  int  delete(clstarifpreconsultation varscls){
 return clsMetier.GetInstance().deleteClstarifpreconsultation(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifpreconsultation() 
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
     return DesignationConplete;
 }
 //***Accesseur de id_de_dossierpreconsultation***
 public int Id_de_dossierpreconsultation
 {
     get { return id_de_dossierpreconsultation; }
     set { id_de_dossierpreconsultation = value; }
 }
} //***fin class

} //***fin namespace
