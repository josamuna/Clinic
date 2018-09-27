using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clschambre 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private string designationConplete;
 private double?  numero ;
 private int?  id_categoriechambre ;
 private int nbrjour;
 private int id_de_hospitalisation;
 private double prix_de_chambre;
 
  //***Listes***
  public List<clschambre> listes(){
 return clsMetier.GetInstance().getAllClschambre();
}
 public  List<clschambre>   listes(string criteria){
 return clsMetier.GetInstance().getAllClschambre(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClschambre(this);
 }
 public  int  update(clschambre varscls){
 return clsMetier.GetInstance().updateClschambre(varscls);
 }
 public  int  delete(clschambre varscls){
 return clsMetier.GetInstance().deleteClschambre(varscls);
 }
  //***Le constructeur par defaut***
  public    clschambre() 
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
  //***Accesseur de numero***
 public  double ?   Numero {

get { return numero; } 
set { numero = value; }
}
  //***Accesseur de id_categoriechambre***
 public  int ?   Id_categoriechambre {

get { return id_categoriechambre; } 
set { id_categoriechambre = value; }
}
 //***Accesseur de designationComplete***
 public string DesignationConplete
 {
     get { return designationConplete; }
     set { designationConplete = value; }
 }
 //***Accesseur de nbrjour***
 public int Nbrjour
 {
     get { return nbrjour; }
     set { nbrjour = value; }
 }
 public override string ToString()
 {
     return designationConplete;
 }
 //***Accesseur de id_de_hospitalisation***
 public int Id_de_hospitalisation
 {
     get { return id_de_hospitalisation; }
     set { id_de_hospitalisation = value; }
 }
 //***Accesseur de prix_de_chambre***
 public double Prix_de_chambre
 {
     get { return prix_de_chambre; }
     set { prix_de_chambre = value; }
 }
} //***fin class

} //***fin namespace
