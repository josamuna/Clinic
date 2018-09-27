using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsfichesupplementaire 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private DateTime?  date ;
 private int   id_dossierpreconsultation ;
 private int id_tarifpreconsultation;
 private string designationComplete;
 private string etatpaiement;
 private double montant;

  //***Listes***
  public List<clsfichesupplementaire> listes(){
 return clsMetier.GetInstance().getAllClsfichesupplementaire();
}
 public  List<clsfichesupplementaire>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsfichesupplementaire(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsfichesupplementaire(this);
 }
 public  int  update(clsfichesupplementaire varscls){
 return clsMetier.GetInstance().updateClsfichesupplementaire(varscls);
 }
 public  int  delete(clsfichesupplementaire varscls){
 return clsMetier.GetInstance().deleteClsfichesupplementaire(varscls);
 }
  //***Le constructeur par defaut***
  public    clsfichesupplementaire() 
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
  //***Accesseur de id_dossierpreconsultation***
 public  int   Id_dossierpreconsultation {

get { return id_dossierpreconsultation; } 
set { id_dossierpreconsultation = value; }
}
  //***Accesseur de etatpaiement***
 public  string   Etatpaiement {

get { return etatpaiement; } 
set { etatpaiement = value; }
}
 //***Accesseur de id_tarifpreconsultation***
 public int Id_tarifpreconsultation
 {
     get { return id_tarifpreconsultation; }
     set { id_tarifpreconsultation = value; }
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
 //***Accesseur de id_tarifpreconsultation***
 public double Montant
 {
     get { return montant; }
     set { montant = value; }
 }
} //***fin class

} //***fin namespace