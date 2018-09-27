using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsdossierpreconsultation 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private DateTime?  date ;
 private int   id_malade ;
 private int id_tarifpreconsultation;
 private string designationComplete;
 private string etatpaiement;
 private double? cumul;

  //***Listes***
  public List<clsdossierpreconsultation> listes(){
 return clsMetier.GetInstance().getAllClsdossierpreconsultation();
}
 public  List<clsdossierpreconsultation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsdossierpreconsultation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsdossierpreconsultation(this);
 }
 public  int  update(clsdossierpreconsultation varscls){
 return clsMetier.GetInstance().updateClsdossierpreconsultation(varscls);
 }
 public  int  delete(clsdossierpreconsultation varscls){
 return clsMetier.GetInstance().deleteClsdossierpreconsultation(varscls);
 }
  //***Le constructeur par defaut***
  public    clsdossierpreconsultation() 
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
  //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
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
 //***Accesseur de cumul***
 public double? Cumul
 {
     get { return cumul; }
     set { cumul = value; }
 }
} //***fin class

} //***fin namespace