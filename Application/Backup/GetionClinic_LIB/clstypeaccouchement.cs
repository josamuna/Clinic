using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstypeaccouchement 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double   prix ;
 private string designationComplete;
 private int id_de_dossieraccouchement;
  //***Listes***
  public List<clstypeaccouchement> listes(){
 return clsMetier.GetInstance().getAllClstypeaccouchement();
}
 public  List<clstypeaccouchement>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstypeaccouchement(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstypeaccouchement(this);
 }
 public  int  update(clstypeaccouchement varscls){
 return clsMetier.GetInstance().updateClstypeaccouchement(varscls);
 }
 public  int  delete(clstypeaccouchement varscls){
 return clsMetier.GetInstance().deleteClstypeaccouchement(varscls);
 }
  //***Le constructeur par defaut***
  public    clstypeaccouchement() 
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
  //***Accesseur de prix***
 public  double   Prix {

get { return prix; } 
set { prix = value; }
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

 public int Id_de_dossieraccouchement
 {
     get { return id_de_dossieraccouchement; }
     set { id_de_dossieraccouchement = value; }
 }
} //***fin class

} //***fin namespace
