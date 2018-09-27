using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsetablissementpriseencharge 
{
  //***Les variables globales***
 private int   id ;
 private string   denomination ;
 private string   adresse ;
 private string telephone;
 private double taux;

  //***Listes***
  public List<clsetablissementpriseencharge> listes(){
 return clsMetier.GetInstance().getAllClsetablissementpriseencharge();
}
 public  List<clsetablissementpriseencharge>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsetablissementpriseencharge(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsetablissementpriseencharge(this);
 }
 public  int  update(clsetablissementpriseencharge varscls){
 return clsMetier.GetInstance().updateClsetablissementpriseencharge(varscls);
 }
 public  int  delete(clsetablissementpriseencharge varscls){
 return clsMetier.GetInstance().deleteClsetablissementpriseencharge(varscls);
 }
  //***Le constructeur par defaut***
  public    clsetablissementpriseencharge() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de denomination***
 public  string   Denomination {

get { return denomination; } 
set { denomination = value; }
}
  //***Accesseur de adresse***
 public  string   Adresse {

get { return adresse; } 
set { adresse = value; }
}
  //***Accesseur de telephone***
 public  string   Telephone {

get { return telephone; } 
set { telephone = value; }
}
 public double Taux
 {
     get { return taux; }
     set { taux = value; }
 }
} //***fin class

} //***fin namespace
