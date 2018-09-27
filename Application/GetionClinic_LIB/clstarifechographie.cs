
using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clstarifechographie 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationComplete;
 private int id_de_dossierechographie;

  //***Listes***
  public List<clstarifechographie> listes(){
 return clsMetier.GetInstance().getAllClstarifechographie();
}
 public  List<clstarifechographie>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifechographie(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifechographie(this);
 }
 public  int  update(clstarifechographie varscls){
 return clsMetier.GetInstance().updateClstarifechographie(varscls);
 }
 public  int  delete(clstarifechographie varscls){
 return clsMetier.GetInstance().deleteClstarifechographie(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifechographie() 
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
 //***Accesseur de id_de_dossierechographie***
 public int Id_de_dossierechographie
 {
     get { return id_de_dossierechographie; }
     set { id_de_dossierechographie = value; }
 }
} //***fin class

} //***fin namespace
