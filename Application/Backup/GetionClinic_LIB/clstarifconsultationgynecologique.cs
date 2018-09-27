using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifconsultationgynecologique 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationConplete;
 private int id_de_dossierconsultationgynecologique;

  //***Listes***
  public List<clstarifconsultationgynecologique> listes(){
 return clsMetier.GetInstance().getAllClstarifconsultationgynecologique();
}
 public  List<clstarifconsultationgynecologique>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifconsultationgynecologique(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifconsultationgynecologique(this);
 }
 public  int  update(clstarifconsultationgynecologique varscls){
 return clsMetier.GetInstance().updateClstarifconsultationgynecologique(varscls);
 }
 public  int  delete(clstarifconsultationgynecologique varscls){
 return clsMetier.GetInstance().deleteClstarifconsultationgynecologique(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifconsultationgynecologique() 
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
 //***Accesseur de id_de_dossierconsultationgynecologique***
 public int Id_de_dossierconsultationgynecologique
 {
     get { return id_de_dossierconsultationgynecologique; }
     set { id_de_dossierconsultationgynecologique = value; }
 }
} //***fin class

} //***fin namespace
